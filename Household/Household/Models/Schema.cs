using System;
using System.Collections.Generic;
using System.Text;

namespace Household.Models
{
    public class Schema
    {
        public Guid Id { get; set; }
        public List<PropertyDefinition> Definitions { get; set; }

        public Schema() : this(null)
        {
        }

        public Schema(Instance instance)
        {
            Id = Guid.NewGuid();
            Definitions = new List<PropertyDefinition>();

            if (instance == null)
            {
                Definitions.Add(new PropertyDefinition());
            }
            else
            {
                // Cloning
                foreach(var definition in instance.Properties.Definitions)
                {
                    var clonedDefinition = new PropertyDefinition(definition);
                    string propertyValue = null; 
                    if (instance.Values.TryGetValue(definition.Id, out propertyValue))
                    {
                        instance.Values.Remove(definition.Id);
                        instance.Values.Add(clonedDefinition.Id, propertyValue);
                    }
                }
            }
        }
    }
}
