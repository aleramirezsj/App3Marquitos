using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace App3.Core
{
    public class Helper
    {
        public static HttpClient ObtenerClienteHttp()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("x-apikey", "2c677ccf2cb62a940092248e128001983dab0");
            return client;
        }
        public static HttpClient ObtenerClienteHttpApiPropia()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
    }
}
