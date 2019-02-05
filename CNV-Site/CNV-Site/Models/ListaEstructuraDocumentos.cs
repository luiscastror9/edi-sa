using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public class ListaEstructuraDocumentos
    {
        public int entidadid { get; set; }
        public string entidadDescripcion { get; set; }
        public int totalElementos { get; set; }
        public List<EstructuraDocumentos> data { get; set; }
    }
}