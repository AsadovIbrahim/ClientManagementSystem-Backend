namespace ClientManagementSystem.BL.DTOs.ClientGroup
{
    public class ClientGroupTreeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ClientGroupTreeDTO> Children { get; set; } = new();
    }
}
