using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using System.Net.Mail;
using System.Net;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace CapaNegocios
{
   
    public class CN_Recurso
    {
        public static string GenerarClave()
        {
            string clave=Guid.NewGuid().ToString("N").Substring(0,6);
            return clave;
        }



        public static string ConvertirSha256(string Mensaje)
        {
            StringBuilder sb=new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes("johan"));
                foreach (Byte b in result)
                    sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
        public static bool EnviarCorreo(string correo, string asunto, string mensaje)
        {
            bool resultado = false;
            try
            {
                MailMessage mail = new MailMessage();
               mail.To.Add(correo);
                mail.From = new MailAddress("Roquejohanssen@gmail.com");
                mail.Subject = asunto;
                mail.Body = mensaje;
                mail.IsBodyHtml = true;
                var smtp = new SmtpClient()
                {
                    Credentials = new NetworkCredential("Roquejohanssen@gmail.com", "oyaitgdgwtfsciwr"),
                      Host = "smtp.gmail.com",
                      Port = 587,
                      EnableSsl = true
                };    
                smtp.Send(mail);
                resultado = true;
            }
            catch(Exception ex)
            {
                resultado=false;
            }
            return resultado;
        }
        public static string ConvertirBase64(string ruta,bool conversion)
        {
            string textobase64 = string.Empty;
            try
            {
                byte[] bytesImagen = File.ReadAllBytes(ruta);
                textobase64 = Convert.ToBase64String(bytesImagen);
            }
            catch (Exception ex)
            {
               conversion = false;
            }
            return textobase64;
        }

        
    }
}
