using DSSGEDAdmin.Models.DAL;
using DSSGEDAdmin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSSGEDAdmin.Models.BLL
{
    public class BLL_DocTypeCustomField
    {
        public static void Add(DocTypeCustomField docTypeCustomField)
        {
            DAL_DocTypeCustomField.Add(docTypeCustomField);
        }
        public static void Update(int id, DocTypeCustomField docTypeCustomField)
        {
            DAL_DocTypeCustomField.Update(id, docTypeCustomField);
        }
        public static void Delete(int id)
        {
            DAL_DocTypeCustomField.Delete(id);
        }
        public static DocTypeCustomField SelectById(int id)
        {
            return DAL_DocTypeCustomField.SelectById(id);
        }
        //public static List<DocTypeCustomField> SelectAll()
        //{
        //    return DAL_DocTypeCustomField.SelectAll();
        //}
    }
}
