using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public class ViewModelFondoComunesInversion
    {
      public ListaUltimaColocacionesInstrumentos LUCIC { get; set; }
        public ListaUltimaColocacionesInstrumentos LUCIA { get; set; }
        public ListaSociedadesGerentes Lsg { get; set; }
        public ListaSociedadesGerentes Lti { get; set; }
        public ListaSociedadesGerentes Lsd { get; set; }

    }
}