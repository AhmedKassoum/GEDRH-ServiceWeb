using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSSGEDAdmin.Models.Entities
{
    public class DocTypeCustomField
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int DocTypeId { get; set; }
        public string TypeValue { get; set; }
        public string AcceptNull { get; set; }

    }
}
