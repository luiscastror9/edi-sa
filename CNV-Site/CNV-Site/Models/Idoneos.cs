using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public class Idoneos
    {
        public string cuit { get; set; }
        public string dni { get; set; }
        public int matricula { get; set; }
        public string nombreApellido { get; set; }
        public string estado { get; set; }
        public object razonSocial { get; set; }
        public string categoria { get; set; }
        public string domicilioElectronico { get; set; }
    }
}