using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_InterfazComun.Constantes
{
    public class Constantes
    {
        #region "Url's de API's"

        //public const string urlServiciosInternos = "http://localhost:63929/";

        public const string urlServiciosInternos = "http://test-api-prueba.azurewebsites.net/";

        public const string apiEmployees = "/api/DimEmployees";

        public const string urlDimEmployees = urlServiciosInternos + "api/DimEmployees";

        public const string urlAllCountries = "https://restcountries.eu/rest/v2/all";

        #endregion
    }
}
