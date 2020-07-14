using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace X.Web.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        public string Description { get; set; }
        [Range(0.01,10000000000)]
        public decimal Price { get; set; }
    }
}
