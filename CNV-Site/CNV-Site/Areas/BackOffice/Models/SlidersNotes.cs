using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Areas.BackOffice.Models
{
    public class SlidersNotes
    {
        public int IdSliderNotes { get; set; }
        public string descSliderNotes { get; set; }
        public System.DateTime create_datetime { get; set; }
        public Nullable<System.DateTime> update_datetime { get; set; }

        public List<SlidersNotes> DtoConsultas(List<sp_Select_SliderNotes_Result> dto_sp)
        {
          
            var dto_sn = from b in dto_sp
                        select new SlidersNotes()
                        {
                            IdSliderNotes = b.IdSliderNotes,
                            descSliderNotes = b.descSliderNotes, 
                            create_datetime = b.create_datetime,
                            update_datetime = b.update_datetime
                        };
            return dto_sn.ToList();
        }
        public SlidersNotes DtoConsultaSimple(sp_Select_SliderNotes_Result dto_sp)
        {
          
            var dto_sn =new SlidersNotes()
                         {
                             IdSliderNotes = dto_sp.IdSliderNotes,
                             descSliderNotes = dto_sp.descSliderNotes,
                             create_datetime = dto_sp.create_datetime,
                             update_datetime = dto_sp.update_datetime
                         };
            return dto_sn;
        }
    }
}