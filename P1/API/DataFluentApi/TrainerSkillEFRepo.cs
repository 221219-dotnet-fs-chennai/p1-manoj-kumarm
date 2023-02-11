using DataFluentApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models;

namespace DataFluentApi
{
    public class TrainerSkillEFRepo : ITrainerSkillEFRepo
    {
        private readonly DataFluentApi.Entities.TrainersDbContext _context;
        public TrainerSkillEFRepo(DataFluentApi.Entities.TrainersDbContext context)
        {
            _context = context;
        }

        public void AddTrainerSkills(int id, TrainerSkill _data)
        {
            try
            {
                if (_data != null)
                {
                    
                    _data.Trainerskillid = id;
                    _context.Add(_data);
                    _context.SaveChanges();
                }
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DeleteTrainerSkill(string skill, int id)
        {
            try
            {
                var s = _context.TrainerSkills.Where(item => item.Trainerskillid == id && item.Skill == skill).First();
                if (s != null)
                {
                    _context.Remove(s);
                    _context.SaveChanges();
                }

            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public IEnumerable<TrainerSkill> GetAllTrainerSkill(int id)
        {
            try
            {
                var skills = _context.TrainerSkills;
                var query = (from t in skills
                            where t.Trainerskillid == id
                            orderby t.Skill
                            select t).Take(3);
                return query.ToList();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public void UpdateTrainerSkills(TrainerSkill _data)
        {
            try
            {
                _context.Update(_data);
                _context.SaveChanges();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
