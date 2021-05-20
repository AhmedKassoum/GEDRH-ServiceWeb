using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSSGEDAdmin.Models.BLL;
using DSSGEDAdmin.Models.DAL;
using DSSGEDAdmin.Models.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DSSGEDAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocTypeCustomFieldController : Controller
    {
        //[Route("")]
        //[HttpGet]
        //public JsonResult Get(string DBName)
        //{
        //    try
        //    {
        //        List<DocTypeCustomField> docTypeCustomFields = BLL_DocTypeCustomField.SelectAll(DBName);
        //        return Json(new { success = true, message = "Documents type champs personnalisés trouve", data = docTypeCustomFields });
        //    }
        //    catch (Exception e)
        //    {
        //        return Json(new { success = false, message = e.Message });
        //    }
        //}

        [Route("GetByDocTCF/{id}")]
        [HttpGet]
        public JsonResult GetByDocTCF(int id)
        {
            try
            {
                List<DocTypeCustomField> docTypeCustomField = DAL_DocTypeCustomField.SelectByDocTypeId(id);
                return Json(new { success = true, message = "Document type champs personnalisés trouve", data = docTypeCustomField });
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
                DocTypeCustomField docTypeCustomField = DAL_DocTypeCustomField.SelectById(id);
                return Json(new { success = true, message = "Document type champs personnalisés trouve", data = docTypeCustomField });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e.Message });
            }
        }

        [Route("")]
        [HttpPost]
        public JsonResult Post(DocTypeCustomField docTypeCustomField)
        {
            try
            {
                DAL_DocTypeCustomField.Add(docTypeCustomField);
                return Json(new { success = true, message = "DocTypeCustomField ajouté avec success" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Erreur serveur: " + ex.Message });
            }
        }

        [Route("{id}")]
        [HttpPut]
        public JsonResult Put(int id, DocTypeCustomField docTypeCustomField)
        {
            try
            {
                DAL_DocTypeCustomField.Update(id, docTypeCustomField);
                return Json(new { success = true, message = "DocTypeCustomField modifié avec succès" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Erreur serveur: " + ex.Message });
            }
        }

        //[Route("{id}")]
        //[HttpDelete]
        //public JsonResult Delete(int id, string DBName)
        //{
        //    try
        //    {
        //        BLL_DocTypeCustomField.Delete(id, DBName);
        //        return Json(new { success = true, message = "DocTypeCustomField supprimé avec succès" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, message = "Erreur serveur: " + ex.Message });
        //    }
        //}
    }
}
