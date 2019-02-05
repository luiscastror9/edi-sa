using CNV_Site.Areas.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNV_Site.Areas.BackOffice.Extensions;


namespace CNV_Site.Areas.BackOffice.Controllers
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
        [Authorize]
        public ActionResult BannerDataSurvey(jQueryDataTableParamModel param)
        {
            var BannersHome = BO.SliderHome.ToList();


            var displayedBannersHome = BannersHome
                        .Skip(param.iDisplayStart)
                        .Take(param.iDisplayLength);

            var result = from c in displayedBannersHome
                         select new { c.IdSlideHome, c.descSlideHome, c.urlSlideHome, c.urlImgSlideHome };

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = BannersHome.Count(),
                iTotalDisplayRecords = BannersHome.Count(),
                aaData = result
            },
             JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult EditBanner(int id)
        {
            SliderHome Banner = BO.SliderHome.Where(x => x.IdSlideHome == id).FirstOrDefault();

            return View(Banner);
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteBanner(int id)
        {
            try
            {
                SliderHome Banner = BO.SliderHome.Where(x => x.IdSlideHome == id).FirstOrDefault();
                BO.Entry(Banner).State = System.Data.Entity.EntityState.Deleted;
                BO.SaveChanges();
                Success("Se ha Eliminado el Banner con Exito!");
                return RedirectToAction("Banner");

            }
            catch
            {
                Danger("Ha Ocurrido un Error!");
                return RedirectToAction("Banner");

            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditBanner(int id, IEnumerable<HttpPostedFileBase> urlImgSlideHome, FormCollection data)
        {
            try
            {
                SliderHome Banner = BO.SliderHome.Where(x => x.IdSlideHome == id).FirstOrDefault();
            Banner.nameSlideHome = data["nameSlideHome"];
            Banner.descSlideHome = data["descSlideHome"];
            Banner.urlSlideHome = data["urlSlideHome"];
            bool activeH = data["h_activeSlideHome"] == "true" ? true : false;
            Banner.activeSlideHome = activeH;
            if (urlImgSlideHome.Count() > 0)
            {
                foreach (var f in urlImgSlideHome)
                {
                        if (f != null)
                        {
                            string _filepath = Path.GetFileName(f.FileName);
                            string _path = Path.Combine(Server.MapPath("~/Content/Upload"), _filepath);

                            f.SaveAs(_path);
                            Banner.urlImgSlideHome = Path.GetFileName(urlImgSlideHome.First().FileName);

                        }
                    }
            }
            DateTime date = DateTime.Now;
            Banner.update_datetime = date;
                BO.Entry(Banner).State = System.Data.Entity.EntityState.Modified;
                BO.SaveChanges();
                Success("Se ha Actualizado el Banner con Exito!");
                return RedirectToAction("Banner");
            }
            catch
            {
                Danger("Ha Ocurrido un Error!");
                return RedirectToAction("Banner");

            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreateBanner(IEnumerable<HttpPostedFileBase> urlImgSlideHome, FormCollection data)
        {
            try { 
            SliderHome Banner = new SliderHome();
                Banner.nameSlideHome = data["nameSlideHome"];
                Banner.descSlideHome = data["descSlideHome"];
                Banner.urlSlideHome = data["urlSlideHome"];
                bool activeH = data["h_activeSlideHome"] == "true" ? true : false;
                Banner.activeSlideHome = activeH;
                // HttpPostedFileBase file = (HttpPostedFileBase)data["urlImgSlideHome"];
                if (urlImgSlideHome.Count()>0)
                {
                    foreach (var f in urlImgSlideHome) { 
                        string _filepath = Path.GetFileName(f.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Content/Upload"),_filepath);

                        f.SaveAs(_path);
                    }
                }
                Banner.urlImgSlideHome = Path.GetFileName(urlImgSlideHome.First().FileName);
                DateTime date= DateTime.Now;
                Banner.create_datetime = date;
                BO.SliderHome.Add(Banner);
                BO.SaveChanges();
                Success("Se ha Agregado el Banner con Exito!");
                return RedirectToAction("Banner");
            }
            catch 
            {
                Danger("Ha Ocurrido un Error!");
                return RedirectToAction("Banner");

            }
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
            CNV_Site.Areas.BackOffice.Models.Consulta Consulta = new Models.Consulta();
            Consulta=Consulta.DtoConsultasSimple(BO.sp_Select_Consultas(0,id,"").FirstOrDefault());

            return View(Consulta);
        }

      [Authorize]
        public ActionResult ResponderConsulta(int id)
        {
            CNV_Site.Areas.BackOffice.Models.Consulta Consulta = new Models.Consulta();
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
