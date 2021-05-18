using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSSGEDAdmin.Models.Entities
{
    public class Document
    {
        public int Id { get; set; }
        public int IdDocumentType { get; set; }
        public int IdDocumentFolder { get; set; }
        public string Reference { get; set; }
        public string Title { get; set; }
        public string MediaType { get; set; }
        public string FileFormat { get; set; }
        public string FilePath { get; set; }
        public string HasHardCopy { get; set; }
        public DateTime AddingDate { get; set; }
        public string Langage { get; set; }
        public string Tags { get; set; }
        public string Description { get; set; }
        public string CustomFields { get; set; }
        public DocumentType DocType { get; set; }
        public Folder Folder { get; set; }
    }
}
