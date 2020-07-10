using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace X.API.DTOs
{
    public class PersonDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(11)]
        public string IdentificationNumber { get; set; }
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        public string Surname { get; set; }
        [Required]
        [MinLength(2)]
        public string PhoneNumber { get; set; }
        [Required]
        [MinLength(2)]
        public string MailAddress { get; set; }
    }
}
