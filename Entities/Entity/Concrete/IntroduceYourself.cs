using Entities.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity.Concrete
{
    public class IntroduceYourself:BaseEntity
    {
        public string? PresentMainTitle { get; set; }
        public string? PresentTitle { get; set; }
        public string? PresentText { get; set; }
    }
}
