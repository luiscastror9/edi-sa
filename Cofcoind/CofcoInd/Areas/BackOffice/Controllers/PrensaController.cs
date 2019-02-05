using CofcoInd.Areas.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CofcoInd.Areas.BackOffice.Controllers
{
    public class PrensaController : AlertsController
    {
        public EntitiesBO BO = new EntitiesBO();
        // GET: BackOffice/Prensa
         [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Integraciones()
        {
            return View();
        }

        #region Articulos Prensa
         [Authorize]
        public ActionResult Articulos()
        {
            return View();
        }
              
   [Authorize]
        public ActionResult ArticulosDataSurvey(jQueryDataTableParamModel param)
        {
            var ArticulossHome = BO.sp_Select_Notes(0, null, null).ToList();


            var displayedArticulossHome = ArticulossHome
                        .Skip(param.iDisplayStart)
                        .Take(param.iDisplayLength);

            var result = from c in displayedArticulossHome
                         select new { c.IdNote, c.titleNote, c.imgNote};

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = ArticulossHome.Count(),
                iTotalDisplayRecords = ArticulossHome.Count(),
                aaData = result
            },
             JsonRequestBehavior.AllowGet);
        }

   [Authorize]
        public ActionResult EditArticulos(int id)
        {
            Notes Notes = BO.Notes.Where(x => x.IdNote == id).FirstOrDefault();
            List<CategoriasNotes> cat = BO.CategoriasNotes.ToList();
            ViewBag.Categorias = new SelectList(cat, "idCategoriasNotes", "descCategoriasNotes");
            return View(Notes);
        }

   [Authorize]
        [ValidateInput(false)]
        public ActionResult CreateArticulos()
        {
            List<CategoriasNotes> cat = BO.CategoriasNotes.ToList();
            ViewBag.Categorias = new SelectList(cat, "idCategoriasNotes", "descCategoriasNotes");
            return View();
        }


   [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DeleteArticulos(int id)
        {
            try
            {
                Notes Notes = BO.Notes.Where(x => x.IdNote == id).FirstOrDefault();
                BO.Entry(Notes).State = System.Data.Entity.EntityState.Deleted;
                BO.SaveChanges();
                Success("Se ha Eliminado el Articulos con Exito!");
                return Content(Url.Action("Articulos", "Prensa"));


            }
            catch
            {
                Danger("Ha Ocurrido un Error!");
                return Content(Url.Action("Articulos", "Prensa"));

            }
        }

        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditArticulos(int id, IEnumerable<HttpPostedFileBase> imgNote, IEnumerable<HttpPostedFileBase> imgSliderNote, FormCollection data)
        {
            try
            {
                Notes Notes = BO.Notes.Where(x => x.IdNote == id).FirstOrDefault();
                Notes.titleNote = data["titleNote"];
                Notes.bodyNote = data["bodyNote"];
                Notes.tagsNote = data["tagsNote"];
                Notes.idCategoriasNote = Convert.ToInt32(data["idCategoriasNotes"]);
                bool activeH = data["h_activeNote"] == "true" ? true : false;
                Notes.ActiveNote = activeH;
                Notes.authorNote = User.Identity.Name ?? "";
                if (imgNote.Count() > 0)
                {
                    foreach (var f in imgNote)
                    {
                        if (f != null)
                        {
                            string _filepath = Path.GetFileName(f.FileName);
                            string _path = Path.Combine(Server.MapPath("~/Content/Upload"), _filepath);

                            f.SaveAs(_path);
                            Notes.imgNote = Path.GetFileName(imgNote.First().FileName);

                        }
                        else { Notes.imgNote = null; }

                    }
                }
                if (imgSliderNote.Count() > 0)
                {
                    foreach (var f in imgSliderNote)
                    {
                        if (f != null)
                        {
                            string _filepath = Path.GetFileName(f.FileName);
                            string _path = Path.Combine(Server.MapPath("~/Content/Upload"), _filepath);

                            f.SaveAs(_path);
                            Notes.imgSliderNote = Path.GetFileName(imgSliderNote.First().FileName);

                        }
                        else { Notes.imgSliderNote = null; }

                    }
                }
                DateTime date = DateTime.Now;

                if (Notes.imgNote == null)
                    Notes.imgNote = "";
                if (Notes.imgSliderNote == null)
                    Notes.imgSliderNote = "";

                Notes.update_datetime = date;
                BO.Entry(Notes).State = System.Data.Entity.EntityState.Modified;
                BO.SaveChanges();
                Success("Se ha Actualizado el Articulos con Exito!");
                return RedirectToAction("Articulos");
            }
            catch
            {
                Danger("Ha Ocurrido un Error!");
                return RedirectToAction("Articulos");

            }
        }

        [HttpPost]
   [Authorize]
        [ValidateInput(false)]
        public ActionResult CreateArticulos(IEnumerable<HttpPostedFileBase> imgNote, IEnumerable<HttpPostedFileBase> imgSliderNote, FormCollection data)
        {
            try
            {
                Notes Notes = new Notes();
                Notes.titleNote = data["titleNote"];
                Notes.bodyNote = data["bodyNote"];
                Notes.tagsNote = data["tagsNote"];
                Notes.idCategoriasNote = Convert.ToInt32(data["idCategoriasNotes"]);
                bool activeH = data["h_activeNote"] == "true" ? true : false;
                Notes.ActiveNote = activeH;
                Notes.authorNote = User.Identity.Name ?? "";
                if (imgNote.Count() > 0)
                {
                    foreach (var f in imgNote)
                    { 
                        if (f != null)
                        {
                            string _filepath = Path.GetFileName(f.FileName);
                            string _path = Path.Combine(Server.MapPath("~/Content/Upload"), _filepath);

                            f.SaveAs(_path);
                            Notes.imgNote = imgNote.First() != null ? Path.GetFileName(imgNote.First().FileName) : "";
                        }
                        else { Notes.imgNote = null; }

                    }
                }
                
                if (imgSliderNote.Count() > 0)
                {
                    foreach (var f in imgSliderNote)
                    {
                        if (f != null) { 
                        string _filepath = Path.GetFileName(f.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Content/Upload"), _filepath);

                        f.SaveAs(_path);
                            Notes.imgSliderNote = imgSliderNote.First() != null ? Path.GetFileName(imgSliderNote.First().FileName) : "";

                        }
                        else { Notes.imgSliderNote = null; }
                    }
                }
                DateTime date = DateTime.Now;
                Notes.create_datetime = date;
                if (Notes.imgNote == null)
                    Notes.imgNote = "";
                if (Notes.imgSliderNote == null)
                    Notes.imgSliderNote = "";
                BO.Notes.Add(Notes);
                BO.SaveChanges();
                Success("Se ha Agregado el Articulos con Exito!");
                return RedirectToAction("Articulos");
            }
            catch
            {
                Danger("Ha Ocurrido un Error!");
                return RedirectToAction("Articulos");

            }
        }

        #endregion

       

        #region Categorias 
        public ActionResult Categorias()
        {
            return View();
        }
   [Authorize]
        public ActionResult CategoriasDataSurvey(jQueryDataTableParamModel param)
        {
            var CategoriasHome = BO.sp_Select_CategoriasNotes(0, null, null).ToList();


            var displayedCategoriasHome = CategoriasHome
                        .Skip(param.iDisplayStart)
                        .Take(param.iDisplayLength);

            var result = from c in displayedCategoriasHome
                         select new { c.IdCategoriasNotes, c.descCategoriasNotes};

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = CategoriasHome.Count(),
                iTotalDisplayRecords = CategoriasHome.Count(),
                aaData = result
            },
             JsonRequestBehavior.AllowGet);
        }

   [Authorize]
        public ActionResult EditCategorias(int id)
        {
            CategoriasNotes Categories = BO.CategoriasNotes.Where(x => x.IdCategoriasNotes == id).FirstOrDefault();

            return View(Categories);
        }

   [Authorize]
        public ActionResult CreateCategorias()
        {

            return View();
        }


   [Authorize]
        [HttpPost]
        public ActionResult DeleteCategorias(int id)
        {
            try
            {
                CategoriasNotes Categories = BO.CategoriasNotes.Where(x => x.IdCategoriasNotes == id).FirstOrDefault();
                BO.Entry(Categories).State = System.Data.Entity.EntityState.Deleted;
                BO.SaveChanges();
                Success("Se ha Eliminado el Articulos con Exito!");
                return Content(Url.Action("Categorias", "Prensa"));

            }
            catch
            {
                Danger("Ha Ocurrido un Error!");
                return Content(Url.Action("Categorias", "Prensa"));

            }
        }


   [Authorize]
        [HttpPost]
        public ActionResult EditCategorias(int id, FormCollection data)
        {
            try
            {
                CategoriasNotes Notes = BO.CategoriasNotes.Where(x => x.IdCategoriasNotes == id).FirstOrDefault();
                Notes.descCategoriasNotes = data["descCategoriasNotes"];
                DateTime date = DateTime.Now;
                Notes.update_datetime = date;
                BO.Entry(Notes).State = System.Data.Entity.EntityState.Modified;
                BO.SaveChanges();
                Success("Se ha Actualizado la Categoria con Exito!");
                return RedirectToAction("Categorias");
            }
            catch
            {
                Danger("Ha Ocurrido un Error!");
                return RedirectToAction("Categorias");

            }
        }

        [HttpPost]
   [Authorize]
        public ActionResult CreateCategorias(FormCollection data)
        {
            try
            {
                CategoriasNotes Notes = new CategoriasNotes();
                Notes.descCategoriasNotes = data["descCategoriasNotes"];
                   DateTime date = DateTime.Now;
                Notes.create_datetime = date;
                BO.CategoriasNotes.Add(Notes);
                BO.SaveChanges();
                Success("Se ha Agregado la Categoria con Exito!");
                return RedirectToAction("Categorias");
            }
            catch
            {
                Danger("Ha Ocurrido un Error!");
                return RedirectToAction("Categorias");

            }
        }


        #endregion



    }
}