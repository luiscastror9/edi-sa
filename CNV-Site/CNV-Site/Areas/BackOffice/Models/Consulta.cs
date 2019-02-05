using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNV_Site.Areas.BackOffice.Models
{
    public class Consulta
    {
        public int IdConsulta { get; set; }
        public string NombreConsulta { get; set; }
        public string EmailConsulta { get; set; }
        public string contenidoConsulta { get; set; }
        public System.DateTime create_datetime { get; set; }
        public Nullable<System.DateTime> update_datetime { get; set; }
        public string cuitConsulta { get; set; }
        public string domicilioConsulta { get; set; }
        public string residenciaConsulta { get; set; }
        public string cpConsulta { get; set; }
        public string telefonoConsulta { get; set; }

        public List<Consulta> DtoConsultas(List<sp_Select_Consultas_Result> dto_sp)
        {
            EntitiesBO BO = new EntitiesBO();
            var dto_c = from b in dto_sp
                        select new Consulta()
                        {
                            IdConsulta = b.IdConsulta,
                            NombreConsulta = b.NombreConsulta,
                            EmailConsulta = b.EmailConsulta,
                            contenidoConsulta = b.contenidoConsulta,
                            create_datetime = b.create_datetime,
                            update_datetime = b.update_datetime,
                            cuitConsulta = b.cuitConsulta,
                            domicilioConsulta = b.domicilioConsulta,
                            residenciaConsulta = b.residenciaConsulta,
                            cpConsulta = b.cpConsulta,
                            telefonoConsulta = b.telefonoConsulta
                        };
            return dto_c.ToList();
        }

        public Consulta DtoConsultasSimple(sp_Select_Consultas_Result dto_sp)
        {


            var dto_sh = new Consulta()
            {
                IdConsulta = dto_sp.IdConsulta,
                NombreConsulta = dto_sp.NombreConsulta,
                EmailConsulta = dto_sp.EmailConsulta,
                contenidoConsulta = dto_sp.contenidoConsulta,
                create_datetime = dto_sp.create_datetime,
                update_datetime = dto_sp.update_datetime,
                cuitConsulta = dto_sp.cuitConsulta,
                domicilioConsulta = dto_sp.domicilioConsulta,
                residenciaConsulta = dto_sp.residenciaConsulta,
                cpConsulta = dto_sp.cpConsulta,
                telefonoConsulta = dto_sp.telefonoConsulta
            };
            return dto_sh;
        }
    }
}