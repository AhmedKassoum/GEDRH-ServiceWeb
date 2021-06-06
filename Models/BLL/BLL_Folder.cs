using DSSGEDAdmin.Models.DAL;
using DSSGEDAdmin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSSGEDAdmin.Models.BLL
{
    public class BLL_Folder
    {
        public static void Add(Folder folder)
        {
            DAL_Folder.Add(folder);
        }
        public static void Update(int id,Folder folder)
        {
            DAL_Folder.Update(id,folder);
        }
        public static void Delete(int id)
        {
            DAL_Folder.Delete(id);
        }
        public static void DeleteByPerson(int id)
        {
            DAL_Folder.DeleteByPerson(id);
        }
        public static void DeleteGetChildsFolder(int pid)
        {
            DAL_Folder.DeleteGetChildsFolder(pid);
        }
        public static Folder SelectById(int id)
        {
            return DAL_Folder.SelectById(id);
        }
        public static int SelectByPersonId(int id)
        {
            return DAL_Folder.SelectByPersonId(id);
        }
        public static List<Folder> SelectAll()
        {
            return DAL_Folder.SelectAll();
        }
        public static List<Folder> SelectByPerson(int Id)
        {
            return DAL_Folder.SelectByPerson(Id);
        }
        public static List<int> GetParents(int id)
        {
            return DAL_Folder.GetParents(id);
        }
        public static void GetChilds(int pid, List<int> IdChilds)
        {
            DAL_Folder.GetChilds(pid, IdChilds);
        }
    }
}
