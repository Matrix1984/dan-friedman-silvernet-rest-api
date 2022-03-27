using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.UsersDTOs
{
    public class CreateUserDTO
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

        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
