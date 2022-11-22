using Core.Repository.Abstract;
using Entities.Entity.Concrete;
using Service.Services.Abstract;

namespace Service.Services.Concrete
{
    public class SkillsService : GenericService<Skills>, ISkillsService
    {
        private readonly ISkillsRepository _skillsRepository;
        public SkillsService(IGenericRepository<Skills> repository, ISkillsRepository skillsRepository) : base(repository)
        {
            _skillsRepository = skillsRepository;
        }
    }
}
