using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using CofcoInd.Areas.BackOffice;
using CofcoInd.Areas.BackOffice.Extensions;
using System.Configuration;
using RestSharp;
using CofcoInd.Models;
using System.Net.Mime;
using System.Text;
using System.Data.Entity.Core.Objects;
using CofcoInd.Areas.BackOffice.Models;

namespace CofcoInd.Controllers
{
    public class HomeController : Controller
    {
        public CofcoInd.Areas.BackOffice.EntitiesBO BO = new CofcoInd.Areas.BackOffice.EntitiesBO();

             [AllowAnonymous]
        public ActionResult Index()
        {

            return View();
        }
        [AllowAnonymous]
        public JsonResult Getlocalidad(int id)
        {
            return Json(BO.localidades.Where(s => s.id_privincia == id), JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        [Route("sitemap.xml")]
        public ActionResult MapaXml()
        {
            
            GetSiteMapNodes GS = new GetSiteMapNodes();
            var sitemapNodes = GS.GetSitemapNodes(this.Url);
            string xml = GS.GetSitemapDocument(sitemapNodes);
            return this.Content(xml, "text/xml", Encoding.UTF8);
           // return View();
        }
          [AllowAnonymous]
        public ActionResult Legal()
        {

            return View();
        }
      
    
        [AllowAnonymous]
        public ActionResult Mapa()
        {

            return View();
        }
          [AllowAnonymous]
        public ActionResult Contacto()
        {
            ViewBag.provincia = new SelectList(BO.provincias.ToList(), "provincia", "provincia");


            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Contacto(FormCollection data)
        {
            try
            {
                Areas.BackOffice.Consultas con = new Areas.BackOffice.Consultas();
                con.NombreConsulta = data["nombre"];
                con.EmailConsulta = data["email"];
                con.contenidoConsulta = data["info"];
                con.cuitConsulta = data["cuit"];
                con.domicilioConsulta = data["domicilio"];
                con.cpConsulta = data["cp"];
                con.telefonoConsulta = data["telefono"];

                con.apellidoConsulta = data["apellido"];
                con.ocupacionConsulta = data["ocupacion"];
                con.localidadConsulta = data["localidad"];
                con.provinciaConsulta = data["provincia"];
                con.sexoConsulta = data["sexo"];

                con.create_datetime = DateTime.Now;
                BO.sp_Insert_Consultas(con.NombreConsulta, con.EmailConsulta, con.contenidoConsulta, con.cuitConsulta, con.domicilioConsulta, con.residenciaConsulta, con.cpConsulta, con.telefonoConsulta,con.ocupacionConsulta,con.sexoConsulta,con.provinciaConsulta,con.localidadConsulta,con.apellidoConsulta);

                //BO.Consultas.Add(con);
                // BO.SaveChanges();
                EmailHelper eh = new EmailHelper();
                eh.SendEmail(con.EmailConsulta, "Contacto desde Cofco Institucional", eh.bodyhtml(con));
                TempData["msg"] = "<script>alert('se ha enviado el contacto satisfactoriamente');</script>";
                return RedirectToAction("Contacto");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "<script>alert('Ha Ocurrido un error al Enviar el formulario.');</script>";
                return RedirectToAction("Contacto");
            }


        }

      
    }
}