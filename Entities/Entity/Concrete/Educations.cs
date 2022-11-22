using Entities.Entity.Abstract;

namespace Entities.Entity.Concrete
{
    public class Educations : BaseEntity
    {
        public string? EducationDate { get; set; }
        public string? EducationTitle { get; set; }
        public string? EducationText { get; set; }
        public bool? MainPageVisibility { get; set; }
    }
}
