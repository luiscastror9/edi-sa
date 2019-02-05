using CNV_Site.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNV_Site.Controllers
{
    public class RegistrosPublicosController : Controller
    {
        // GET: RegistrosPublicos
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewData["Results"] = "false";
            return View();
        }
        [AllowAnonymous]
        public ActionResult Agentes()
        {
            ViewData["Results"] = "true";
            return View();
        }
        [AllowAnonymous]
        public ActionResult Idoneos()
        {
            ViewData["Results"] = "false";
            return View();
        }
        [AllowAnonymous]
        public ActionResult Auditores()
        {
            ViewData["Results"] = "false";
            return View();
        }
        [AllowAnonymous]
        public ActionResult Custodia()
        {
            ViewData["Results"] = "false";
            return View();
        }
        [AllowAnonymous]
        public ActionResult Calificacion()
        {
            ViewData["Results"] = "false";
            return View();
        }
        [AllowAnonymous]
        public ActionResult Mercados()
        {
            ViewData["Results"] = "false";
            return View();
        }
        [AllowAnonymous]
        public ActionResult Mas()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult ResultadosIdoneos(FormCollection data,int pagina=1)
        {
            var client = new RestClient();
            var request = new RestRequest();
            client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            IRestResponse response;
            ListaIdoneos Li = new ListaIdoneos();
            List<Idoneos> I = new List<Models.Idoneos>();
            Li.data = I;
            string filtros="";
            int count = 0;
            if (!String.IsNullOrWhiteSpace(data["nombre"]))
            { filtros = count == 0 ?  filtros+ "nombreyapellido=" + data["nombre"] : filtros + "&nombreyapellido=" + data["nombre"] ; count = count + 1; }
            if (!String.IsNullOrWhiteSpace(data["dni"]))
            { filtros =  count==0 ?  filtros+ "dni=" + data["dni"] : filtros +"&dni="+ data["dni"]; count = count + 1; }
            if (!String.IsNullOrWhiteSpace(data["cuit"]))
            { filtros = count == 0 ? filtros+"cuit=" + data["cuit"] : filtros + "&cuit=" + data["cuit"]; count = count + 1; }
            if (!String.IsNullOrWhiteSpace(data["nombre-registrado"]))
            { filtros = count == 0 ? filtros+ "razonSocial=" + data["nombre-registrado"] : filtros + "&razonSocial=" + data["nombre-registrado"]; count = count + 1; }
            if (!String.IsNullOrWhiteSpace(data["matricula"]))
            { filtros = count == 0 ? filtros+ "matricula=" + data["matricula"] : filtros + "&matricula=" + data["matricula"]; count = count + 1; }
            if (!String.IsNullOrWhiteSpace(data["cuit-registro"]))
            { filtros = count == 0 ? filtros+ "cuit=" + data["cuit-registro"] : filtros + "&cuit=" + data["cuit-registro"]; count = count + 1; }
            
            request = new RestRequest("Idoneos/?" + filtros, Method.GET);

            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                Li = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaIdoneos>(response.Content);

            Session.Add("filtrosIdoneos", filtros);
            Session.Timeout = 180;
            return View(Li);
        }

        [AllowAnonymous]
        public ActionResult ResultadosIdoneos( int pagina = 1)
        {
            var client = new RestClient();
            var request = new RestRequest();
            client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            IRestResponse response;
            ListaIdoneos Li = new ListaIdoneos();
            List<Idoneos> I = new List<Models.Idoneos>();
            Li.data = I;
            string filtros = "";
            filtros= Session["filtrosIdoneos"].ToString();
            pagina = pagina.ToString() == "1" ? 1 : (pagina - 1);
            request = new RestRequest("Idoneos/?" + filtros+ "&skip="+ pagina * 100, Method.GET);

            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                Li = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaIdoneos>(response.Content);

            
            return View(Li);
        }
        [AllowAnonymous]
        public JsonResult AutoCompleteNombre(string term)
        {
            ListaIdoneos Li = new ListaIdoneos();
            List<Idoneos> I = new List<Models.Idoneos>();
            Li.data = I;
            var client = new RestClient();
            var request = new RestRequest();
            client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            IRestResponse response;

            request = new RestRequest("/Idoneos/?nombreyapellido=" + term, Method.GET);

            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
            {
                Li = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaIdoneos>(response.Content);
                I = Li.data ?? new List<Idoneos>();

            }
            var nomb = I.Select(c => new
            {
                c.dni,
                c.nombreApellido

            });


            return Json(nomb, JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        public JsonResult AutoCompleteRazon(string term)
        {
            ListaIdoneos Li = new ListaIdoneos();
            List<Idoneos> I = new List<Models.Idoneos>();
            Li.data = I;
            var client = new RestClient();
            var request = new RestRequest();
            client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            IRestResponse response;

            request = new RestRequest("/Idoneos/?razonSocial=" + term, Method.GET);

            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
            {
                Li = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaIdoneos>(response.Content);
                I = Li.data ?? new List<Idoneos>();

            }
            var nomb = I.Where(x => x.razonSocial!=null).Select(c => new
            {
                c.dni,
                c.razonSocial

            });


            return Json(nomb, JsonRequestBehavior.AllowGet);
        }

    }
}