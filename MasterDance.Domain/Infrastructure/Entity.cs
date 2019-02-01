namespace MasterDance.Domain.Infrastructure
{
    public class Entity
    {
        public int Id { get; set; }
        public bool IsNew => Id == 0;
    }
}