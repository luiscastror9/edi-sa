//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CofcoInd.Areas.BackOffice
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notes
    {
        public int IdNote { get; set; }
        public string titleNote { get; set; }
        public string bodyNote { get; set; }
        public string imgNote { get; set; }
        public string tagsNote { get; set; }
        public System.DateTime create_datetime { get; set; }
        public Nullable<System.DateTime> update_datetime { get; set; }
        public string authorNote { get; set; }
        public bool ActiveNote { get; set; }
        public int idCategoriasNote { get; set; }
        public string imgSliderNote { get; set; }
    }
}