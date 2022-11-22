using Core.Repository.Abstract;
using Entities.Entity.Concrete;
using Microsoft.Extensions.Configuration;

namespace Core.Repository.Concrete
{
    public class ExperiencesRepository : GenericRepository<Experiences>, IExperiencesRepository
    {
        public ExperiencesRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
