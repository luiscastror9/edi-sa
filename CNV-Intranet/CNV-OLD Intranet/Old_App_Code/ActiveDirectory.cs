using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using Entidades;

namespace Utilidades
{
    public static class ActiveDirectory
    {
        internal static bool UsaActiveDirectory = Convert.ToBoolean(ConfigurationManager.AppSettings["UsaActiveDirectory"]);

        public static List<string> GruposDelUsuario()
        {
            // Construye una lista para almacenar los grupos del usuario logueado
            List<string> grupos = new List<string>();

            try
            {
                // Obtiene los grupos del Active Directory
                foreach (System.Security.Principal.IdentityReference group in System.Web.HttpContext.Current.Request.LogonUserIdentity.Groups)
                {
                    // Agrega los grupos al array de grupos
                    grupos.Add(group.Translate(typeof(System.Security.Principal.NTAccount)).ToString());
                    //var nombre = System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName;
                }
            }
            catch (Exception)
            {

                // Response.Write(ex.ToString());
                // throw ex;
            }

            return grupos;
        }

        public static UsuarioAd obtieneUsuario()
        {
            var nombreUsuario = System.Web.HttpContext.Current.Request.LogonUserIdentity.Name;
            nombreUsuario = nombreUsuario.Replace("CNV\\", "");
            // var ctx = new PrincipalContext(ContextType.Domain);
            //var user = UserPrincipal.Current;
            //var nombreUsuario = user.DisplayName;
            //var nombre2 = System.Web.HttpContext.Current.User.Identity.Name.ToString();

            // Lista para Retornar
            var lList = new List<Entidades.UsuarioAd>();
            // Utiliza las credenciales de Login de Win.
            // Using rootDE As DirectoryEntry = Domain.GetCurrentDomain().GetDirectoryEntry() ' Busca Usuarios desde la raíz del Active Directory
            // Using rootDE As New DirectoryEntry("LDAP://cnv.gov.ar/CN=Domain Users,OU=UsuariosCNV,DC=cnv,DC=gov,DC=ar")

            // using (var rootDE = new DirectoryEntry("LDAP://ou=UsuariosCNV,dc=cnv,dc=gov,dc=ar"))
            // using (var rootDE = Domain.GetCurrentDomain().GetDirectoryEntry())
            // using (var rootDE = new DirectoryEntry("LDAP://ou=UsuariosCNV,dc=cnv,dc=gov,dc=ar"))
            using (var rootDE = new DirectoryEntry("LDAP://ou=UsuariosCNV,dc=cnv,dc=gov,dc=ar"))
            {
                // Crea una instancia de DirectorySearcher que permite buscar en el rootDE definido arriba
                using (var dSearcher = new DirectorySearcher(rootDE))
                {
                    // Verifica si se quieren listar todos los usuarios o uno especifico pasado por param
                    if (nombreUsuario == "")
                    {
                        // Define el filtro de busqueda del objeto principal en el AD
                        dSearcher.Filter = "(&(objectCategory=Person)(objectClass=User))";
                    }
                    else
                    {
                        dSearcher.Filter =
                            $"(&(objectCategory=Person)(objectClass=User)(!(userAccountControl:1.2.840.113556.1.4.803:=2))(sAMAccountName={"*" + nombreUsuario + "*"}))";
                    }

                    // Cargamos el dSearcher con las propiedades del objeto que queremos obtener
                    dSearcher.PropertiesToLoad.Add("sAMAccountName"); //cuenta
                    dSearcher.PropertiesToLoad.Add("giveName"); //nombreDePila
                    dSearcher.PropertiesToLoad.Add("sn"); //apellidos
                    dSearcher.PropertiesToLoad.Add("displayName"); //nombreParaMostrar
                    dSearcher.PropertiesToLoad.Add("description"); //descripcion
                    dSearcher.PropertiesToLoad.Add("mail"); //correoElectronico
                    dSearcher.PropertiesToLoad.Add("company"); //organizacion  ej. Gcia Servicios Centrales
                    dSearcher.PropertiesToLoad.Add("department"); //departamento ej. Subgcia de Informatica y Organizacion
                    dSearcher.PropertiesToLoad.Add("title"); //puesto ej. Empleado

                    // Definimos un colección para contener todos los resultados de busqueda
                    var sResult = dSearcher.FindAll();

                    if (sResult.Count == 0)
                    {
                        throw new System.Exception(

                            "Error en la Función dlusuariosActiveDirectory.listaUsuarios. No se encontraron las propiedades company, department, title, etc <br/>");
                    }

                    foreach (SearchResult result in sResult)
                    {
                        if (result.Properties.Contains("mail"))
                        {
                            var oEntUsuarios = new UsuarioAd();

                            try
                            {
                                if (result.Properties.Contains("sAMAccountName"))
                                    oEntUsuarios.Cuenta = Convert.ToString(result.Properties["sAMAccountName"][0]);

                                if (result.Properties.Contains("giveName"))
                                    oEntUsuarios.Nombre = Convert.ToString(result.Properties["giveName"][0]);

                                if (result.Properties.Contains("sn"))
                                    oEntUsuarios.Apellido = Convert.ToString(result.Properties["sn"][0]);

                                if (result.Properties.Contains("displayName"))
                                    oEntUsuarios.NombreMostrable = Convert.ToString(result.Properties["displayName"][0]);

                                if (result.Properties.Contains("description"))
                                    oEntUsuarios.Descripcion = Convert.ToString(result.Properties["description"][0]);

                                if (result.Properties.Contains("mail"))
                                    oEntUsuarios.CorreoElectronico = Convert.ToString(result.Properties["mail"][0]);

                                if (result.Properties.Contains("company"))
                                    oEntUsuarios.Organizacion = Convert.ToString(result.Properties["company"][0]);

                                if (result.Properties.Contains("department"))
                                    oEntUsuarios.Departamento = Convert.ToString(result.Properties["department"][0]);

                                if (result.Properties.Contains("title"))
                                    oEntUsuarios.Puesto = Convert.ToString(result.Properties["title"][0]);

                            }
                            catch (Exception e)
                            {
                                throw new System.Exception("Error en listaUsuarios (no hay propiedades): " +
                                                           e.Message + "<br>" + "Stack Trace: " + e.StackTrace);
                            }
                            lList.Add(oEntUsuarios);
                        }
                    }
                }
            }

            return lList[0];
        }
    }
}