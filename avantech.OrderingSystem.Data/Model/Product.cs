using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace avantech.OrderingSystem.Data.Model
{

    [Table("Product", Schema = "dbo")]
    [Index("ProductId", Name = "PK_Products")]
    public partial class Product
    {
        [Key]
        [StringLength(50)]
        [Unicode(false)]
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? ProductCategoryId { get; set; }
    }
}