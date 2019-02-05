using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CofcoInd.Areas.BackOffice.Models;
using CofcoInd.Models;
using System.Globalization;
using FlickrNet;

namespace CofcoInd.Controllers
{
    public class NovedadesController : Controller
    {
        public CofcoInd.Areas.BackOffice.EntitiesBO BO = new CofcoInd.Areas.BackOffice.EntitiesBO();

        // GET: Prensa
         [AllowAnonymous]
        public ActionResult Index()
        {
           
           // List< CofcoInd.Areas.BackOffice.Models.Note> Notes = BO.Notes.ToList();
            List<Areas.BackOffice.sp_Select_Notes_Result> Ns = BO.sp_Select_Notes(0, null, null).ToList();
            Note Nn = new Areas.BackOffice.Models.Note();
            List<Note> Notes = Nn.DtoNotes(Ns).OrderByDescending(x=>x.create_datetime).ToList();
            Areas.BackOffice.sp_Select_SliderNotes_Result SsN = BO.sp_Select_SliderNotes(0, null, null).OrderByDescending(x => x.create_datetime).ToList().FirstOrDefault();
              PrensaHome PH = new PrensaHome();
            PH.Noticias = Notes;
            List<string> yr = new List<string>();
            List<string> mo = new List<string>();
            List<MonthsY> my = new List<MonthsY>();
            var years =  Notes.GroupBy(z=>z.create_datetime.Year);
            DateTimeFormatInfo dinfo = new CultureInfo("es-ES", false).DateTimeFormat;


            foreach (var i in years)
            {
                MonthsY mY = new MonthsY();
                string y = Convert.ToString(i.FirstOrDefault().create_datetime.Year);
                mY.Year = Convert.ToInt32(y);
                mY.Months = new List<string>();
                foreach (var e in i)
                {

                    if (e.create_datetime.Year == mY.Year)
                    {
                        mY.Months.Add(Convert.ToString(dinfo.GetMonthName(e.create_datetime.Month)));
                    }
                    if (i.Where(x => x.create_datetime.Month == e.create_datetime.Month).Count() > 1)
                        break;
                }
                my.Add(mY);

                //  yr.Add(y);
            }
            ViewBag.Years = my;

            //var months = Notes.GroupBy(z => dinfo.GetMonthName(z.create_datetime.Month) );
            //foreach (var i in years)
            //{

            //    string m = Convert.ToString(dinfo.GetMonthName(i.FirstOrDefault().create_datetime.Month));

            //    mo.Add(m);
            //}
            // ViewBag.Months = mo;
            try
            {
                //Flickr flickr = new Flickr("a4643fe323345683f35f86b922f94a02", "3f0230a15936bee5");
                //var token = flickr.OAuthGetRequestToken(Request.Url.AbsoluteUri);
                //string url = flickr.OAuthCalculateAuthorizationUrl(token.Token, AuthLevel.Read);
                //var options = new PhotoSearchOptions { UserId = "fotografiacnv", PerPage = 20, Page = 1 };
                //PhotoCollection photos = flickr.PhotosSearch(options);
                //ViewBag.Photos = photos.Take(6);

                PhotoCollection photos = new PhotoCollection();
                ViewBag.Photos = photos;

                return View(PH);
            }
            catch
            {
                PhotoCollection photos = new PhotoCollection();
                ViewBag.Photos = photos;
                ViewBag.Years = my;
                return View(PH);
            }
//            return View(PH);
        }


        // GET: Prensa/Details/5
         [AllowAnonymous]
            [HttpPost]
        public ActionResult Resultados()
        {
            try {

                return View();
            }
            
            catch
            {
                
                return View();
            }

           
        }
        // GET: Prensa/Details/5

         [AllowAnonymous]
        public ActionResult Nota(int id)
        {
            Note N = new Note();
            Areas.BackOffice.sp_Select_Notes_Result Nn = BO.sp_Select_Notes(1,id,null).FirstOrDefault();
            N = N.DtoNotesSimple(Nn);


            return View(N);
        }


    }
}
