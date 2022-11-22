using Core.Repository.Abstract;
using Entities.Entity.Concrete;
using Microsoft.Extensions.Configuration;

namespace Core.Repository.Concrete
{
    public class ExpertisesRepository : GenericRepository<Expertises>, IExpertisesRepository
    {
        public ExpertisesRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
