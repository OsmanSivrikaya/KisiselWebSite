using Core.Repository.Abstract;
using Entities.Entity.Concrete;
using Service.Services.Abstract;
namespace Service.Services.Concrete
{
    public class ExpertisesService : GenericService<Expertises>, IExpertisesService
    {
        private readonly IExpertisesRepository _expertisesRepository;
        public ExpertisesService(IGenericRepository<Expertises> repository, IExpertisesRepository expertisesRepository) : base(repository)
        {
            _expertisesRepository = expertisesRepository;
        }
    }
}
