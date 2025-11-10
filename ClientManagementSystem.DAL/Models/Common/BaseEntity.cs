namespace ClientManagementSystem.DAL.Models.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedAt { get; set; } = DateTime.UtcNow;
    }
}
