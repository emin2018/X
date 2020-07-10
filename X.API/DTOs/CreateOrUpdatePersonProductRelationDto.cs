using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace X.API.DTOs
{
    public class CreateOrUpdatePersonProductRelationDto
    {
        public int Id { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
