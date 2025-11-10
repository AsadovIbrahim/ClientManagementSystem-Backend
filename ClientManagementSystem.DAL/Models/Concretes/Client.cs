using ClientManagementSystem.DAL.Models.Common;
using ClientManagementSystem.DAL.Models.Concretes;

public class Client : BaseEntity
{
    public string Name { get; set; }
    public int Code { get; set; }
    public string Comment { get; set; }

    // Foreign Key 
    public Guid ClientGroupId { get; set; }

    // Navigation Property
    public virtual ClientGroup ClientGroup { get; set; }
}