using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Areas.BackOffice.Models
{
    public class SlidersHome
    {
        
            public int IdSlideHome { get; set; }
            public string descSlideHome { get; set; }
            public string urlSlideHome { get; set; }
            public string urlImgSlideHome { get; set; }
            public bool activeSlideHome { get; set; }
            public System.DateTime create_datetime { get; set; }
            public Nullable<System.DateTime> update_datetime { get; set; }
            public string nameSlideHome { get; set; }

        public List<SlidersHome> DtoSliderHome(List<sp_Select_SliderHome_Result> dto_sp)
        {
            EntitiesBO BO = new EntitiesBO();
           
            var dto_sh = from b in dto_sp
                     select new SlidersHome()
                     {
                         IdSlideHome = b.IdSlideHome,
                         descSlideHome = b.descSlideHome,
                         urlSlideHome = b.urlSlideHome,
                         urlImgSlideHome = b.urlImgSlideHome,
                         activeSlideHome = b.activeSlideHome,
                         create_datetime = b.create_datetime,
                         update_datetime = b.update_datetime,
                         nameSlideHome = b.nameSlideHome
                     };
            return dto_sh.ToList();
        }

        public SlidersHome DtoSliderHomeSimple(sp_Select_SliderHome_Result dto_sp)
        {
           

            var dto_sh = new SlidersHome()
                         {
                             IdSlideHome = dto_sp.IdSlideHome,
                             descSlideHome = dto_sp.descSlideHome,
                             urlSlideHome = dto_sp.urlSlideHome,
                             urlImgSlideHome = dto_sp.urlImgSlideHome,
                             activeSlideHome = dto_sp.activeSlideHome,
                             create_datetime = dto_sp.create_datetime,
                             update_datetime = dto_sp.update_datetime,
                             nameSlideHome = dto_sp.nameSlideHome
                         };
            return dto_sh;
        }
    }

  
}