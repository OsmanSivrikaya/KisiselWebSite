using Core.Repository.Abstract;
using Entities.Entity.Concrete;
using Microsoft.Extensions.Configuration;

namespace Core.Repository.Concrete
{
    public class LanguagesRepository : GenericRepository<Languages>, ILanguagesRepository
    {
        public LanguagesRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
