using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public class ListaSociedadesGerentes
    {
        public int totalElementos { get; set; }
        public List<SociedadesGerentes> data { get; set; }
    }
}