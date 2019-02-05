using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public class ViewModelHechosRelevantes
    {
        public ListaDocumentos Empresas { get; set; }
        public ListaDocumentos FCI { get; set; }
        public ListaDocumentos Agentes { get; set; }

    }
}