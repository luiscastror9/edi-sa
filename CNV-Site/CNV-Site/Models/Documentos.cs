using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public class Documentos
    {
        public int id { get; set; }
        public int idPadre { get; set; }
        public DateTime fecha { get; set; }
        public string tipoDocumento { get; set; }
        public int entidadId { get; set; }
        public string entidadDescripcion { get; set; }
        public string link { get; set; }
    }
}