using DSSGEDAdmin.Models.DAL;
using DSSGEDAdmin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSSGEDAdmin.Models.BLL
{
    public class BLL_DocumentType
    {
        public static void Add(DocumentType documentType)
        {
            DAL_DocumentType.Add(documentType);
        }
        public static void Update(int id, DocumentType documentType)
        {
            DAL_DocumentType.Update(id, documentType);
        }
        public static void Delete(int id)
        {
            DAL_DocumentType.Delete(id);
        }
        public static DocumentType SelectById(int id)
        {
            return DAL_DocumentType.SelectById(id);
        }
        public static List<DocumentType> SelectAll()
        {
            return DAL_DocumentType.SelectAll();
        }
    }
}
