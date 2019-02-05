using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public class FiduciariosFF
    {
        public int codSoc { get; set; }
        public string descripcion { get; set; }
        public List<ProgramaFF> programas { get; set; }
        public List<FideicomisosFF> fideicomisos { get; set; }
    }
}