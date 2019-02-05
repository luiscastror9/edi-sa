using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public class Instrumentos
    {
        public int id { get; set; }
        public string denominacion { get; set; }
        public int tipoId { get; set; }
        public object tipo { get; set; }
        public DateTime fechaLanzamiento { get; set; }
        public object objetoInversion { get; set; }
        public int codSociedadGerente { get; set; }
        public string sociedadGerente { get; set; }
        public int codSociedadDepositaria { get; set; }
        public string sociedadDepositaria { get; set; }
        public List<object> documentos { get; set; }
    }
}