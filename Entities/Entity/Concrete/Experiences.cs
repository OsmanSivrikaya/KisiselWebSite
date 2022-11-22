using Entities.Entity.Abstract;

namespace Entities.Entity.Concrete
{
    public class Experiences : BaseEntity
    {
        public string? ExperienceDate { get; set; }
        public string? ExperienceTitle { get; set; }
        public string? ExperienceText { get; set; }
        public bool? MainPageVisibility { get; set; }
    }
}
