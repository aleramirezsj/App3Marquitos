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
        /// <summary>
        /// Método que agrega una actividad de manera asincrónica
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="horarios"></param>
        /// <param name="costo"></param>
        /// <returns></returns>
        public async Task<Actividad> AddAsync(string nombre, string horarios, decimal costo)
        {
            //creamos un objeto del tipo Actividad con los parámetros que llegan
            Actividad actividad = new Actividad()
            {
                Nombre = nombre,
                Horarios = horarios,
                Costo = costo
            };

            //creamos un objeto HttpClient
            HttpClient client = Helper.ObtenerClienteHttpApiPropia();

            //enviamos por POST el objeto que creamos a la URL de la API
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(actividad),
                    Encoding.UTF8, "application/json"));
            
            //retorna el objeto que se agregó en la API ya con su ID generado por la base de datos
            return JsonConvert.DeserializeObject<Actividad>(
                await response.Content.ReadAsStringAsync());
        }
        /// <summary>
        /// método que elimina una actividad y devuelve verdadero o falso si lo pudo hacer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(int id)
        {
            HttpClient client = Helper.ObtenerClienteHttpApiPropia();
            var response = await client.DeleteAsync(Url + "/" + id);
            return response.IsSuccessStatusCode;
        }
        /// <summary>
        /// modifica una actividad
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="horarios"></param>
        /// <param name="costo"></param>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// obtiene todas las actividades
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Actividad>> GetAllAsync()
        {
            HttpClient client = Helper.ObtenerClienteHttpApiPropia();
            var response=await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Actividad>>(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Actividad> GetByIdAsync(int id)
        {
            HttpClient client = Helper.ObtenerClienteHttpApiPropia();
            var response = await client.GetStringAsync(Url + "/" + id);
            return JsonConvert.DeserializeObject<Actividad>(response); 
        }
    }
}
