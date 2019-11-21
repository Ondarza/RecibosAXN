using Recibos.Controllers;
using Recibos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace Recibos.BLL
{
    public class RecibosBLL
    {

        static string url = "https://localhost:44386/api/Recibos/";
        public string Send<T>(string url, T objectRequest, string method , int id)
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

        public void AgregarRecibo(Recibo recibo)
        {
            try
            {
                string resultado = Send(url, recibo, "POST",0);
            }
            catch (Exception e)
            {
            }
        }
        public void ModificarRecibo(Recibo recibo)
        {
            try
            {
                string resultado = Send(url, recibo, "PUT", recibo.idRecibo);
            }
            catch (Exception e)
            {
            }
        }
        public void EliminarRecibo(int id)
        {
            try
            {
                string resultado = Send(url, id, "DELETE", id);
            }
            catch (Exception e)
            {
            }
        }

        public List<ReciboDTO> CargarRecibos()
        {
            List<ReciboDTO> recibos = new List<ReciboDTO>();
            WebRequest webRequest = WebRequest.Create(url );
            webRequest.Method = "GET";
            HttpWebResponse webResponse = null;
            webResponse = (HttpWebResponse)webRequest.GetResponse();

            string result = null;
            using (Stream stream = webResponse.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                result = sr.ReadToEnd();
                sr.Close();
                recibos = new JavaScriptSerializer().Deserialize<List<ReciboDTO>>(result);
            }
            return recibos != null ? recibos : null;
        }

        public List<ReciboDTO> CargarRecibos(int id)
        {
            RecibosController controller = new RecibosController();

            return controller.GetRecibos(id, true);
        }

        public ReciboDTO CargarRecibo(int id)
        {
            ReciboDTO recibo = new ReciboDTO();

            WebRequest webRequest = WebRequest.Create(url + id.ToString());
            webRequest.Method = "GET";
            HttpWebResponse webResponse = null;

            try
            {
                webResponse = (HttpWebResponse)webRequest.GetResponse();
                string result = null;
                using (Stream stream = webResponse.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    result = sr.ReadToEnd();
                    sr.Close();
                    recibo = new JavaScriptSerializer().Deserialize<ReciboDTO>(result);
                }
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
            }
            return recibo != null ? recibo : null;
        }
    }
}