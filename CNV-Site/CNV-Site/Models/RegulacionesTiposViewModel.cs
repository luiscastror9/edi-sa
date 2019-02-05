using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public  class RegulacionesTiposViewModel
    {
        public string title { get; set; }
        public string prefijocombinado { get; set; }
        public  TiposRegulacion TipoRegulacion { get; set; }
       public List<Regulaciones> Regulaciones { get; set; }

    }
}