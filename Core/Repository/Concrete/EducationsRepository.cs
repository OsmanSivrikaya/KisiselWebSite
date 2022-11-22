using Core.Repository.Abstract;
using Entities.Entity.Concrete;
using Microsoft.Extensions.Configuration;

namespace Core.Repository.Concrete
{
    public class EducationsRepository : GenericRepository<Educations> , IEducationsRepository
    {
        public EducationsRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
