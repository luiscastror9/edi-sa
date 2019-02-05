using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace CofcoInd.Areas.BackOffice.Extensions
{
    public class EmailHelper
    {
        #region -- Fields --

        private const int DefaultSmtpPort = 25;

        #endregion

        #region -- Singleton --

        private static EmailHelper _instance;

        public static EmailHelper Instance
        {
            get
            {
                if (_instance == null) _instance = new EmailHelper();
                return _instance;
            }
        }

        #endregion

        #region -- Constructors --

        public EmailHelper()
        {
            string emailFrom = ConfigurationManager.AppSettings["mailFrom"];
            string serverEmail = ConfigurationManager.AppSettings["ServerIP"];

            this.MailFrom = new MailAddress(emailFrom);
            this.ClientSmtp = new SmtpClient(serverEmail, EmailHelper.SmtpPort);
        }

        #endregion

        #region -- Properties --

        public SmtpClient ClientSmtp { get; private set; }
        public MailAddress MailFrom { get; private set; }

        private static int SmtpPort
        {
            get
            {
                string smtpPortAsString = ConfigurationManager.AppSettings["SmtpPort"];

                int smtpPort = EmailHelper.DefaultSmtpPort;

                if (!string.IsNullOrEmpty(smtpPortAsString))
                {
                    if (!int.TryParse(smtpPortAsString.Trim(), out smtpPort))
                        smtpPort = EmailHelper.DefaultSmtpPort;
                }
                else
                    smtpPort = EmailHelper.DefaultSmtpPort;

                return smtpPort;
            }
        }

        private static void ConfigureEmailSettings()
        {
            bool useExchangeConfiguration = true;
            string useExchangeConfigurationAsString = ConfigurationManager.AppSettings["useExchangeConfiguration"];

            if (!string.IsNullOrEmpty(useExchangeConfigurationAsString) &&
                bool.TryParse(useExchangeConfigurationAsString, out useExchangeConfiguration))
            {
                if (!useExchangeConfiguration)
                {
                    string sendUserName = ConfigurationManager.AppSettings["sendUserName"];
                    string sendUserPassword = ConfigurationManager.AppSettings["sendUserPassword"];

                    // Use these settings when Office365 is needed
                    //Instance.ClientSmtp.Port = EmailHelper.SmtpPort;
                    Instance.ClientSmtp.UseDefaultCredentials = false;
                    Instance.ClientSmtp.EnableSsl = true;
                    Instance.ClientSmtp.Credentials = new System.Net.NetworkCredential(sendUserName, sendUserPassword, ConfigurationManager.AppSettings["domain"]);
                }
            }
        }

        public static string ReplaceEnterCode(string text)
        {
            text = text ?? string.Empty;
            return text.Replace("\r\n", "<br/>");
        }

        #endregion

        public bool SendEmailError(string subject, string username, Exception ex)
        {
            try
            {
                ConfigureEmailSettings();
                MailMessage Mensaje = new MailMessage();
                Mensaje.From= new MailAddress(ConfigurationManager.AppSettings.Get("mailsupport"),"Error en WebApp "+ HttpContext.Current.Request.Url.ToString());
                Mensaje.To.Add(ConfigurationManager.AppSettings.Get("mailsupport"));
                Mensaje.IsBodyHtml = true;
                Mensaje.Priority = MailPriority.High;
                Mensaje.Subject = "se ha producido un Error en la WebApp con ruta" + HttpContext.Current.Request.Url.ToString();
                Mensaje.Body = "<html><table><tr><td><b>Usuario: </b><br/>" + username + "</td></tr> <tr><td><b>Origen: </b><br/>" + HttpContext.Current.Request.Url.ToString() + "</td></tr> <tr><td><b>Error: </b><br/>" + ex.StackTrace + "</td></tr> </table></html>";
                Instance.ClientSmtp.Send(Mensaje);
                return true;
            }
            catch (Exception error)
            {

            }
            return true;
        }

        public bool SendEmail(string email,string subject,string body)
        {
            try
            {
                ConfigureEmailSettings();
                MailMessage Mensaje = new MailMessage();
                Mensaje.From = new MailAddress(ConfigurationManager.AppSettings.Get("mailFrom"));
                                  
                    Mensaje.To.Add(new MailAddress(email));
                    Mensaje.IsBodyHtml = true;
                    Mensaje.Priority = MailPriority.Normal;
                    Mensaje.Subject = subject;

                    Mensaje.Body = body;
                    Instance.ClientSmtp.Send(Mensaje);
               

             return true;
            }
            catch (Exception error)
            {
                return false;
            }
            
        }
        public string bodyhtml(CofcoInd.Areas.BackOffice.Consultas con, int opt = 0)
        {
            string body = string.Empty;
            //using streamreader for reading my htmltemplate   
          
                using (StreamReader reader = new StreamReader(System.Web.Hosting.HostingEnvironment.MapPath("~/Views/Templates/contacto.html")))

                {

                    body = reader.ReadToEnd();

                }
                body = body.Replace("{Nombre}", con.NombreConsulta +" "+ con.apellidoConsulta); //replacing the required things  

                body = body.Replace("{cuit}", con.cuitConsulta);

            body = body.Replace("{provincia}", con.provinciaConsulta);
            body = body.Replace("{localidad}", con.localidadConsulta);
            body = body.Replace("{sexo}", con.sexoConsulta);
            body = body.Replace("{ocupacion}", con.ocupacionConsulta);


            body = body.Replace("{domicilio}", con.domicilioConsulta);

                body = body.Replace("{cp}", con.cpConsulta); //replacing the required things  

            body = body.Replace("{residencia}", con.residenciaConsulta); //replacing the required things  

            body = body.Replace("{telefono}", con.telefonoConsulta);

                body = body.Replace("{email}", con.EmailConsulta);

                body = body.Replace("{info}", con.contenidoConsulta);

                return body;
        }

    }
}