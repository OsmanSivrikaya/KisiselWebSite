using Core.Repository.Abstract;
using Entities.Entity.Concrete;
using Microsoft.Extensions.Configuration;

namespace Core.Repository.Concrete
{
    public class IntroduceYourselfRepository : GenericRepository<IntroduceYourself>, IIntroduceYourselfRepository
    {
        public IntroduceYourselfRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
