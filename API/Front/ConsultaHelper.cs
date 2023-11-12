using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrica.Http
{
    class ConsultaHelper
    {
        private static ConsultaHelper instancia;
        private HttpClient client;
        private ConsultaHelper()
        {
            client = new HttpClient();
        }
        public static ConsultaHelper GetInstance()
        {
            if (instancia == null)
                instancia = new ConsultaHelper();
            return instancia;
        }
        public async Task<string> GetAsync(string url)
        {
            var result = await client.GetAsync(url);
            var content = "";
            if (result.IsSuccessStatusCode)
                content = await result.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<Response> PostAsync(string url, string data)
        {
            StringContent content = new StringContent(data, Encoding.UTF8,
            "application/json");
            var result = await client.PostAsync(url, content);
            

            Response resp = new Response()
            {
                Ok = result.IsSuccessStatusCode,
                Mensaje = await result.Content.ReadAsStringAsync()
            };
           
            return resp;
        }
        public async Task<Response> DeleteAsync(string url)
        {
           
            var result = await client.DeleteAsync(url);


            Response resp = new Response()
            {
                Ok = result.IsSuccessStatusCode,
                Mensaje = await result.Content.ReadAsStringAsync()
            };

            return resp;
        }

        public async Task<Response> PutAsync(string url, string data)
        {
            StringContent content = new StringContent(data, Encoding.UTF8,
            "application/json");
            var result = await client.PutAsync(url, content);


            Response resp = new Response()
            {
                Ok = result.IsSuccessStatusCode,
                Mensaje = await result.Content.ReadAsStringAsync()
            };

            return resp;
        }
    }


    public class Response
    {
        public bool Ok { get; set; }
        public string Mensaje { get; set; }
    }
}
