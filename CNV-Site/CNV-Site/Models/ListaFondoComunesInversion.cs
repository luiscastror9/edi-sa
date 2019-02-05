using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public class ListaFondoComunesInversion
    {
        public int totalElementos { get; set; }
        public int desde { get; set; }
        public int hasta { get; set; }
        public List<FondoComunesInversion> data { get; set; }
    }
}