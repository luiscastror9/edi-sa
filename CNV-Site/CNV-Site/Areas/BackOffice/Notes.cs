//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNV_Site.Areas.BackOffice
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

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
        public string GenerateSlug()
        {
            string phrase = string.Format("{0}/{1}", IdNote, titleNote);

            string str = RemoveAccent(phrase).ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            //str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        private string RemoveAccent(string text)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(text);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }
}
