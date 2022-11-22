using Core.Repository.Abstract;
using Entities.Entity.Concrete;
using Microsoft.Extensions.Configuration;

namespace Core.Repository.Concrete
{
    public class PersonalDataRepository : GenericRepository<PersonalData>, IPersonalDataRepository
    {
        public PersonalDataRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
