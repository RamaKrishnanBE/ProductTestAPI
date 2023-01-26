using ProductTest.DomainObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTest.DomainObjects.Models
{

    [Table("Product")]
    public class Product : IProduct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Product name can't be longer than 50 characters")]
        [Column(TypeName = "VARCHAR")]
        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "Product Description can't be longer than 200 characters")]
        [Column(TypeName = "VARCHAR")]
        [Required(ErrorMessage = "Product name is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "MRP is required")]
        public decimal MRP { get; set; }

        [Required(ErrorMessage = "Buying Price is required")]
        public decimal BuyingPrice { get; set; }

        [Required(ErrorMessage = "Selling Price is required")]
        public decimal SellingPrice { get; set; }
        public bool IsActive { get; set; } = true;

        [StringLength(500, ErrorMessage = "Product Remarks can't be longer than 500 characters")]
        [Column(TypeName = "VARCHAR")]
        public string Remarks { get; set; }
    }
}
