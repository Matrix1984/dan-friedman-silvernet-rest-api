namespace Models.DTOs.TenantsDTOs
{
    public class SelectTenantDTO
    {
        public long TenantId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
