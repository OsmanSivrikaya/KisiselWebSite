using Core.Repository.Abstract;
using Entities.Entity.Concrete;
using Service.Services.Abstract;

namespace Service.Services.Concrete
{
    public class PersonalDataService : GenericService<PersonalData>, IPersonalDataService
    {
        private readonly IPersonalDataRepository _personalDataRepository;
        public PersonalDataService(IGenericRepository<PersonalData> repository, IPersonalDataRepository personalDataRepository) : base(repository)
        {
            _personalDataRepository = personalDataRepository;
        }
    }
}
