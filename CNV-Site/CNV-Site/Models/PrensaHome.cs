using CNV_Site.Areas.BackOffice;
using CNV_Site.Areas.BackOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Models
{
    public class PrensaHome
    {
        
       
        public  List<Note> Noticias { get; set; } 
        public SlidersNotes Galeria { get; set; }
    }

  
}