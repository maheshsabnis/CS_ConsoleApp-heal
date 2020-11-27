using System.Data.Entity;

namespace MVC_Complete_App.Models
{
    /// <summary>
    /// We will get DbContext from EntityFramework and EntityFramework.SqlServer assemblies 
    /// these are added because the project is created using
    /// Individual User Accounts
    /// </summary>
    public class RHealDbContext : DbContext
    {
        /// <summary>
        /// Constructor that will read the Connection string from the Wen.Config file
        /// </summary>
        public RHealDbContext():base("name=RHealDbConnection")
        {
        }

        // define DbSet<T> for Categories and Products
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Create Tables mapped with Model classes or entity classes 
        /// used through the DbSet<T> poroperties e.g. Categories and Products
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}