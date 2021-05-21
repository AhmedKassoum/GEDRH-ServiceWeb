using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSSGEDAdmin.Models.BLL;
using DSSGEDAdmin.Models.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DSSGEDAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : Controller
    {
        [Route("")]
        [HttpGet]
        public JsonResult Get(string DBName)
        {
            try
            {
                List<Folder> folders = BLL_Folder.SelectAll();
                return Json(new { success = true, message = "Dossiers trouvent", data = folders });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e.Message });
            }
        }

        [Route("GetByPerson/{id}")]
        [HttpGet]
        public JsonResult GetByPerson(int id)
        {
            try
            {
                List<Folder> folder = BLL_Folder.SelectByPerson(id);
                return Json(new { success = true, message = "Dossier trouve", data = folder });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e.Message });
            }
        }

        [Route("{id}")]
        [HttpGet]
        public JsonResult Get(int id, string DBName)
        {
            try
            {
                Folder folder = BLL_Folder.SelectById(id);
                return Json(new { success = true, message = "Dossier trouve", data = folder });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e.Message });
            }
        }

        [Route("")]
        [HttpPost]
        public JsonResult Post(Folder folder)
        {
            try
            {
                BLL_Folder.Add(folder);
                return Json(new { success = true, message = "Dossier ajouté avec success" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Erreur serveur: " + ex.Message });
            }
        }

        [Route("{id}")]
        [HttpPut]
        public JsonResult Put(int id,Folder folder)
        {
            try
            {
                BLL_Folder.Update(id,folder);
                return Json(new { success = true, message = "Dossier modifié avec succès" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Erreur serveur: " + ex.Message });
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            try
            {
                BLL_Folder.Delete(id);
                return Json(new { success = true, message = "Dossier supprimé avec succès" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [Route("DeleteByPerson/{id}")]
        [HttpDelete]
        public JsonResult DeleteByPerson(int id)
        {
            try
            {
                BLL_Folder.DeleteByPerson(id);
                return Json(new { success = true, message = "Dossier supprimé avec succès" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
