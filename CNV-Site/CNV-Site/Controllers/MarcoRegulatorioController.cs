using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNV_Site.Models;
namespace CNV_Site.Controllers
{
    public class MarcoRegulatorioController : Controller
    {
    
        // GET: MarcoRegulatorio
         [AllowAnonymous]
        public ActionResult Index()
        {
            var client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            var request = new RestRequest("/TiposRegulacion", Method.GET);

            IRestResponse response = client.Execute(request);
            ListaTiposRegulacion TR = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaTiposRegulacion>(response.Content);

            request = new RestRequest("/Regulaciones", Method.GET);

            response = client.Execute(request);
            var R = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaRegulaciones>(response.Content);

            List<RegulacionesTiposViewModel> LRTVW = new List<RegulacionesTiposViewModel>();
            

            foreach (TiposRegulacion tr in TR.data)
            {
                RegulacionesTiposViewModel RTVW = new RegulacionesTiposViewModel();
                RTVW.TipoRegulacion = tr;
                RTVW.Regulaciones = R.data.Where(z => z.prefijo == tr.prefijo).ToList();
                
                LRTVW.Add(RTVW);
            }

          

            return View(LRTVW);
        }
    }
}