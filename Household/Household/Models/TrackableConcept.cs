using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Household.Models
{
    public class TrackableConcept
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public Instance CurrentInstance { get; set; }
        public List<Instance> Instances { get; set; }

        public TrackableConcept()
        {
            var schema = new Schema();
            Id = Guid.NewGuid();
            CurrentInstance = new Instance(schema);
            Instances = new List<Instance>();
            Instances.Add(CurrentInstance);
        }

        public void NewInstance()
        {
            CurrentInstance = new Instance(CurrentInstance.Properties);
            //TODO: Initialize?
        }

        public void AddProperty()
        {
            // Adds a new Property
            var newProperty = new PropertyDefinition();
            if (Instances.Any(i => i.Properties == CurrentInstance.Properties && i != CurrentInstance))
            {
                // Clone Properties (and update values)
                CurrentInstance.Properties = new Schema(CurrentInstance);

                // TODO: Update Values
            }
        }

        //TODO: Only one property definition can be editable at a time
    }
}
