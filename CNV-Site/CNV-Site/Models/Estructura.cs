using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public class Estructura
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public List<Estructura> hijos { get; set; }
    }
}