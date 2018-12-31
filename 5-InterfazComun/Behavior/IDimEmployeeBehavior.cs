using _5_InterfazComun.DTO;
using System.Collections.Generic;

namespace _5_InterfazComun.Behavior
{
    public interface IDimEmployeeBehavior
    {
        /// <summary>
        ///  Busqueda de datos a partir de parametros de entrada
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        List<IDimEmployeeDTO> GET(IDimEmployeeDTO consulta);

        /// <summary>
        /// Obtener todo
        /// </summary>
        /// <returns></returns>
        List<IDimEmployeeDTO> GETALL();

        /// <summary>
        ///  Agregar un registro
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        IDimEmployeeDTO Create(IDimEmployeeDTO datos);

        /// <summary>
        /// Actualizar registro
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        IDimEmployeeDTO Update(IDimEmployeeDTO datos);

        /// <summary>
        /// Eliminar un registro a partir del id de un empleado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IDimEmployeeDTO Delete(int id);
        
    }
}
