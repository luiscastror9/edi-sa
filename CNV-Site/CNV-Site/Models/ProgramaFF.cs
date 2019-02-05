using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public class ProgramaFF
    {
        public int id { get; set; }
        public object denominacion { get; set; }
        public List<SeriesFF> series { get; set; }
        public List<DocumentoFF> documentos { get; set; }
    }
}