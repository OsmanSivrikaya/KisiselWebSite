using Core.Repository.Abstract;
using Entities.Entity.Concrete;
using Service.Services.Abstract;

namespace Service.Services.Concrete
{
    public class LanguagesService : GenericService<Languages>, ILanguagesService
    {
        private readonly ILanguagesRepository _languagesRepository;
        public LanguagesService(IGenericRepository<Languages> repository, ILanguagesRepository languagesRepository) : base(repository)
        {
            _languagesRepository = languagesRepository;
        }
    }
}
