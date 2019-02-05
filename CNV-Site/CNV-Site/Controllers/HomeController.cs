using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using CNV_Site.Areas.BackOffice;
using CNV_Site.Areas.BackOffice.Extensions;
using System.Configuration;
using RestSharp;
using CNV_Site.Models;
using System.Net.Mime;
using System.Text;
using System.Data.Entity.Core.Objects;
using CNV_Site.Areas.BackOffice.Models;

namespace CNV_Site.Controllers
{
    public class HomeController : Controller
    {
        public CNV_Site.Areas.BackOffice.EntitiesBO BO = new CNV_Site.Areas.BackOffice.EntitiesBO();

             [AllowAnonymous]
        public ActionResult Index()
        {
          
            var client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            var request = new RestRequest("/HechosRelevantesPorTipoEntidad/1/?desde=" + DateTime.Today.AddMonths(-12).ToShortDateString()+"&limit=5", Method.GET);
            ListaDocumentos DOCSHR = new ListaDocumentos();
            ListaDocumentos DOCSUN = new ListaDocumentos();

            IRestResponse response = client.Execute(request);
            if(response.StatusCode!= System.Net.HttpStatusCode.NotFound)
            DOCSHR = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaDocumentos>(response.Content);

            client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            request = new RestRequest("/HechosRelevantesPorTipoEntidad/1/?desde=" + DateTime.Today.AddMonths(-12).ToShortDateString()+"&limit=5", Method.GET);

             response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                DOCSUN = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaDocumentos>(response.Content);

            
            List<Areas.BackOffice.sp_Select_SliderHome_Result> SSL= BO.sp_Select_SliderHome(0,null,null).OrderByDescending(z => z.create_datetime).Take(5).ToList();
            SlidersHome No = new Areas.BackOffice.Models.SlidersHome();
            
            List<Areas.BackOffice.Models.SlidersHome> SL = No.DtoSliderHome(SSL);

            List<Areas.BackOffice.sp_Select_Notes_Result> Ns = BO.sp_Select_Notes(0, null, null).OrderByDescending(z => z.create_datetime).Take(5).ToList();
            Note Nn = new Areas.BackOffice.Models.Note();
            List<Note> N = Nn.DtoNotes(Ns);
            ViewModelHome Vhome = new ViewModelHome();
            Vhome.N = N ?? new List<Note>();
            Vhome.SL = SL ?? new List<SlidersHome>();
            Vhome.DOCSHR = DOCSHR.data==null ? new List<Documentos>(): DOCSHR.data;
            Vhome.DOCSUN = DOCSUN.data == null ? new List<Documentos>() : DOCSUN.data;

            return View(Vhome);
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
                con.create_datetime = DateTime.Now;
                BO.sp_Insert_Consultas(con.NombreConsulta, con.EmailConsulta, con.contenidoConsulta, con.cuitConsulta, con.domicilioConsulta, con.residenciaConsulta, con.cpConsulta, con.telefonoConsulta);

                //BO.Consultas.Add(con);
                // BO.SaveChanges();
                EmailHelper eh = new EmailHelper();
                eh.SendEmail(con.EmailConsulta, "Contacto desde CNV", eh.bodyhtml(con));
                TempData["msg"] = "<script>alert('se ha enviado el contacto satisfactoriamente');</script>";
                return RedirectToAction("Contacto");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "<script>alert('Ha Ocurrido un error al Enviar el formulario.');</script>";
                return RedirectToAction("Contacto");
            }


        }

        [AllowAnonymous]
        public ActionResult AIF()
        {

            return View();
        }

    }
}