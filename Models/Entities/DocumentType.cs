using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSSGEDAdmin.Models.Entities
{
    public class DocumentType
    {
        public int Id { get; set; }
        //public string Code { get; set; }
        public string Name { get; set; }
        //public string DocTypePrefix { get; set; }
        public string Description { get; set; }
        //public string ControlDuplication { get; set; }
    }
}
