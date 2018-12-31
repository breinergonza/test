using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using _1_Presentacion_MVC.Models;
using _1_Presentacion_MVC.WebClient;

namespace _1_Presentacion_MVC.Controllers
{
    public class DimEmployeesController : Controller
    {
        /// <summary>
        /// Metodo para obtener todos los registros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Index()
        {

            List<DimEmployee> resp = await DimEmployeesClient.GetAllAsync();

            return View(resp);
        }

        /// <summary>
        /// Metodo para obtener un detalle a partir del Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var dimEmployee = await DimEmployeesClient.GetAsync(id.Value);

                if (dimEmployee == null) return HttpNotFound();

                return View(dimEmployee);
            }
        }

        [Authorize]
        public ActionResult Create()
        {

            //ViewBag.ParentEmployeeKey = new SelectList(db.DimEmployee, "EmployeeKey", "FirstName");

            return View();
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include ="EmployeeKey,ParentEmployeeKey,FirstName,LastName,MiddleName,Title,HireDate,BirthDate,EmailAddress,Phone,MaritalStatus,EmergencyContactName,EmergencyContactPhone,SalariedFlag,Gender,PayFrequency,BaseRate,VacationHours,CurrentFlag,SalesPersonFlag,DepartmentName,StartDate,EndDate,Status,ImageUrl,ProfileUrl,ETLLoadID,LoadDate,UpdateDate")] DimEmployee dimEmployee)
        {
            if (ModelState.IsValid)
            {
                DimEmployee respuesta = await DimEmployeesClient.CreateAsync(dimEmployee);

                if (respuesta != null)
                {
                    return RedirectToAction("Index");
                }
            }
            
            //ViewBag.ParentEmployeeKey = new SelectList(db.DimEmployee, "EmployeeKey", "FirstName", dimEmployee.ParentEmployeeKey);

            return View(dimEmployee);
        }

        // GET: DimEmployees/Edit/5
        [Authorize]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var dimEmployee = await DimEmployeesClient.GetAsync(id.Value);

                if (dimEmployee == null) return HttpNotFound();

                //ViewBag.ParentEmployeeKey =
                //    new SelectList(db.DimEmployee, "EmployeeKey", "FirstName", dimEmployee.ParentEmployeeKey);

                return View(dimEmployee);
            }
        }

        // POST: DimEmployees/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EmployeeKey,ParentEmployeeKey,FirstName,LastName,MiddleName,Title,HireDate,BirthDate,EmailAddress,Phone,MaritalStatus,EmergencyContactName,EmergencyContactPhone,SalariedFlag,Gender,PayFrequency,BaseRate,VacationHours,CurrentFlag,SalesPersonFlag,DepartmentName,StartDate,EndDate,Status,ImageUrl,ProfileUrl,ETLLoadID,LoadDate,UpdateDate")] DimEmployee dimEmployee)
        {
            if (ModelState.IsValid)
            {
                DimEmployee respuesta = await DimEmployeesClient.UpdateAsync(dimEmployee);

                if (respuesta != null)
                {
                    return RedirectToAction("Index");
                }
                
                return RedirectToAction("Index");
            }

            //ViewBag.ParentEmployeeKey =
            //    new SelectList(db.DimEmployee, "EmployeeKey", "FirstName", dimEmployee.ParentEmployeeKey);

            return View(dimEmployee);
        }

        // GET: DimEmployees/Delete/5
        [Authorize]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dimEmployee = await DimEmployeesClient.GetAsync(id.Value);

            if (dimEmployee == null) return HttpNotFound();

            return View(dimEmployee);
        }

        // POST: DimEmployees/Delete/5
        [HttpPost]
        [Authorize]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var dimEmployee = await DimEmployeesClient.DeleteAsync(id);

            return RedirectToAction("Index");
        }

    }
}