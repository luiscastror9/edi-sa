using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public class UltimasColocacionesFideicomisosFinancieros
    {
        public int id { get; set; }
        public int tipoId { get; set; }
        public string tipo { get; set; }
        public string denominacion { get; set; }
        public string fiduciario { get; set; }
        public List<string> fiduciantes { get; set; }
        public ProgramaFideicomisosFinancieros programa { get; set; }
        public string activosFideicomiso { get; set; }
        public string moneda { get; set; }
        public string montoAutorizado { get; set; }
        public string lugarCotizacion { get; set; }
        public string agentePago { get; set; }
        public string lugarPago { get; set; }
        public DateTime? fechaVencimiento { get; set; }
        public DateTime? fechaColocacion { get; set; }
        public List<DocumentoFF> documentos { get; set; }
    }
}