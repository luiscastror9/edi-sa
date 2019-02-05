using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CofcoInd.Areas.BackOffice.Models
{
    public class Note
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

        public List<Note> DtoNotes(List<sp_Select_Notes_Result> dto_sp)
        {
            EntitiesBO BO = new EntitiesBO();
            var dto_n = from b in dto_sp
                     select new Note()
                     {
                         IdNote = b.IdNote,
                         titleNote = b.titleNote,
                         bodyNote = b.bodyNote,
                         imgNote = b.imgNote,
                         tagsNote = b.tagsNote,
                         create_datetime = b.create_datetime,
                         update_datetime = b.update_datetime,
                         authorNote = b.authorNote,
                         ActiveNote = b.ActiveNote,
                         idCategoriasNote = b.idCategoriasNote,
                         imgSliderNote = b.imgSliderNote
                     };
            return dto_n.ToList();
        }

        public Note DtoNotesSimple(sp_Select_Notes_Result dto_sp)
        {
           
            var dto_n = new Note()
                        {
                            IdNote = dto_sp.IdNote,
                            titleNote = dto_sp.titleNote,
                            bodyNote = dto_sp.bodyNote,
                            imgNote = dto_sp.imgNote,
                            tagsNote = dto_sp.tagsNote,
                            create_datetime = dto_sp.create_datetime,
                            update_datetime = dto_sp.update_datetime,
                            authorNote = dto_sp.authorNote,
                            ActiveNote = dto_sp.ActiveNote,
                            idCategoriasNote = dto_sp.idCategoriasNote,
                            imgSliderNote = dto_sp.imgSliderNote
                        };
            return dto_n;
        }

    }

  
}