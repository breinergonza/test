using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using _1_Presentacion_MVC.Models;
using _5_InterfazComun.Constantes;

namespace _1_Presentacion_MVC.WebClient
{
    public class DimEmployeesClient 
    {
        private static readonly HttpClient client = new HttpClient();
        
        /// <summary>
        ///     Obtener empleados del API
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task<List<DimEmployee>> GetAllAsync()
        {
            string path = Constantes.urlDimEmployees;
            List<DimEmployee> employee = null;
            var response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode) employee = await response.Content.ReadAsAsync<List<DimEmployee>>();
            return employee;
        }

        /// <summary>
        /// Metodo para obtener un Empleado a partir de su Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<DimEmployee> GetAsync(int id)
        {
            string path = Constantes.urlDimEmployees + "/" + id;
            DimEmployee employee = null;

            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode) employee = await response.Content.ReadAsAsync<DimEmployee>();
            return employee;
        }

        /// <summary>
        /// Metodo para actualizar un Empleado
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static async Task<DimEmployee> UpdateAsync(DimEmployee employee)
        {
            string path = Constantes.urlDimEmployees + "/" + employee.EmployeeKey;

            HttpResponseMessage response = await client.PutAsJsonAsync(path, employee);

            response.EnsureSuccessStatusCode();
            
            employee = await response.Content.ReadAsAsync<DimEmployee>();

            return employee;
        }

        /// <summary>
        /// Metodo para agregar un empleado
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static async Task<DimEmployee> CreateAsync(DimEmployee employee)
        {
            string path = Constantes.urlDimEmployees;

            HttpResponseMessage response = await client.PostAsJsonAsync(path, employee);

            response.EnsureSuccessStatusCode();

            employee = await response.Content.ReadAsAsync<DimEmployee>();
            
            return employee;
        }

        /// <summary>
        /// Metodo para eliminar un registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<HttpStatusCode> DeleteAsync(int id)
        {
            string path = Constantes.urlDimEmployees + "/" + id;

            HttpResponseMessage response = await client.DeleteAsync(path);

            return response.StatusCode;
        }

    }
}