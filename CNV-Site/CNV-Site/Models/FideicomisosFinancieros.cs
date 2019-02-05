using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public class FideicomisosFinancieros
    {
        public int id { get; set; }
        public string denominacion { get; set; }
        public string fiduciario { get; set; }
        public object fiduciante { get; set; }
        public ProgramaFideicomisosFinancieros programa { get; set; }
        public object activosFideicomiso { get; set; }
        public string moneda { get; set; }
        public int montoAutorizado { get; set; }
        public string lugarCotizacion { get; set; }
        public object agentePago { get; set; }
        public object lugarPago { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public DateTime fechaColocacion { get; set; }
        public List<DocumentoFF> documentos { get; set; }
    }
}