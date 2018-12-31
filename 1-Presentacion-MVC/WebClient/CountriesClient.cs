using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using _1_Presentacion_MVC.Models;
using _5_InterfazComun.Constantes;

namespace _1_Presentacion_MVC.WebClient
{
    public class CountriesClient
    {
        private static readonly HttpClient client = new HttpClient();
        
        /// <summary>
        ///     Obtener listado de todos los paises del API
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task<List<Countries>> GetCountriesAsync()
        {
            string path = Constantes.urlAllCountries;

            List<Countries> countries= null;
            var response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode) countries = await response.Content.ReadAsAsync<List<Countries>>();
            return countries;
        }
        
    }
}