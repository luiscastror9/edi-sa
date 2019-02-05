using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CofcoInd.Areas.Models;


namespace CofcoInd.Areas.BackOffice.Controllers
{
    public class ConfiguracionController : AlertsController
    {
        public EntitiesBO BO = new EntitiesBO();
        //
        // GET: /BackOffice/Configuracion/
         [Authorize]
        public ActionResult Index()
        {
            return View();
        }
         [Authorize]
        public ActionResult ConfiguracionDataSurvey(jQueryDataTableParamModel param)
        {
            var SettingsIntegrationNotes = BO.sp_Select_SettingsIntegrationNotes(0, null, null).ToList();


            var displayedSettingsIntegrationNotes = SettingsIntegrationNotes
                        .Skip(param.iDisplayStart)
                        .Take(param.iDisplayLength);

            var result = from c in displayedSettingsIntegrationNotes
                         select new { c.IdSettingsIntegrationNotes, c.descSettingsIntegrationNotes,c.keySettingsIntegrationNotes,c.valueSettingsIntegrationNotes };

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = SettingsIntegrationNotes.Count(),
                iTotalDisplayRecords = SettingsIntegrationNotes.Count(),
                aaData = result
            },
             JsonRequestBehavior.AllowGet);
        }
         [Authorize]
        public ActionResult Edit(int id)
        {
            SettingsIntegrationNotes Setting = BO.SettingsIntegrationNotes.Where(x => x.IdSettingsIntegrationNotes == id).FirstOrDefault();
            return View(Setting);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection data)
        {
            try
            {
                SettingsIntegrationNotes Setting = BO.SettingsIntegrationNotes.Where(x => x.IdSettingsIntegrationNotes == id).FirstOrDefault();
                Setting.valueSettingsIntegrationNotes = data["keySettingsIntegrationNotes"];
               
                bool activeH = data["h_ActiveSettingsIntegrationNotes"] == "true" ? true : false;
                Setting.ActiveSettingsIntegrationNotes = activeH;
                DateTime date = DateTime.Now;
                Setting.update_datetime = date;
                BO.Entry(Setting).State = System.Data.Entity.EntityState.Modified;
                BO.SaveChanges();
                Success("Se ha Actualizado el Articulos con Exito!");
                return RedirectToAction("Index");
            }
            catch
            {
                Danger("Ha Ocurrido un Error!");
                return RedirectToAction("Index");

            }
        }

    }
}