using CNV_Site.Areas.BackOffice.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNV_Site.Controllers
{
    public class ProteccionInversorController : Controller
    {
        // GET: ProteccionInversor
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Contacto(FormCollection data)
        {
            try
            {
                Areas.BackOffice.Consultas con = new Areas.BackOffice.Consultas();
                con.NombreConsulta = data["nombre"];
                con.EmailConsulta = data["email"];
                con.contenidoConsulta = data["info"];
                con.cuitConsulta = data["dni"];
                con.domicilioConsulta = data["domicilio"];
              
                con.telefonoConsulta = data["telefono"];
                //con.create_datetime = DateTime.Now;
                //BO.sp_Insert_Consultas(con.NombreConsulta, con.EmailConsulta, con.contenidoConsulta, con.cuitConsulta, con.domicilioConsulta, con.residenciaConsulta, con.cpConsulta, con.telefonoConsulta);

                //BO.Consultas.Add(con);
                // BO.SaveChanges();
                EmailHelper eh = new EmailHelper();
                
                eh.SendEmail(con.EmailConsulta, "Contacto desde CNV Seccion Proteccion al Inversor "+ data["select1"] + " ", eh.bodyhtml(con,1));
                TempData["msg"] = "<script>alert('se ha enviado el contacto satisfactoriamente');</script>";
                return RedirectToAction("Contacto");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "<script>alert('Ha Ocurrido un error al Enviar el formulario.');</script>";
                return RedirectToAction("Contacto");
            }


        }

    }
}