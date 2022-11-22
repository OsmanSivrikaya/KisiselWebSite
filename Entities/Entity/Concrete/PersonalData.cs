using Entities.Entity.Abstract;

namespace Entities.Entity.Concrete
{
    public class PersonalData : BaseEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Number { get; set; }
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }
        public string? Instagram { get; set; }
        public string? Github { get; set; }
        public string? Address { get; set; }
        public string? Birthdate { get; set; }
        public string? GoogleMapsLink { get; set; }
    }
}
