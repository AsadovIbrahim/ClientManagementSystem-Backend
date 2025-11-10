using ClientManagementSystem.DAL.Models.Common;

namespace ClientManagementSystem.DAL.Models.Concretes
{
    public class ClientGroup:BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public string Comment { get; set; }

        //Navigation Property
        public virtual ICollection<Client> Clients { get; set; }

    }
}
