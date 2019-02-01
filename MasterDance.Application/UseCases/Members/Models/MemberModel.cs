namespace MasterDance.Application.UseCases.Members.Models
{
    public class MemberModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public int? MemberGroupId { get; set; }
    }
}