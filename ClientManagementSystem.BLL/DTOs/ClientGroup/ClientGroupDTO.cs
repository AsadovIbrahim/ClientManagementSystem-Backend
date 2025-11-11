namespace ClientManagementSystem.BL.DTOs.ClientGroup
{
    public class ClientGroupDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Code { get; set; }
        public string? Comment { get; set; }
        public Guid? ParentGroupId { get; set; }
        public string? ParentName { get; set; } 
    }
}
