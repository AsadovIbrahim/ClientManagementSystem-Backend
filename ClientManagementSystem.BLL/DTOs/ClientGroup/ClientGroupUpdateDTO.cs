namespace ClientManagementSystem.BL.DTOs.ClientGroup
{
    public class ClientGroupUpdateDTO
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }
        public int? Code { get; set; }
        public string? Comment { get; set; }
    }
}
