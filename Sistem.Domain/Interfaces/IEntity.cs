namespace Sistem.Domain.Interfaces
{
    public interface IEntity : IValidator
    {
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
