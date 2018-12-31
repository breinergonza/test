
using System.ComponentModel.DataAnnotations;

namespace _1_Presentacion_MVC.Models
{
    public class Currency
    {
        [Key]
        public int id { get; set; }

        public string code { get; set; }

         public string name { get; set; }
         
         public string symbol { get; set; }

    }
}