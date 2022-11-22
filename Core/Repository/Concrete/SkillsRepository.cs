using Core.Repository.Abstract;
using Entities.Entity.Concrete;
using Microsoft.Extensions.Configuration;

namespace Core.Repository.Concrete
{
    public class SkillsRepository : GenericRepository<Skills>, ISkillsRepository
    {
        public SkillsRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
