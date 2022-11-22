using Core.Repository.Abstract;
using Entities.Entity.Concrete;
using Service.Services.Abstract;

namespace Service.Services.Concrete
{
    public class ExperiencesService : GenericService<Experiences>, IExperiencesService
    {
        private readonly IExperiencesRepository _experiencesRepository;
        public ExperiencesService(IGenericRepository<Experiences> repository, IExperiencesRepository experiencesRepository) : base(repository)
        {
            _experiencesRepository = experiencesRepository;
        }
    }
}
