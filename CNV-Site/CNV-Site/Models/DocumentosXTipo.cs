﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public class DocumentosXTipo
    {
        public int idDocumento { get; set; }
        public string tipoDocumento { get; set; }
        public int idPadre { get; set; }
        public List<Documentos> DOCS { get; set; }
    }
}