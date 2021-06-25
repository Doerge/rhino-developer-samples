using System;
using Rhino;

namespace SampleCsEto.Selections
{
    public static class DocData
    {
        public static SelectionStore SelectionStore(RhinoDoc doc)
        {
            return doc.RuntimeData.GetValue(typeof(SelectionStore), rhinoDoc => new SelectionStore(rhinoDoc.RuntimeSerialNumber));
        }

        public static SelectionStore GetSelectionStore(RhinoDoc rhinoDoc) { return SelectionStore(rhinoDoc); }
    }
}

