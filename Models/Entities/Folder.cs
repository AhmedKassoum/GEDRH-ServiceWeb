using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSSGEDAdmin.Models.Entities
{
    public class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PathName { get; set; }
        public int IdPerson { get; set; }
        public string Description { get; set; }
        //public DateTime? CreationDate { get; set; }
        //public string CreatedBy { get; set; }
        //public int IdParent { get; set; }
        //public bool IsTerminal { get; set; }
        //public int? IdOwner { get; set; }
    }
}
