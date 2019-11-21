using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Recibos.Controllers;
using Recibos.Models;

namespace Recibos.BLL
{
    public class UsuariosBLL
    {
        static string url = "https://localhost:44386/api/Usuarios/";
        public string Send<T>(string url, T objectRequest, string method, int id)
        {
            string result = "";
            if (id > 0)
                url += id.ToString();
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();

                //serializamos el objeto
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(objectRequest);

                //peticion
                WebRequest request = WebRequest.Create(url);
                //headers
                request.Method = method;
                request.PreAuthenticate = true;
                request.ContentType = "application/json;charset=utf-8'";
                request.Timeout = 10000; //esto es opcional

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                //en caso de error lo manejamos en el mensaje
                result = e.Message;

            }

            return result;
        }

        public void AgregarUsuario(Usuario usuario)
        {
            try
            {
                using(SHA256 sha = SHA256.Create())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(usuario.contra);
                    byte[] hash = sha.ComputeHash(bytes);
                    usuario.contra = Convert.ToBase64String(hash);
                }
                string resultado = Send(url, usuario, "POST", 0);
            }
            catch (Exception e)
            {
            }
        }
        public UsuarioDTO usuarioValido(string user, string contra)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(contra);
                byte[] hash = sha.ComputeHash(bytes);
                contra = Convert.ToBase64String(hash);
            }

            UsuariosController controller = new UsuariosController();
            return controller.UsuarioExists(user, contra);
        }
    }
}