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
    public class ActividadesRepository
    {
        const string Url = "https://cosmopolitaweb.azurewebsites.net/api/apiactividades";
        public async Task<Actividad> AddAsync(string nombre, string horarios, decimal costo)
        {
            Actividad actividad = new Actividad()
            {
                Nombre = nombre,
                Horarios = horarios,
                Costo = costo
            };

            HttpClient client = Helper.ObtenerClienteHttpApiPropia();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(actividad),
                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Actividad>(
                await response.Content.ReadAsStringAsync());
        }
        public async Task<bool> DeleteAsync(int id)
        {
            HttpClient client = Helper.ObtenerClienteHttpApiPropia();
            var response = await client.DeleteAsync(Url + "/" + id);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateAsync(string nombre, string horarios, decimal costo, int id)
        {
            HttpClient client = Helper.ObtenerClienteHttpApiPropia();
            Actividad actividad = new Actividad() {
                Id=id,
                Nombre = nombre,
                Horarios = horarios,
                Costo= costo
            };
            var response=await client.PutAsync(Url+"/"+id,new StringContent(JsonConvert.SerializeObject(actividad),Encoding.UTF8,"application/json"));
            return response.IsSuccessStatusCode;
        }
        public async Task<IEnumerable<Actividad>> GetAllAsync()
        {
            HttpClient client = Helper.ObtenerClienteHttpApiPropia();
            var response=await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Actividad>>(response);
        }
        public async Task<Actividad> GetByIdAsync(int id)
        {
            HttpClient client = Helper.ObtenerClienteHttpApiPropia();
            var response = await client.GetStringAsync(Url + "/" + id);
            return JsonConvert.DeserializeObject<Actividad>(response); 
        }
    }
}
