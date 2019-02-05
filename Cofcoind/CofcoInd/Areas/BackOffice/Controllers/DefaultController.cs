using CofcoInd.Areas.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CofcoInd.Areas.BackOffice.Extensions;


namespace CofcoInd.Areas.BackOffice.Controllers
{
    public class DefaultController : AlertsController
    {
      public EntitiesBO BO = new EntitiesBO();

        // GET: BackOffice/Default
        [Authorize]
        public ActionResult Index()
        {

           return View();
        }

        

        [Authorize]
        public ActionResult Banner()
        {

            return View();
        }
        [Authorize]
        public ActionResult Consulta()
        {

            return View();
        }



        #region Banner Home

        [Authorize]
        public ActionResult CreateBanner()
        {

            return View();
        }
  
      
        #endregion

        #region Consulta
        [Authorize]
        public ActionResult ConsultaDataSurvey(jQueryDataTableParamModel param)
        {
            var ConsultasHome = BO.Consultas.ToList();


            var displayedConsultasHome = ConsultasHome
                        .Skip(param.iDisplayStart)
                        .Take(param.iDisplayLength);

            var result = from c in displayedConsultasHome
                         select new { c.IdConsulta, c.NombreConsulta, c.EmailConsulta };

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = ConsultasHome.Count(),
                iTotalDisplayRecords = ConsultasHome.Count(),
                aaData = result
            },
             JsonRequestBehavior.AllowGet);
        }

   [Authorize]
        public ActionResult ViewConsulta(int id)
        {
            CofcoInd.Areas.BackOffice.Models.Consulta Consulta = new Models.Consulta();
            Consulta=Consulta.DtoConsultasSimple(BO.sp_Select_Consultas(0,id,"").FirstOrDefault());

            return View(Consulta);
        }

      [Authorize]
        public ActionResult ResponderConsulta(int id)
        {
            CofcoInd.Areas.BackOffice.Models.Consulta Consulta = new Models.Consulta();
            Consulta = Consulta.DtoConsultasSimple(BO.sp_Select_Consultas(0, id, "").FirstOrDefault());
            return View(Consulta);
        }

        //[Authorize]
        //[HttpPost]
        //public ActionResult DeleteConsulta(int id)
        //{
        //    try
        //    {
        //        Consultas Consulta = BO.Consultas.Where(x => x.IdConsulta == id).FirstOrDefault();
        //        BO.Entry(Consulta).State = System.Data.Entity.EntityState.Deleted;
        //        BO.SaveChanges();
        //        Success("Se ha Eliminado la Consulta con Exito!");
        //        return RedirectToAction("Consulta");

        //    }
        //    catch
        //    {
        //        Danger("Ha Ocurrido un Error!");
        //        return RedirectToAction("Consulta");

        //    }
        //}

       [Authorize]
        [HttpPost]
        [ValidateInput(false)]

        public ActionResult ResponderConsulta(int id, FormCollection data)
        {
            try
            {
                
                Consultas ConsultaEmail = BO.Consultas.Where(x => x.IdConsulta == id).SingleOrDefault();
                RespuestaConsultas Consulta = new RespuestaConsultas();
                EmailHelper eh = new EmailHelper();
                var username = HttpContext.Request.ServerVariables["LOGON_USER"];
                if (username == "") username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

                Consulta.NombreRespuestaConsultas = username;

                Consulta.contenidoConsulta = data["contenidoConsulta"];
                Consulta.IdConsulta = id;
                DateTime date = DateTime.Now;
                Consulta.create_datetime = date;
                BO.RespuestaConsultas.Add(Consulta);
                BO.SaveChanges();
                if (eh.SendEmail(ConsultaEmail.EmailConsulta, "", Consulta.contenidoConsulta)) { 
                Success("Se ha respondido la consulta con Exito!");
                return RedirectToAction("Consulta");
                }
                else
                {
                    Danger("Ha Ocurrido un Error!");
                    return RedirectToAction("Consulta");
                }
            }
            catch
            {
                Danger("Ha Ocurrido un Error!");
                return RedirectToAction("Consulta");

            }
        }

        #endregion

    }
}
