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
    public class HechosRelevantesController : Controller
    {
        //
        // GET: /HechosRelevantes/
         [AllowAnonymous]
        public ActionResult Index()
        {
            ListaDocumentos Empresas = new ListaDocumentos(), FCI = new ListaDocumentos(), Agentes = new ListaDocumentos();
            var client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            var request = new RestRequest("HechosRelevantesPorTipoEntidad/1/?desde=" + DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd",
       System.Globalization.CultureInfo.CreateSpecificCulture("es-AR"))+ "&limit=6", Method.GET);
            //Empresas
            IRestResponse response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                Empresas = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaDocumentos>(response.Content);

             client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
             request = new RestRequest("HechosRelevantesPorTipoEntidad/3/?desde=" + DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd",
      System.Globalization.CultureInfo.CreateSpecificCulture("es-AR")) + "&limit=6", Method.GET);
            //Fondos Comunes de Inversión
            response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                 FCI = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaDocumentos>(response.Content);

            client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
             request = new RestRequest("HechosRelevantesPorTipoEntidad/2/?desde=" + DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd",
       System.Globalization.CultureInfo.CreateSpecificCulture("es-AR")) + "&limit=6", Method.GET);
            //Agentes
            response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                Agentes = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaDocumentos>(response.Content);

             ViewModelHechosRelevantes VMHR = new ViewModelHechosRelevantes();
             VMHR.Empresas = Empresas;
             VMHR.FCI = FCI;
             VMHR.Agentes = Agentes;
             return View(VMHR);
        }
         [AllowAnonymous]
        public ActionResult Anteriores(int i=0)
        {
            ListaDocumentosHechosR Empresas = new ListaDocumentosHechosR(), FCI = new ListaDocumentosHechosR(), Agentes = new ListaDocumentosHechosR();

            var client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            var request = new RestRequest("HechosRelevantesPorTipoEntidad/1/?desde=" + DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd",
                   System.Globalization.CultureInfo.CreateSpecificCulture("es-AR"))+ "&skip=" + i + "&limit=8" , Method.GET);
            //Empresas
            IRestResponse response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                Empresas = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaDocumentosHechosR>(response.Content);

            client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            request = new RestRequest("HechosRelevantesPorTipoEntidad/3/?desde=" + DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd",
                   System.Globalization.CultureInfo.CreateSpecificCulture("es-AR")) + "&skip=" + i + "&limit=8", Method.GET);
            //Fondos Comunes de Inversión
            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                FCI = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaDocumentosHechosR>(response.Content);

            client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            request = new RestRequest("HechosRelevantesPorTipoEntidad/2/?desde=" + DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd",
                   System.Globalization.CultureInfo.CreateSpecificCulture("es-AR")) + "&skip=" + i + "&limit=8", Method.GET);
            //Agentes
            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                Agentes = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaDocumentosHechosR>(response.Content);

            ViewModelHechosRelevantesBusqueda VMHRB = new ViewModelHechosRelevantesBusqueda();
            VMHRB.Busqueda = new ListaDocumentosHechosR();
            VMHRB.Busqueda.data = Empresas.data;
            VMHRB.Busqueda.totalElementos=Empresas.totalElementos;
            foreach (DocumentosHechosR d in Empresas.data)
            {
                d.Entidadtipo = "EM";

            }
            foreach (DocumentosHechosR d in FCI.data)
            {
                d.Entidadtipo = "FC";
                VMHRB.Busqueda.data.Add(d);

            }
            VMHRB.Busqueda.totalElementos = VMHRB.Busqueda.totalElementos+ FCI.totalElementos;

            foreach (DocumentosHechosR d in Agentes.data)
            {
                d.Entidadtipo = "AG";
                VMHRB.Busqueda.data.Add(d);

            }
            VMHRB.Busqueda.totalElementos = VMHRB.Busqueda.totalElementos + Agentes.totalElementos;

            return View(VMHRB);
        }

    }
}