using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSSGEDAdmin.Models.Entities
{
    public class DocTypeCustomField
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool AcceptNull { get; set; }
        //public string MaxLength { get; set; }
        public string DefaultValue { get; set; }
        public int IdDocumentType { get; set; }
        public string ValueList { get; set; }

    }
}
