using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public class ViewModelEmpresas
    {
        public List<Documentos> DOCSUN { get; set; }
        public List<EmpresasB> LlE { get; set; }
        public List<ListaEstructuraDocumentos> leD { get; set; }
        public ListaUltimaColocacionesInstrumentos Lfci { get; set; }
    }
}