using System;
using System.Collections.Generic;
using System.Text;

namespace Household.Models
{
    public class PropertyDefinition
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public PropertyTypes DataType { get; set; }

        public PropertyDefinition ClonedFrom { get; set; }

        public PropertyDefinition() : this(null)
        {
        }

        public PropertyDefinition(PropertyDefinition clonedFrom)
        {
            // A new property definition is empty 
            // and can be edited by the user
            Id = Guid.NewGuid();
            ClonedFrom = clonedFrom;
            if (clonedFrom != null)
            {
                Name = clonedFrom.Name;
                DataType = clonedFrom.DataType;
            }
        }
    }
}
