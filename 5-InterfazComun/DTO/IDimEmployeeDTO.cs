using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_InterfazComun.DTO
{
    public interface IDimEmployeeDTO
    {

        int EmployeeKey { get; set; }

        //int? ParentEmployeeKey { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string MiddleName { get; set; }

        string Title { get; set; }

        DateTime? HireDate { get; set; }

        DateTime? BirthDate { get; set; }

        string EmailAddress { get; set; }

        string Phone { get; set; }

        string MaritalStatus { get; set; }

        string EmergencyContactName { get; set; }

        string EmergencyContactPhone { get; set; }

        bool? SalariedFlag { get; set; }

        string Gender { get; set; }

        byte? PayFrequency { get; set; }

        decimal? BaseRate { get; set; }

        short? VacationHours { get; set; }

        bool CurrentFlag { get; set; }

        bool SalesPersonFlag { get; set; }

        string DepartmentName { get; set; }

        DateTime? StartDate { get; set; }

        DateTime? EndDate { get; set; }

        string Status { get; set; }

        string ImageUrl { get; set; }

        string ProfileUrl { get; set; }

        int? ETLLoadID { get; set; }

        DateTime? LoadDate { get; set; }

        DateTime? UpdateDate { get; set; }

    }
}
