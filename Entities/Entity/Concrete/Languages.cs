using Entities.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity.Concrete
{
    public class Languages : BaseEntity
    {
        public string? LanguagesName { get; set; }
        public int? LanguagesPoints { get; set; }
        public bool? MainPageVisibility { get; set; }
    }
}
