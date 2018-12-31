using System;
using System.Collections.Generic;
using System.Linq;
using _4_Datos.Data;
using _5_InterfazComun.Behavior;
using _5_InterfazComun.DTO;
using _5_InterfazComun.Extensiones;

namespace _4_Datos.DAL
{
    public class DimEmployeeDAL : IDimEmployeeBehavior
    {
        private Entitys db;
        
        public DimEmployeeDAL()
        {
            db = new Entitys();
        }

        #region "Metodos publicos"

        /// <summary>
        /// Busqueda de datos a partir de parametros de entrada
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        public List<IDimEmployeeDTO> GET(IDimEmployeeDTO consulta)
        {
            List<DimEmployee> respuesta = new List<DimEmployee>();

            try
            {
                if (consulta != null)
                {
                    IQueryable<DimEmployee> buscar = db.DimEmployee.Where(x =>
                        (x.EmployeeKey == consulta.EmployeeKey || consulta.EmployeeKey == 0)
                        && (x.FirstName.Contains(consulta.FirstName) || consulta.FirstName == null)
                        && (x.LastName.Contains(consulta.LastName) || consulta.LastName == null)
                        && (x.MiddleName.Contains(consulta.MiddleName) || consulta.MiddleName == null)
                        && (x.Title.Contains(consulta.Title) || consulta.Title == null)
                        && (x.EmailAddress.Contains(consulta.EmailAddress) || consulta.EmailAddress == null)
                    );

                    respuesta = buscar.ToList();
                }
                else
                {
                    respuesta = db.DimEmployee.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return respuesta.MapperPruebasDetached(new List<IDimEmployeeDTO>());

        }

        /// <summary>
        /// Obtener todos los registros
        /// </summary>
        /// <returns></returns>
        public List<IDimEmployeeDTO> GETALL()
        {
            return db.DimEmployee.ToList().MapperPruebasDetached(new List<IDimEmployeeDTO>()); ;
        }

        /// <summary>
        /// Agregar registro
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public IDimEmployeeDTO Create(IDimEmployeeDTO datos)
        {
            DimEmployee DimEmployeeParaGuardar = datos.MapperPruebas<IDimEmployeeDTO, DimEmployee>();

            db.DimEmployee.Add(DimEmployeeParaGuardar);
            db.SaveChanges();

            return DimEmployeeParaGuardar.MapperPruebas<IDimEmployeeDTO, DimEmployee>();
        }

        /// <summary>
        /// Actualizar Registro
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public IDimEmployeeDTO Update(IDimEmployeeDTO datos)
        {
            DimEmployee DimEmployeeEditar = db.DimEmployee.FirstOrDefault(c =>
                   c.EmployeeKey == datos.EmployeeKey);

            DimEmployee parametros = datos.MapperPruebasDetached(new DimEmployee());

            if (DimEmployeeEditar == null)
            {
                return new DimEmployee();
            }

            //Mapeo para actualizar
            DimEmployeeEditar.ParentEmployeeKey = parametros.ParentEmployeeKey;
            DimEmployeeEditar.FirstName = parametros.FirstName;
            DimEmployeeEditar.LastName = parametros.LastName;
            DimEmployeeEditar.MiddleName = parametros.MiddleName;
            DimEmployeeEditar.Title = parametros.Title;
            DimEmployeeEditar.HireDate = parametros.HireDate;
            DimEmployeeEditar.BirthDate = parametros.BirthDate;
            DimEmployeeEditar.EmailAddress = parametros.EmailAddress;
            DimEmployeeEditar.Phone = parametros.Phone;
            DimEmployeeEditar.MaritalStatus = parametros.MaritalStatus;
            DimEmployeeEditar.EmergencyContactName = parametros.EmergencyContactName;
            DimEmployeeEditar.EmergencyContactPhone = parametros.EmergencyContactPhone;
            DimEmployeeEditar.SalariedFlag = parametros.SalariedFlag;
            DimEmployeeEditar.Gender = parametros.Gender;
            DimEmployeeEditar.PayFrequency = parametros.PayFrequency;
            DimEmployeeEditar.BaseRate = parametros.BaseRate;
            DimEmployeeEditar.VacationHours = parametros.VacationHours;
            DimEmployeeEditar.CurrentFlag = parametros.CurrentFlag;
            DimEmployeeEditar.SalesPersonFlag = parametros.SalesPersonFlag;
            DimEmployeeEditar.DepartmentName = parametros.DepartmentName;
            DimEmployeeEditar.StartDate = parametros.StartDate;
            DimEmployeeEditar.EndDate = parametros.EndDate;
            DimEmployeeEditar.Status = parametros.Status;
            DimEmployeeEditar.ImageUrl = parametros.ImageUrl;
            DimEmployeeEditar.ProfileUrl = parametros.ProfileUrl;
            DimEmployeeEditar.ETLLoadID = parametros.ETLLoadID;
            DimEmployeeEditar.LoadDate = parametros.LoadDate;
            DimEmployeeEditar.UpdateDate = parametros.UpdateDate;

            if (db.SaveChanges() <= 0)
            {
                //error
            }

            return DimEmployeeEditar;
        }

        /// <summary>
        /// Eliminar registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IDimEmployeeDTO Delete(int id)
        {
            DimEmployee del = db.DimEmployee.Find(id);

            db.DimEmployee.Remove(del);
            db.SaveChanges();

            return del;
        }

        #endregion

        #region "Metodos privados"

        /// <summary>
        /// Validar si empleado existe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DimEmployeeExists(int id)
        {
            return db.DimEmployee.Count(e => e.EmployeeKey == id) > 0;
        }             

        #endregion
    }
}
