using System;
using System.Collections.Generic;
using System.Text;

namespace Household.Models
{
    public class Instance
    {
        /// <summary>
        /// Done can be:
        /// true => If the Instance is done.
        /// false => If the instance is pending.
        /// </summary>
        public bool Done { get; set; }
        public DateTime? DoneAt { get; set; }
        public Schema Properties { get; set; }

        public Dictionary<Guid,string> Values { get; set; }

        public Instance(Schema properties)
        {
            Properties = properties;
            Values = new Dictionary<Guid, string>();
        }

    }
}
