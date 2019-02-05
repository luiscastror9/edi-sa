using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public class ListaRegulaciones
    {
        public int totalElementos { get; set; }
        public List<Regulaciones> data { get; set; }
    }

}