using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public class Entidades
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int tipoEntidadId { get; set; }
        public string tipoEntidad { get; set; }
    }
}