using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.UsersDTOs
{
    public class UpdateUserDTO
    {
        [RegularExpression(@"^([A-Za-z]+)$")]
        [Required]
        public string FirstName { get; set; }

        [RegularExpression(@"^([A-Za-z]+)$")]
        [Required]
        public string LastName { get; set; }

        [Phone]
        [Required]
        public string Phone { get; set; }

        [Email]
        [Required]
        public string Email { get; set; } 
    }
}
