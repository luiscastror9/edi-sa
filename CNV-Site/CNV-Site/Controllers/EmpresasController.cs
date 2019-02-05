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
    public class EmpresasController : Controller
    {
        public Credentials s= new Credentials();
        public string fechadesde = "", fechahasta = "";
        // GET: Empresas
        public ActionResult Index()
        {
            ViewData["Results"] = false;
            var client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            var request = new RestRequest("/HechosRelevantesPorTipoEntidad/1/?desde=" + DateTime.Today.AddMonths(-12).ToShortDateString() + "&limit=5", Method.GET);
            ListaDocumentos DOCSHR = new ListaDocumentos();
            ListaUltimaColocacionesInstrumentos LFCI = new ListaUltimaColocacionesInstrumentos();

            IRestResponse response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                DOCSHR = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaDocumentos>(response.Content);
            ViewModelEmpresas Vhome = new ViewModelEmpresas();
            Vhome.DOCSUN = DOCSHR.data == null ? new List<Documentos>() : DOCSHR.data;
            Vhome.LlE = new List<EmpresasB>();
            Vhome.Lfci = new ListaUltimaColocacionesInstrumentos();
            request = new RestRequest("/Instrumentos/FCI/UltimasColocaciones?desde=" + DateTime.Today.AddMonths(-12).ToShortDateString() + "&limit=3", Method.GET);
            response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                LFCI = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaUltimaColocacionesInstrumentos>(response.Content);
            Vhome.Lfci = LFCI;
            return View(Vhome);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(FormCollection data)
        {
            // do populate model
            var client = new RestClient();
            var request = new RestRequest();
            client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            IRestResponse response;
            if (User.Identity.IsAuthenticated) { 
            request = new RestRequest("/token", Method.POST);
                request.AddParameter("grant_type", "password");
                request.AddParameter("username", "pepe");
                request.AddParameter("PASSWORD", "123");
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
            response = client.Execute(request);

             s = Newtonsoft.Json.JsonConvert.DeserializeObject<Credentials>(response.Content);
            }
            string nombreempresa = "", todosdocumentos = "", ultimadocumentos = "", actasorganosdocumentos = "", hechosrelevantesdocumentos = "", codigogobiernodocumentos = "", infofinancieradocumentos = "", infopublicodocumentos = "", infosocietariadocumentos = "", emisionesdocumentos = "",  documentosid = ""; 

            ViewData["Results"] = "true";


            nombreempresa = data["nombreempresa"] ?? "";

            todosdocumentos = data["todosdocumentos"] ?? "";
            ultimadocumentos = data["ultimadocumentos"] ?? "";

            actasorganosdocumentos = data["actasorganosdocumentos"] ?? "";
            hechosrelevantesdocumentos = data["hechosrelevantesdocumentos"] ?? "";
            codigogobiernodocumentos = data["codigogobiernodocumentos"] ?? "";
            infofinancieradocumentos = data["infofinancieradocumentos"] ?? "";
            infopublicodocumentos = data["infopublicodocumentos"] ?? "";
            infosocietariadocumentos = data["infosocietariadocumentos"] ?? "";
            emisionesdocumentos = data["emisionesdocumentos"] ?? "";

            fechadesde = data["desde"] ?? "";
            fechahasta = data["hasta"] ?? "";
            ListaEntidades ListaNombre = new ListaEntidades();
            ListaNombre.data = new List<Entidades>();
            if (!String.IsNullOrEmpty(nombreempresa))
            {
                request = new RestRequest("/entidadespornombre/1/" + nombreempresa.Replace("S.A.",""), Method.GET);
              
                response = client.Execute(request);
                if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                    ListaNombre = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaEntidades>(response.Content);

                if (ListaNombre.data.Count > 5)
                {
                    TempData["msg"] = "<script>alert('por favor coloque un criterio de nombre mas especifico');</script>";
                    return RedirectToAction("Index");
                }
                else { 

                string entidadid = string.Join("&entidadid=", ListaNombre.data.Select(i => i.id));
                entidadid = ListaNombre.data.Count == 1 ? "&entidadid=" + entidadid :entidadid ;
                    }
            }
            List<ListaEstructuraDocumentos> LlE = new List<Models.ListaEstructuraDocumentos>();
            ListaEstructuraDocumentos ListaEstructuras = new ListaEstructuraDocumentos();


            request = new RestRequest("/estructuraportipoentidad/1?idPadre=0", Method.GET);
            if (User.Identity.IsAuthenticated)
                request.AddHeader("Authorization", "bearer " + s.access_token);
            response = client.Execute(request);
            ListaEstructuraDocumentos ListaEstructurasTD = new ListaEstructuraDocumentos();
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                ListaEstructuras = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaEstructuraDocumentos>(response.Content);

            List<EstructuraDocumentos> eSsD = new List<EstructuraDocumentos>();
            List<EstructuraDocumentos> eSsD2 = new List<EstructuraDocumentos>();
            List<EstructuraDocumentos> eSsD3 = new List<EstructuraDocumentos>();

            List<ListaDocumentos> LlD = new List<ListaDocumentos>();
            List<EmpresasB> v = new List<EmpresasB>();

            foreach (Entidades e in ListaNombre.data) {
                // Se agregan todos los tipos de documentos de las estructuras
               
                if (todosdocumentos != "") { 
                
                }
                else
                {
                    if (ultimadocumentos != "")
                {
                 documentosid = documentosid+"&tipoDocumentoId=3";
                }
                if (hechosrelevantesdocumentos != "")
                {
                     documentosid = documentosid + "&tipoDocumentoId=4";
                    }
                if (infosocietariadocumentos != "")
                {
                   
                        documentosid = documentosid + "&tipoDocumentoId=5";
                    }
                if (infofinancieradocumentos != "")
                {
                       documentosid = documentosid + "&tipoDocumentoId=6";
                    }
                if (emisionesdocumentos != "")
                {
                         documentosid = documentosid + "&tipoDocumentoId=7";
                    }
                if (actasorganosdocumentos != "")
                {
                      documentosid = documentosid + "&tipoDocumentoId=8";
                    }            
                if (codigogobiernodocumentos != "")
                {
                    documentosid = documentosid + "&tipoDocumentoId=9";
                    }               
                if (infopublicodocumentos != "")
                {
                  documentosid = documentosid + "&tipoDocumentoId=10";
                    }

                }

         ListaDocumentos lD = new ListaDocumentos();
          
              lD =  GetEstructuraDocumentos(documentosid, e.id);
                var d = lD.data.GroupBy(x => x.idPadre);
                foreach (IGrouping<int,Documentos> r in d)
                {
                    EmpresasB Eb = new EmpresasB();
                    Eb.DOCXTIPO = new List<Documentos>();
                   
                    Eb.entidadId = e.id;
                    Eb.entidadDescripcion = e.descripcion;
                   
                    foreach(Documentos dd in r){
                        Eb.tipoDocumento = dd.tipoDocumento;
                        Eb.idDocumento = dd.id;
                        Eb.idPadre = dd.idPadre;
                        Eb.DOCXTIPO.Add(dd);
                    }
                   
                    
                v.Add(Eb);
                }
                ListaEstructuras.entidadDescripcion = e.descripcion;
                ListaEstructuras.entidadid = e.id;
                foreach (EstructuraDocumentos eS in ListaEstructuras.data)
                {
                    // eS.ListaDocs = v.Where(x => x.idPadre == eS.id).FirstOrDefault();
                    foreach (EstructuraDocumentos eSs in eS.hijos)
                    {
                        if(eSs.hijos.Count()==0 &&  eSs.ListaDocs==null)
                        {
                            eSsD.Add(eSs);
                        }else if(eSs.hijos.Count() == 0 && eSs.ListaDocs.data.Count() == 0)
                        {
                            eSsD.Add(eSs);
                        }
                        //else { 
                        ListaEstructuraDocumentos(v, eSs, eSs.id);
                       // }
                        eSsD.RemoveAll(x => x.ListaDocs.data.Count()>0);
                        eSsD.RemoveAll(x => x.hijos.Count() > 0);
                    }
                }
                LlE.Add(ListaEstructuras);
            }


            foreach (EstructuraDocumentos eS in eSsD)
            {
                foreach (ListaEstructuraDocumentos eSe in LlE)
                {

                    foreach (EstructuraDocumentos eSee in eSe.data)
                    {
                        //eSee.hijos.Remove(eS);
                        foreach (EstructuraDocumentos eSeee in eSee.hijos)
                        {
                            if (eSeee.hijos.Count() == 0 && eSeee.ListaDocs == null)
                            {
                                eSsD2.Add(eSeee);
                            }
                            else if (eSeee.hijos.Count() == 0 && eSeee.ListaDocs.data.Count() == 0)
                            {
                                eSsD2.Add(eSeee);
                            }

                            foreach (EstructuraDocumentos eSeeer in eSeee.hijos)
                            {
                                if (eSeeer.hijos.Count() == 0 && eSeeer.ListaDocs == null)
                                {
                                    eSsD3.Add(eSeeer);
                                }
                                else if (eSeeer.hijos.Count() == 0 && eSeeer.ListaDocs.data.Count() == 0)
                                {
                                    eSsD3.Add(eSeeer);
                                }
                            }
                        }

                    }
                }

            }

            foreach (ListaEstructuraDocumentos eSe in LlE)
                {
                eSe.data.RemoveAll(x => x.hijos.Count() == 0 && x.ListaDocs.data.Count() == 0 || x.hijos.Count() == 0 && x.ListaDocs == null);
                ListaEstructuraDelete(eSe);
                }

            foreach (ListaEstructuraDocumentos eSe in LlE)
            {
                
                foreach (EstructuraDocumentos eSee in eSe.data)
                {
                    eSee.hijos.RemoveAll(x => x.hijos.Count() == 0 && x.ListaDocs.data.Count() == 0 || x.hijos.Count() == 0 && x.ListaDocs == null);
                    foreach (EstructuraDocumentos r in eSee.hijos)
                    {
                        r.hijos.RemoveAll(x => x.hijos.Count() == 0 && x.ListaDocs.data.Count() == 0 || x.hijos.Count() == 0 && x.ListaDocs == null);
                        foreach (EstructuraDocumentos d in r.hijos)
                        {
                            d.hijos.RemoveAll(x => x.hijos.Count() == 0 && x.ListaDocs.data.Count() == 0 || x.hijos.Count() == 0 && x.ListaDocs == null);
                        }
                    }
                }
            }

                    request = new RestRequest("/HechosRelevantesPorTipoEntidad/1/?desde=" + DateTime.Today.AddMonths(-12).ToShortDateString() + "&limit=5", Method.GET);
            ListaDocumentos DOCSHR = new ListaDocumentos();


            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                DOCSHR = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaDocumentos>(response.Content);
            ViewModelEmpresas Vhome = new ViewModelEmpresas();
            Vhome.DOCSUN = DOCSHR.data == null ? new List<Documentos>() : DOCSHR.data;
            ListaUltimaColocacionesInstrumentos LFCI = new ListaUltimaColocacionesInstrumentos();

            Vhome.LlE = v ?? new List<EmpresasB>();
            Vhome.leD = LlE ?? new List<Models.ListaEstructuraDocumentos>();
            Vhome.Lfci = new ListaUltimaColocacionesInstrumentos();
            request = new RestRequest("/Instrumentos/FCI/UltimasColocaciones?desde=" + DateTime.Today.AddMonths(-12).ToShortDateString() + "&limit=3", Method.GET);
            response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                LFCI = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaUltimaColocacionesInstrumentos>(response.Content);
            Vhome.Lfci = LFCI;


            return View(Vhome);
        }



        public JsonResult AutoComplete(string term)
        {
            ListaEntidades ListaNombre = new ListaEntidades();
            List<Entidades> data = new List<Entidades>();
            var client = new RestClient();
            var request = new RestRequest();
            client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            IRestResponse response;

            request = new RestRequest("/entidadespornombre/1/" + term, Method.GET);

            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
            {
                ListaNombre = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaEntidades>(response.Content);
                data = ListaNombre.data ?? new List<Entidades>();

            }
            var nomb = data.Select(c => new
            {
                c.id,c.descripcion

            });
           

            return Json( nomb, JsonRequestBehavior.AllowGet);
        }
        // Recursivo para recorrer TODAS las estructuras
        public EstructuraDocumentos ListaEstructuraDocumentos(List<EmpresasB> v,EstructuraDocumentos lEd, int entidadid)
        {
            lEd.ListaDocs = new ListaDocumentos();
            lEd.ListaDocs.data = new List<Documentos>();
            lEd.ListaDocs.data = v.Where(x => x.idPadre == entidadid).FirstOrDefault() != null ? v.Where(x => x.idPadre == entidadid).FirstOrDefault().DOCXTIPO : new List<Documentos>();
            
            foreach (EstructuraDocumentos eS in lEd.hijos)
            {
                eS.ListaDocs = new ListaDocumentos();
                eS.ListaDocs.data = new List<Documentos>();
                eS.ListaDocs.data = v.Where(x => x.idPadre == eS.id).FirstOrDefault() != null ? v.Where(x => x.idPadre == eS.id).FirstOrDefault().DOCXTIPO : new List<Documentos>();

               
                foreach (EstructuraDocumentos eSw in eS.hijos)
                {
                    eSw.ListaDocs = new ListaDocumentos();
                    eSw.ListaDocs.data = new List<Documentos>();
                    eSw.ListaDocs.data = v.Where(x => x.idPadre == eSw.id).FirstOrDefault() != null ? v.Where(x => x.idPadre == eSw.id).FirstOrDefault().DOCXTIPO : new List<Documentos>();

                    foreach (EstructuraDocumentos eSww in eSw.hijos)
                    {
                        eSww.ListaDocs = new ListaDocumentos();
                        eSww.ListaDocs.data = new List<Documentos>();
                        eSww.ListaDocs.data = v.Where(x => x.idPadre == eSww.id).FirstOrDefault() != null ? v.Where(x => x.idPadre == eSww.id).FirstOrDefault().DOCXTIPO : new List<Documentos>();

                    }
                }
            }

            return lEd;
        }
        // Obtiene los documentos por tipo de Entidad
        public ListaDocumentos GetEstructuraDocumentos(string eS,int entidadid)
        {
            var client = new RestClient();
            var request = new RestRequest();
            client = new RestClient(ConfigurationManager.AppSettings["UrlAPI"]);
            IRestResponse response;
            string fdesde = fechadesde != "" ? Convert.ToDateTime(fechadesde).ToString("MM-dd-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("es-AR")) : Convert.ToDateTime(DateTime.Today.AddMonths(-12).ToShortDateString()).ToString("MM-dd-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("es-AR"));
            string fhasta = fechahasta != "" ? "&hasta=" + Convert.ToDateTime(fechahasta).ToString("MM-dd-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("es-AR")) : "";
            
            request = new RestRequest("/documentosportipoentidad/1/?desde=" + fdesde + fhasta  +eS   + "&entidadid=" + entidadid, Method.GET);
            if (User.Identity.IsAuthenticated)
                request.AddHeader("Authorization", "bearer " + s.access_token);

            ListaDocumentos DOCSHR = new ListaDocumentos();
            response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                DOCSHR = Newtonsoft.Json.JsonConvert.DeserializeObject<ListaDocumentos>(response.Content);
             return DOCSHR;
        }

        public ListaEstructuraDocumentos ListaEstructuraDelete(ListaEstructuraDocumentos lEd)
        {
            foreach (EstructuraDocumentos eSee in lEd.data)
            {
                eSee.hijos.RemoveAll(x => x.hijos.Count() == 0 && x.ListaDocs.data.Count() == 0 || x.hijos.Count() == 0 && x.ListaDocs == null);

                foreach (EstructuraDocumentos eSeer in eSee.hijos)
                {
                    eSeer.hijos.RemoveAll(x => x.hijos.Count() == 0 && x.ListaDocs.data.Count() == 0 || x.hijos.Count() == 0 && x.ListaDocs == null);

                    foreach (EstructuraDocumentos eSeere in eSeer.hijos)
                    {
                        eSeere.hijos.RemoveAll(x => x.hijos.Count() == 0 && x.ListaDocs.data.Count() == 0 || x.hijos.Count() == 0 && x.ListaDocs == null);
                        foreach (EstructuraDocumentos eSeeret in eSeere.hijos)
                        {
                            eSeeret.hijos.RemoveAll(x => x.hijos.Count() == 0 && x.ListaDocs.data.Count() == 0 || x.hijos.Count() == 0 && x.ListaDocs == null);
                            foreach (EstructuraDocumentos eSeerete in eSeeret.hijos)
                            {
                                eSeerete.hijos.RemoveAll(x => x.hijos.Count() == 0 && x.ListaDocs.data.Count() == 0 || x.hijos.Count() == 0 && x.ListaDocs == null);

                            }
                        }
                    }
                }
            }
            return lEd;
        }
    }
}
