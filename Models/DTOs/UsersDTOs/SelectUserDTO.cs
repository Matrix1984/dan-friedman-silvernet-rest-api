namespace Models.DTOs.UsersDTOs
{
    public class SelectUserDTO
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
