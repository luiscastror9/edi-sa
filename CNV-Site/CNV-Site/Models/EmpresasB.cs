using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public class EmpresasB
    {
       
        public int entidadId { get; set; }
        public string entidadDescripcion { get; set; }
        public int idPadre { get; set; }
        public int idDocumento { get; set; }
        public string tipoDocumento { get; set; }
        public List<Documentos> DOCXTIPO { get; set; }
    }
}