using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.TenantsDTOs
{
    public class UpdateTenantDTO
    {
        [RegularExpression(@"^([A-Za-z]+)$")]
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Phone]
        [Required]
        public string Phone { get; set; } 
    }
}
