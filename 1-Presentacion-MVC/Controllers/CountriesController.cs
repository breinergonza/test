using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using _1_Presentacion_MVC.Models;
using _1_Presentacion_MVC.WebClient;


namespace _1_Presentacion_MVC.Controllers
{
    public class CountriesController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {

            List<Countries> resp = await CountriesClient.GetCountriesAsync();

            return View(resp);
        }
      
    }
}