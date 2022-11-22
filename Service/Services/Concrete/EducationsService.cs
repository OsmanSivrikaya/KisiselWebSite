using Core.Repository.Abstract;
using Entities.Entity.Concrete;
using Service.Services.Abstract;

namespace Service.Services.Concrete
{
    public class EducationsService : GenericService<Educations>, IEducationsService
    {
        private readonly IEducationsRepository _educationsRepository;
        public EducationsService(IGenericRepository<Educations> repository, IEducationsRepository educationsRepository) : base(repository)
        {
            _educationsRepository = educationsRepository;
        }
    }
}
