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
    public class DocumentController : Controller
    {
        [Route("")]
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<Document> Documents = BLL_Document.SelectAll();
                return Json(new { success = true, message = "Documents trouve", data = Documents });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e.Message });
            }
        }

        [Route("{id}")]
        [HttpGet]
        public JsonResult Get(int id)
        {
            try
            {
                Document Document = BLL_Document.SelectById(id);
                return Json(new { success = true, message = "Document trouve", data = Document });
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
                List<Document> Documents = BLL_Document.SelectByPersonId(id);
                return Json(new { success = true, message = "Document trouve", data = Documents });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e.Message });
            }
        }

        [Route("GetDocumentByFolder/{id}")]
        [HttpGet]
        public JsonResult GetDocumentByFolder(int id)
        {
            try
            {
                List<Document> Documents = BLL_Document.SelectByFolder(id);
                return Json(new { success = true, message = "Document trouve", data = Documents });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e.Message });
            }
        }

        [Route("GetDocumentByDocType/{id}")]
        [HttpGet]
        public JsonResult GetDocumentByDocType(int id)
        {
            try
            {
                List<Document> Documents = BLL_Document.SelectByDocType(id);
                return Json(new { success = true, message = "Document trouve", data = Documents });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e.Message });
            }
        }

        [Route("GetByFolderAndDocType/{idDocType}/{idFolder}")]
        [HttpGet]
        public JsonResult GetByFolderAndDocType(int idDocType, int idFolder)
        {
            try
            {
                List<Document> Documents = BLL_Document.SelectAllByFolderAndDocType(idDocType,idFolder);
                return Json(new { success = true, message = "Document trouve", data = Documents });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e.Message });
            }
        }


        [Route("")]
        [HttpPost]
        public JsonResult Post(Document Document)
        {
            try
            {
                BLL_Document.Add(Document);
                return Json(new { success = true, message = "Document ajouté avec success" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Erreur serveur: " + ex.Message });
            }
        }

        [Route("{id}")]
        [HttpPut]
        public JsonResult Put(int id, Document Document)
        {
            try
            {
                BLL_Document.Update(id, Document);
                return Json(new { success = true, message = "Document modifié avec succès" });
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
                BLL_Document.Delete(id);
                return Json(new { success = true, message = "Document supprimé avec succès" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Erreur serveur: " + ex.Message });
            }
        }
    }
}
