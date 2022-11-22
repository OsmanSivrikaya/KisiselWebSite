using Entities.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity.Concrete
{
    public class Skills : BaseEntity
    {
        public string? SkillName { get; set; }
        public int? SkillPoints { get; set; }
        public bool? MainPageVisibility { get; set; }
    }
}
