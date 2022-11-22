using Core.Repository.Abstract;
using Entities.Entity.Concrete;
using Service.Services.Abstract;
namespace Service.Services.Concrete
{
    public class IntroduceYourselfService : GenericService<IntroduceYourself>, IIntroduceYourselfService
    {
        private readonly IIntroduceYourselfRepository _introduceYourselfRepository;
        public IntroduceYourselfService(IGenericRepository<IntroduceYourself> repository, IIntroduceYourselfRepository introduceYourselfRepository) : base(repository)
        {
            _introduceYourselfRepository = introduceYourselfRepository;
        }
    }
}
