using System.ComponentModel.DataAnnotations;

namespace _1_Presentacion_MVC.Models
{
    public class Language
    {
        [Key]
        public int id { get; set; }

        public string iso639_1 { get; set; }
           
        public string iso639_2 { get; set; }

        public string name { get; set; }

        public string nativeName { get; set; }
    }
}