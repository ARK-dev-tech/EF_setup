using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_setup.Model.Entities
{
    [Table("Product")]

    public class Product
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Column("product_name")]

        public string ProductName { get; set; }
        [Column("price")]

        public decimal Price { get; set; }
        [Column("stock")]

        public int Stock { get; set; }
        [Column("category")]

        public string Category { get; set; }
    }
}
