using System.Data.Entity;

namespace _1_Presentacion_MVC.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base("Entitys")
        {
        }

        public virtual DbSet<DimEmployee> DimEmployee { get; set; }

        public virtual DbSet<Countries> Countries { get; set; }

    }
}