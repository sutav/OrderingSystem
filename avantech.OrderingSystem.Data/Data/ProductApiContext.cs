using avantech.OrderingSystem.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avantech.OrderingSystem.Data.Data
{
    public partial class ProductApiContext : DbContext
    {
        public ProductApiContext()
        {
        }

        public ProductApiContext(DbContextOptions<ProductApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Model.Product> Products { get; set; }      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.Product>(entity =>
            {
                entity.HasKey(e => e.ProductId).HasName("PK_Products");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        static partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
