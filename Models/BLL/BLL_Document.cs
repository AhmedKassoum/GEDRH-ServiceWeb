using DSSGEDAdmin.Models.DAL;
using DSSGEDAdmin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSSGEDAdmin.Models.BLL
{
    public class BLL_Document
    {
        public static void Add(Document document)
        {
            DAL_Document.Add(document);
        }
        public static void Update(int id, Document document)
        {
            DAL_Document.Update(id, document);
        }
        public static void Delete(int id)
        {
            DAL_Document.Delete(id);
        }
        public static void DeleteByDocument(int id)
        {
            DAL_Document.Delete(id);
        }
        public static Document SelectById(int id)
        {
            return DAL_Document.SelectById(id);
        }

        public static List<Document> SelectByFolder(int id)
        {
            return DAL_Document.SelectAllDocumentByFolder(id);
        }
        public static List<Document> SelectByDocType(int id)
        {
            return DAL_Document.SelectAllDocumentByDocType(id);
        }

        public static List<Document> SelectAllByFolderAndDocType(int idDocType, int idFolder)
        {
            return DAL_Document.SelectAllByFolderAndDocType(idDocType,idFolder);
        }
        public static List<Document> SelectAll()
        {
            return DAL_Document.SelectAll();
        }
        public static List<Document> SelectByPersonId(int Id)
        {
            return DAL_Document.SelectByPersonId(Id);
        }
    }
}
