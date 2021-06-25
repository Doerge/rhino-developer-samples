using System.Drawing;
using System.Linq;
using Rhino;
using Rhino.Display;
using Rhino.DocObjects;
using SampleCsEto.Selections;

namespace SampleCsEto
{
    public class DisplayConduit : Rhino.Display.DisplayConduit
    {
        public SelectionStore SelectionStore(RhinoDoc rhinoDoc) { return DocData.SelectionStore(rhinoDoc); }
        public Color TextColor = Color.White;

        protected override void PostDrawObjects(DrawEventArgs e)
        {
            base.PostDrawObjects(e);
            if (e.Display.Viewport.ViewportType == ViewportType.DetailViewport || e.Display.IsPrinting || e.Display.IsInViewCapture)
            {
                // Do not draw anything in DetailViews/Layouts/Printing
                return;
            }

            e.Display.EnableDepthWriting(false);
            e.Display.EnableDepthTesting(false);

            // Draw all blocks
            var instObjs = e.RhinoDoc.Objects
                .FindByFilter(new ObjectEnumeratorSettings { ObjectTypeFilter = ObjectType.InstanceReference });
            foreach (InstanceObject instance in instObjs)
            {
                DrawBlock(e, instance);
            }

            e.Display.EnableDepthWriting(true);
            e.Display.EnableDepthTesting(true);
        }

        private void DrawBlock(DrawEventArgs e, InstanceObject instanceObject)
        {
            // Get the bbox of the InstanceDef
            var bbox = instanceObject.InstanceDefinition.GetObjects()
                .Where(o => o.ObjectType == ObjectType.Brep)
                .Select(o => o.Geometry.GetBoundingBox(false))
                .Aggregate((bboxA, bboxB) =>
                {
                    bboxA.Union(bboxB);
                    return bboxA;
                });
            // Get the center of the bbox of the instancedef and transform it to the instanceobject
            var center = instanceObject.InstanceXform * bbox.Center;

            if (instanceObject.InstanceDefinition.UserDictionary.TryGetInteger(Constants.USER_KEY_ITEM_TEMPLATE_ID, out int myKeyVal))
            {
                // Draw the text as dot
                e.Display.DrawDot(
                    center,
                    $"{Constants.USER_KEY_ITEM_TEMPLATE_ID}: {myKeyVal}",
                    Color.Red,
                    Color.DarkBlue
                );
            }
        }
    }
}
