using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using _2_Servicios_API.Models;
using _3_Negocio.BL;
using _5_InterfazComun.Extensiones;

namespace _2_Servicios_API.Controllers
{
    public class DimEmployeesController : ApiController
    {      

        private readonly Lazy<DimEmployeeBL> employee;

        public DimEmployeesController()
        {
            employee = new Lazy<DimEmployeeBL>();
        }

        /// <summary>
        /// Metodo para obtener todos los registros GET: api/DimEmployees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<DimEmployeeType> GetDimEmployee()
        {
            return employee.Value.GETALL().MapperPruebasDetached(new List<DimEmployeeType>());
        }

        /// <summary>
        /// Metodo para obtener un registro de DimEmployee a partir de su Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(DimEmployeeType))]
        public IHttpActionResult GetDimEmployee(int id)
        {
            DimEmployeeType dimEmployee = DimEmployeeId(id);

            if (dimEmployee == null)
            {
                return NotFound();
            }

            return Ok(dimEmployee);
        }

        /// <summary>
        /// Metodo para actualizar un registro de DimEmployee
        /// </summary>
        /// <param name="dimEmployee"></param>
        /// <returns></returns>
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDimEmployee(DimEmployeeType dimEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            employee.Value.Update(dimEmployee);

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Metodo para agregar un registro - POST: api/DimEmployees
        /// </summary>
        /// <param name="dimEmployee"></param>
        /// <returns></returns>
        [HttpPost]
        //[ResponseType(typeof(DimEmployeeType))]
        public IHttpActionResult PostDimEmployee(DimEmployeeType dimEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dimEmployee = employee.Value.Create(dimEmployee).MapperPruebasDetached(new DimEmployeeType());

            return CreatedAtRoute("DefaultApi", new { id = dimEmployee.EmployeeKey }, dimEmployee);
        }

        /// <summary>
        /// Metodo para eliminar un registro a partir de su Id - DELETE: api/DimEmployees/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ResponseType(typeof(DimEmployeeType))]
        public IHttpActionResult DeleteDimEmployee(int id)
        {
            DimEmployeeType dimEmployee = employee.Value.Delete(id).MapperPruebasDetached(new DimEmployeeType());

            if (dimEmployee == null)
            {
                return NotFound();
            }
           
            return Ok(dimEmployee);
        }

        /// <summary>
        /// Obtiene un DimEmployee a partir de su Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private DimEmployeeType DimEmployeeId(int id)
        {
            //El metodo GET de empleados puede ser utilizado para la busqueda de cualquier campo
            return employee.Value.GET(new DimEmployeeType()
            {
                EmployeeKey = id
            }).FirstOrDefault().MapperPruebasDetached(new DimEmployeeType());
        }
    }
}