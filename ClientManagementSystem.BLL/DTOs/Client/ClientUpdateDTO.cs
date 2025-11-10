namespace ClientManagementSystem.BL.DTOs.Client
{
    public class ClientUpdateDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int? Code { get; set; }
        public string? Comment { get; set; }
        public Guid ClientGroupId { get; set; }
    }
}
