using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public class EstructuraDocumentos
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public List<EstructuraDocumentos> hijos { get; set; }
        public ListaDocumentos ListaDocs { get; set; }

    }
}