using Entities.Entity.Abstract;

namespace Entities.Entity.Concrete
{
    public class Expertises : BaseEntity
    {
        public string? ExpertiseTitle { get; set; }
        public string? ExpertiseText { get; set; }
        public string? ExpertiseIcon { get; set; }
    }
}
