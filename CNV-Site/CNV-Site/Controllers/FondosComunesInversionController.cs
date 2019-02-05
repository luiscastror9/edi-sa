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
    public class FondosComunesInversionController : Controller
    {
        //
        // GET: /FondosComunesInversion/
        [AllowAnonymous]
        public ActionResult Index()
        {
            var client = new RestClient();
            var request = new RestRequest();
            client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            IRestResponse response;
            ListaUltimaColocacionesInstrumentos Lfci = new ListaUltimaColocacionesInstrumentos();
            ListaUltimaColocacionesInstrumentos LfciA = new ListaUltimaColocacionesInstrumentos();
            List<DocUltimaColocacionesInstrumentos> dfci = new List<DocUltimaColocacionesInstrumentos>();
            ListaSociedadesGerentes Lsg = new ListaSociedadesGerentes();
            ListaSociedadesGerentes Lti = new ListaSociedadesGerentes();
            ListaSociedadesGerentes Lsd = new ListaSociedadesGerentes();

            ViewModelFondoComunesInversion vmFCI = new ViewModelFondoComunesInversion();
            Lfci.data = new List<UltimaColocacionesInstrumentos>();
            LfciA.data = new List<UltimaColocacionesInstrumentos>(); 
            Lsg.data =  new List<SociedadesGerentes>();
            Lti.data = new List<SociedadesGerentes>();
            Lsd.data = new List<SociedadesGerentes>();

            request = new RestRequest("/Instrumentos/FCI/BuscaFondosComunes?tipoId=1&limit=3", Method.GET);
            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                Lfci = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaUltimaColocacionesInstrumentos>(response.Content);
            request = new RestRequest("/Instrumentos/FCI/BuscaFondosComunes?tipoId=2&limit=3", Method.GET);
            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                LfciA = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaUltimaColocacionesInstrumentos>(response.Content);

            request = new RestRequest("/Instrumentos/FCI/ListaSociedadesGerentes/", Method.GET);
            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                Lsg = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaSociedadesGerentes>(response.Content);

            request = new RestRequest("/Instrumentos/FCI/ListaTiposInversion/", Method.GET);
            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                Lti = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaSociedadesGerentes>(response.Content);

            request = new RestRequest("/Instrumentos/FCI/ListaSociedadesDepositarias/", Method.GET);
            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                Lsd = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaSociedadesGerentes>(response.Content);



            vmFCI.LUCIC = Lfci;
            vmFCI.LUCIA = LfciA;
            vmFCI.Lsg = Lsg;
            vmFCI.Lti = Lti;
            vmFCI.Lsd = Lsd;

            return View(vmFCI);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Busqueda(FormCollection data)
        {
            var client = new RestClient();
            var request = new RestRequest();
            client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            IRestResponse response;
            ListaUltimaColocacionesInstrumentos Lfci = new ListaUltimaColocacionesInstrumentos();
            ListaUltimaColocacionesInstrumentos LfciA = new ListaUltimaColocacionesInstrumentos();
            List<DocUltimaColocacionesInstrumentos> dfci = new List<DocUltimaColocacionesInstrumentos>();
            ListaSociedadesGerentes Lsg = new ListaSociedadesGerentes();
            ListaSociedadesGerentes Lti = new ListaSociedadesGerentes();
            ListaSociedadesGerentes Lsd = new ListaSociedadesGerentes();
            string sg = "", ti = "", sd = "",tp="";
            tp = data["tipo"] == "" ? "" : "&tipoId=" + data["tipo"];
            sg = data["Lsg"]==""?"": "&idSocGerente="+data["Lsg"];
            sd = data["Lsd"] == "" ? "" : "&codSociedadDepositaria=" + data["Lsd"];
            ti = data["Lti"] == "" ? "" : "&idTipoInversion=" + data["Lti"];
            ViewModelFondoComunesInversion vmFCI = new ViewModelFondoComunesInversion();
            Lfci.data = new List<UltimaColocacionesInstrumentos>();
            LfciA.data = new List<UltimaColocacionesInstrumentos>();
            Lsg.data = new List<SociedadesGerentes>();
            Lti.data = new List<SociedadesGerentes>();
            Lsd.data = new List<SociedadesGerentes>();
            string q = sg + sd + ti+ tp; 
            request = new RestRequest("/Instrumentos/FCI/BuscaFondosComunes?desde=" + DateTime.Today.AddMonths(-12).ToShortDateString() + q, Method.GET);
            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                Lfci = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaUltimaColocacionesInstrumentos>(response.Content);
            Session.Add("filtrosfci", q);
            Session.Timeout = 180;


            request = new RestRequest("/Instrumentos/FCI/ListaSociedadesGerentes/", Method.GET);
            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                Lsg = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaSociedadesGerentes>(response.Content);

            request = new RestRequest("/Instrumentos/FCI/ListaTiposInversion/", Method.GET);
            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                Lti = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaSociedadesGerentes>(response.Content);

            request = new RestRequest("/Instrumentos/FCI/ListaSociedadesDepositarias/", Method.GET);
            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                Lsd = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaSociedadesGerentes>(response.Content);



            vmFCI.LUCIC = Lfci;
           // vmFCI.LUCIA = LfciA;
            vmFCI.Lsg = Lsg;
            vmFCI.Lti = Lti;
            vmFCI.Lsd = Lsd;

            return View(vmFCI);
        }
        [AllowAnonymous]
        public ActionResult Busqueda(int pagina = 1)
        {
            var client = new RestClient();
            var request = new RestRequest();
            client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            IRestResponse response;
            string filtros = "";
            ListaUltimaColocacionesInstrumentos Lfci = new ListaUltimaColocacionesInstrumentos();
            ListaUltimaColocacionesInstrumentos LfciA = new ListaUltimaColocacionesInstrumentos();
            List<DocUltimaColocacionesInstrumentos> dfci = new List<DocUltimaColocacionesInstrumentos>();
            ListaSociedadesGerentes Lsg = new ListaSociedadesGerentes();
            ListaSociedadesGerentes Lti = new ListaSociedadesGerentes();
            ListaSociedadesGerentes Lsd = new ListaSociedadesGerentes();
            ViewModelFondoComunesInversion vmFCI = new ViewModelFondoComunesInversion();
            Lfci.data = new List<UltimaColocacionesInstrumentos>();
            LfciA.data = new List<UltimaColocacionesInstrumentos>();
            Lsg.data = new List<SociedadesGerentes>();
            Lti.data = new List<SociedadesGerentes>();
            Lsd.data = new List<SociedadesGerentes>();
            filtros = Session["filtrosfci"].ToString();
            pagina=pagina.ToString() == "1" ? 1 : (pagina - 1);
            request = new RestRequest("/Instrumentos/FCI/BuscaFondosComunes?desde=" + DateTime.Today.AddMonths(-12).ToShortDateString() + filtros + "&skip=" + pagina * 100, Method.GET);
            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                Lfci = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaUltimaColocacionesInstrumentos>(response.Content);

            request = new RestRequest("/Instrumentos/FCI/ListaSociedadesGerentes/", Method.GET);
            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                Lsg = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaSociedadesGerentes>(response.Content);

            request = new RestRequest("/Instrumentos/FCI/ListaTiposInversion/", Method.GET);
            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                Lti = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaSociedadesGerentes>(response.Content);

            request = new RestRequest("/Instrumentos/FCI/ListaSociedadesDepositarias/", Method.GET);
            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                Lsd = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaSociedadesGerentes>(response.Content);



            vmFCI.LUCIC = Lfci;
            // vmFCI.LUCIA = LfciA;
            vmFCI.Lsg = Lsg;
            vmFCI.Lti = Lti;
            vmFCI.Lsd = Lsd;

            return View(vmFCI);

           
        }
    }
}