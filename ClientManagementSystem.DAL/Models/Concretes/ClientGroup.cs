using ClientManagementSystem.DAL.Models.Common;

namespace ClientManagementSystem.DAL.Models.Concretes
{
    public class ClientGroup : BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public string Comment { get; set; }

        //Hierarchical Relationship
        public Guid? ParentGroupId { get; set; }

        //Navigation Property
        public virtual ClientGroup ParentGroup { get; set; }
        public virtual ICollection<ClientGroup> ChildGroups { get; set; } = new List<ClientGroup>();
        public virtual ICollection<Client> Clients { get; set; }

    }
}
