using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{

   
    public class Regulaciones
    {
       

        public int tipoId { get; set; }
        public string numero { get; set; }
        public string prefijo { get; set; }
        public object titulo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public object fecha { get; set; }

        public List<Links> links { get; set; }
        public List<Regulaciones> anexos { get; set; }
    }
}