using System;
using System.Collections.Generic;
using _4_Datos.DAL;
using _5_InterfazComun.Behavior;
using _5_InterfazComun.DTO;

namespace _3_Negocio.BL
{
    public class DimEmployeeBL : IDimEmployeeBehavior
    {

        private readonly Lazy<DimEmployeeDAL> employee;

        public DimEmployeeBL()
        {
            employee = new Lazy<DimEmployeeDAL>();
        }

        /// <summary>
        ///  Agregar un registro
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public IDimEmployeeDTO Create(IDimEmployeeDTO datos)
        {
            //Aqui irian las reglas de negocio
            return employee.Value.Create(datos);
        }

        /// <summary>
        /// Eliminar un registro a partir del id de un empleado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IDimEmployeeDTO Delete(int id)
        {
            //Aqui irian las reglas de negocio
            return employee.Value.Delete(id);
        }

        /// <summary>
        ///  Busqueda de datos a partir de parametros de entrada
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        public List<IDimEmployeeDTO> GET(IDimEmployeeDTO consulta)
        {
            //Aqui irian las reglas de negocio
            return employee.Value.GET(consulta);
        }

        /// <summary>
        /// Obtener todo
        /// </summary>
        /// <returns></returns>
        public List<IDimEmployeeDTO> GETALL()
        {
            //Aqui irian las reglas de negocio
            return employee.Value.GETALL();
        }

        /// <summary>
        /// Eliminar un registro a partir del id de un empleado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IDimEmployeeDTO Update(IDimEmployeeDTO datos)
        {
            //Aqui irian las reglas de negocio
            return employee.Value.Update(datos);
        }
    }
}
