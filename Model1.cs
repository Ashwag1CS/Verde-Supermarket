using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Verde_Supermarket
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<carts> carts { get; set; }
        public virtual DbSet<customer> customer { get; set; }
        public virtual DbSet<manager> manager { get; set; }
        public virtual DbSet<product> product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
