namespace ClientManagementSystem.BL.DTOs.ClientGroup
{
    public class ClientGroupCreateDTO
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public string? Comment { get; set; }
        public Guid? ParentGroupId { get; set; }
    }

}
