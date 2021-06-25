using System;
using System.Collections.Generic;
using System.Linq;
using Rhino;
using Rhino.DocObjects;

namespace SampleCsEto.Selections
{
    public class SelectionStore
    {
        public uint DocumentSerialNumber { get; private set; }
        public RhinoDoc Document { get => RhinoDoc.FromRuntimeSerialNumber(DocumentSerialNumber); }
        public HashSet<Guid> selectedBlockIds;

        public SelectionStore(uint documentSerialNumber)
        {
            DocumentSerialNumber = documentSerialNumber;

            RhinoDoc.SelectObjects += OnSelectObjects;
            RhinoDoc.DeselectObjects += OnDeselectObjects;
            RhinoDoc.DeselectAllObjects += OnDeselectAllObjects;

            selectedBlockIds = new HashSet<Guid>();
        }

        // Events
        // NOTE: It is important to always listen to all 3 events, and handle them correctly.
        // Otherwise there are cornercases that are not handled correctly.
        public event EventHandler ObjectSelected;
        public event EventHandler ObjectDeselected;
        public event EventHandler DeselectAllObjects;

        protected virtual void OnDeselectAllObjects(object sender, RhinoDeselectAllObjectsEventArgs args)
        {
            selectedBlockIds.Clear();

            // Emit event
            EventHandler handler = DeselectAllObjects;
            handler?.Invoke(this, args);
        }

        protected virtual void OnSelectObjects(object sender, RhinoObjectSelectionEventArgs args)
        {
            // Get the guids of the currently selected objects
            IEnumerable<Guid> guids = args.RhinoObjects
                    .Select(o => o.Id)
                    .ToArray();

            // Handle Blocks
            var blocks = args.RhinoObjects
                .Where(o => o.ObjectType == ObjectType.InstanceReference)
                .ToArray();

            foreach (var block in blocks)
            {
                selectedBlockIds.Add(block.Id);
            }

            // Emit event
            EventHandler handler = ObjectSelected;
            handler?.Invoke(this, args);
        }

        protected virtual void OnDeselectObjects(object sender, RhinoObjectSelectionEventArgs args)
        {
            // Get the guids of the currently selected objects
            IEnumerable<Guid> guids = args.RhinoObjects
                    .Select(o => o.Id);

            // Handle Blocks
            var blocks = args.RhinoObjects
                .Where(o => o.ObjectType == ObjectType.InstanceReference)
                .ToArray();

            foreach (var block in blocks)
            {
                selectedBlockIds.Remove(block.Id);
            }

            // Emit event
            EventHandler handler = ObjectDeselected;
            handler?.Invoke(this, args);
        }
    }
}