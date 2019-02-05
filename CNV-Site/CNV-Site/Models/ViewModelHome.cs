using CNV_Site.Areas.BackOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public class ViewModelHome
    {
        public List<Areas.BackOffice.Models.SlidersHome> SL { get; set; }
        public List<Areas.BackOffice.Models.Note> N { get; set; }
        public List<Documentos> DOCSHR { get; set; }
        public List<Documentos> DOCSUN { get; set; }
    }
}