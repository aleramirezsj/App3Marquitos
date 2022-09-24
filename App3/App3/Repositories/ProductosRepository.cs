using App3.Core;
using App3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App3.Repositories
{
    public class ProductosRepository
    {
        const string Url = "https://biblioisp20-92ed.restdb.io/rest/productos";
        public async Task<Producto> AddAsync(string nombre, float precio)
        {
            Producto producto = new Producto()
            {
                Nombre = nombre,
                Precio = precio
            };

            HttpClient client = Helper.ObtenerClienteHttp();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(producto),
                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Producto>(
                await response.Content.ReadAsStringAsync());
        }
        public async Task<bool> DeleteAsync(string id)
        {
            HttpClient client = Helper.ObtenerClienteHttp();
            var response = await client.DeleteAsync(Url + "/" + id);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateAsync(string nombre, float precio, string id)
        {
            HttpClient client = Helper.ObtenerClienteHttp();
            Producto producto = new Producto() {
                _id=id,
                Nombre = nombre,
                Precio = precio 
            };
            var response=await client.PutAsync(Url+"/"+id,new StringContent(JsonConvert.SerializeObject(producto),Encoding.UTF8,"application/json"));
            return response.IsSuccessStatusCode;
        }
        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            HttpClient client = Helper.ObtenerClienteHttp();
            var response=await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Producto>>(response);
        }
        public async Task<Producto> GetByIdAsync(string id)
        {
            HttpClient client = Helper.ObtenerClienteHttp();
            var response = await client.GetStringAsync(Url + "/" + id);
            return JsonConvert.DeserializeObject<Producto>(response); 
        }
    }
}
