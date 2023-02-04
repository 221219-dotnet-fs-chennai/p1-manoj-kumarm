using DataFluentApi.Entities;
using Models;

namespace DataFluentApi
{
    public class TrainerSkillEFRepo : IRepo<Entities.TrainerSkill>
    {
        TrainersDbContext _context = new();
        public List<TrainerSkill> GetAll(int i)
        {
            return _context.TrainerSkills.ToList();
        }

        public IEnumerable<TrainerSkill> SearchByFilters()
        {
            return _context.TrainerSkills.ToList();
        }
    }
}
