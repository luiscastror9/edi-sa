using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public class ViewModelFideicomisosFinancieros
    {
       public List<UltimasColocacionesFideicomisosFinancieros> UCFF { get; set; }
        public List<FideicomisosFF> FFF { get; set; }
        public List<ProgramaFF> PFF { get; set; }
        public List<FiduciariosFF> FFF2 { get; set; }
    }
}