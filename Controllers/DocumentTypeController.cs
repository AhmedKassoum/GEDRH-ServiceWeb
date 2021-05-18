using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSSGEDAdmin.Models.BLL;
using DSSGEDAdmin.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSSGEDAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : Controller
    {
        [Route("")]
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<DocumentType> documentTypes = BLL_DocumentType.SelectAll();
                return Json(new { data = documentTypes });
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
                DocumentType documentType = BLL_DocumentType.SelectById(id);
                return Json(new { success = true, message = "Document type trouve", data = documentType });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e.Message });
            }
        }

        [Route("")]
        [HttpPost]
        public JsonResult Post(DocumentType documentType)
        {
            try
            {
                BLL_DocumentType.Add(documentType);
                return Json(new { success = true, message = "DocumentType ajouté avec success" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Erreur serveur: " + ex.Message });
            }
        }

        [Route("{id}")]
        [HttpPut]
        public JsonResult Put(int id, DocumentType documentType)
        {
            try
            {
                BLL_DocumentType.Update(id, documentType);
                return Json(new { success = true, message = "DocumentType modifié avec succès" });
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
                BLL_DocumentType.Delete(id);
                return Json(new { success = true, message = "DocumentType supprimé avec succès" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Erreur serveur: " + ex.Message });
            }
        }
    }
}
