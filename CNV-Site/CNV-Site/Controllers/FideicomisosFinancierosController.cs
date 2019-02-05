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
    public class FideicomisosFinancierosController : Controller
    {
        // GET: FideicomisosFinancieros
        [AllowAnonymous]
        public ActionResult Index()
        {

            var client = new RestClient();
            var request = new RestRequest();
            client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            IRestResponse response;

            ListaUtimasColocacionesFideicomisosFinancieros UCFF = new ListaUtimasColocacionesFideicomisosFinancieros();
            request = new RestRequest("/Instrumentos/FF/UltimasColocaciones/", Method.GET);
            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                UCFF = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaUtimasColocacionesFideicomisosFinancieros>(response.Content);
            ViewModelFideicomisosFinancieros VMFF = new ViewModelFideicomisosFinancieros();
            VMFF.UCFF = UCFF.data.Take(3).ToList();

            return View(VMFF);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Busqueda(FormCollection data)
        {
            var client = new RestClient();
            var request = new RestRequest();
            ListaFFLD listaFiduciario = new ListaFFLD();
            ListaFFLF listaprograma = new ListaFFLF();
            ListaFFLF listadenominacion = new ListaFFLF();
            client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            IRestResponse response;


         
            
                if (data["denominacionFF"]!=""){
                request = new RestRequest("Instrumentos/FF/BuscaFideicomisos/" + data["denominacionFF"], Method.GET);
                response = client.Execute(request);
                if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                    listadenominacion = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaFFLF>(response.Content);
                Session.Add("denominacion", listadenominacion.data[0].id);
                return RedirectToAction("Fideicomiso");
            }else if (data["programaFF"] != "")
            {
                request = new RestRequest("Instrumentos/FF/BuscaProgramas/" + data["programaFF"], Method.GET);
                response = client.Execute(request);
                if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                    listaprograma = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaFFLF>(response.Content);
                Session.Add("programa", listaprograma.data[0].id);
                return RedirectToAction("Programa");
            }
            else if (data["fiduciarioFF"] != "")
            {
                request = new RestRequest("Instrumentos/FF/BuscaFiduciarios/" + data["fiduciarioFF"], Method.GET);
                response = client.Execute(request);
                if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                    listaFiduciario = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaFFLD>(response.Content);
                Session.Add("fiduciario", listaFiduciario.data[0].id);
                return RedirectToAction("Fiduciario");
            }else
                return View();
          



        }


        [AllowAnonymous]
        public JsonResult AutoCompletedenominacion(string term)
        {
            ListaFFLF Listadenominacion = new ListaFFLF();
            List<FFLF> data = new List<FFLF>();
            var client = new RestClient();
            var request = new RestRequest();
            client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            IRestResponse response;

            request = new RestRequest("Instrumentos/FF/BuscaFideicomisos/" + term, Method.GET);

            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
            {
                Listadenominacion = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaFFLF>(response.Content);
                data = Listadenominacion.data ?? new List<FFLF>();

            }
            var nomb = data.Select(c => new
            {
                c.id,
                c.denominacion

            }).Take(100);


            return Json(nomb, JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        public JsonResult AutoCompleteprograma(string term)
        {
            ListaFFLF Listaprograma = new ListaFFLF();
            List<FFLF> data = new List<FFLF>();
            var client = new RestClient();
            var request = new RestRequest();
            client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            IRestResponse response;

            request = new RestRequest("Instrumentos/FF/BuscaProgramas/" + term, Method.GET);

            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
            {
                Listaprograma = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaFFLF>(response.Content);
                data = Listaprograma.data ?? new List<FFLF>();

            }
            var nomb = data.Select(c => new
            {
                c.id,
                c.denominacion

            }).Take(100);


            return Json(nomb, JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        public JsonResult AutoCompletefiduciario(string term)
        {
            ListaFFLD Listafiduciario = new ListaFFLD();
            List<FFLD> data = new List<FFLD>();
            var client = new RestClient();
            var request = new RestRequest();
            client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            IRestResponse response;

            request = new RestRequest("Instrumentos/FF/BuscaFiduciarios/" + term, Method.GET);

            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
            {
                Listafiduciario = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaFFLD>(response.Content);
                data = Listafiduciario.data ?? new List<FFLD>();

            }
            var nomb = data.Select(c => new
            {
                c.id,
                c.descripcion

            }).Take(100);


            return Json(nomb, JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        public ActionResult Programa()
        {

           string programas = Session["programa"].ToString();
            var client = new RestClient();
            var request = new RestRequest();
            client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            IRestResponse response;

            ListaUtimasColocacionesFideicomisosFinancieros UCFF = new ListaUtimasColocacionesFideicomisosFinancieros();
            request = new RestRequest("/Instrumentos/FF/UltimasColocaciones/", Method.GET);
            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                UCFF = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaUtimasColocacionesFideicomisosFinancieros>(response.Content);
            ViewModelFideicomisosFinancieros VMFF = new ViewModelFideicomisosFinancieros();
            VMFF.UCFF = new List<UltimasColocacionesFideicomisosFinancieros>();
            VMFF.UCFF = UCFF.data.Take(3).ToList();
            VMFF.FFF = new List<FideicomisosFF>();
            ListaFideicomisosFF LFFF = new ListaFideicomisosFF();
            request = new RestRequest("/Instrumentos/FF/FideicomisoData/" + programas, Method.GET);
            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                LFFF = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaFideicomisosFF>(response.Content);

            VMFF.FFF.Add(LFFF.data);


            return View(VMFF);
        }
        [AllowAnonymous]
        public ActionResult Fideicomiso()
        {
            string fideicomisos = Session["denominacion"].ToString();
            var client = new RestClient();
            var request = new RestRequest();
            client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            IRestResponse response;

            ListaUtimasColocacionesFideicomisosFinancieros UCFF = new ListaUtimasColocacionesFideicomisosFinancieros();
            request = new RestRequest("/Instrumentos/FF/UltimasColocaciones/", Method.GET);
            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                UCFF = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaUtimasColocacionesFideicomisosFinancieros>(response.Content);
            ViewModelFideicomisosFinancieros VMFF = new ViewModelFideicomisosFinancieros();
            VMFF.UCFF = new List<UltimasColocacionesFideicomisosFinancieros>();
            VMFF.UCFF = UCFF.data.Take(3).ToList();
            VMFF.FFF = new List<FideicomisosFF>();
            ListaFideicomisosFF LFFF = new ListaFideicomisosFF();
            LFFF.data = new FideicomisosFF();
            request = new RestRequest("/Instrumentos/FF/FideicomisoData/"+ fideicomisos, Method.GET);
            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
               LFFF = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaFideicomisosFF>(response.Content);

            VMFF.FFF.Add(LFFF.data);


            return View(VMFF);
        }
        [AllowAnonymous]
        public ActionResult Fiduciario()
        {

            string fiduciario = Session["fiduciario"].ToString();
            var client = new RestClient();
            var request = new RestRequest();
            client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            IRestResponse response;

            ListaUtimasColocacionesFideicomisosFinancieros UCFF = new ListaUtimasColocacionesFideicomisosFinancieros();
            request = new RestRequest("/Instrumentos/FF/UltimasColocaciones/", Method.GET);
            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                UCFF = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaUtimasColocacionesFideicomisosFinancieros>(response.Content);
            ViewModelFideicomisosFinancieros VMFF = new ViewModelFideicomisosFinancieros();
            VMFF.UCFF = new List<UltimasColocacionesFideicomisosFinancieros>();
            VMFF.UCFF = UCFF.data.Take(3).ToList();
            VMFF.FFF2 = new List<FiduciariosFF>() ;
            ListaFiduciariosFF LFFF = new ListaFiduciariosFF();
            request = new RestRequest("/Instrumentos/FF/FiduciarioData/" + fiduciario, Method.GET);
            response = client.Execute(request);
          

            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                LFFF = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaFiduciariosFF>(response.Content);
            
            VMFF.FFF2.Add(LFFF.data);


            return View(VMFF);
        }
    }
}