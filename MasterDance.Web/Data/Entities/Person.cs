namespace MasterDance.Web.Data.Entities
{
    public class Person : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Contact Contact { get; set; }
        public Gender Gender { get; set; }
    }
}