using Microsoft.EntityFrameworkCore;
using Models;

namespace LogicLayer
{
    public class TrainerSkillLogic : ITrainerSkill
    {
        private static DataFluentApi.Entities.TrainersDbContext _context = new();
        Models.IRepo<DataFluentApi.Entities.TrainerSkill> _repo = new DataFluentApi.TrainerSkillEFRepo();
        public void AddTrainerSkill(TrainerSkills _data)
        {
            try
            {
                if (_data != null)
                {
                    _context.Add(Mapper.Map(_data));
                    _context.SaveChanges();
                }
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine("");
            }
        }

        public void DeleteTrainerskill(TrainerSkills _data)
        {
            try
            {
                var s = _context.TrainerSkills.Where(item=>item.Trainerskillid == _data.Trainerskillid && item.Skill == _data.Skill).First();
                if(s != null)
                {
                    _context.Remove(s);
                    _context.SaveChanges();
                }

            }
            catch (DbUpdateException e)
            {
                Console.WriteLine("");
            }
        }

        public void UpdateTrainerSkill(TrainerSkills _data, string oldSkill)
        {
            try
            {
                DataFluentApi.Entities.TrainerSkill t;
                t = Utility.CheckForNullsAndUpdate(_data, oldSkill);
                _context.Update(t);
                _context.SaveChanges();

            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine();
            }
            catch (DbUpdateException e) {
                Console.WriteLine();
            }
        }

        public IEnumerable<Models.TrainerSkills> GetTrainerSkills(int id)
        {
            return Mapper.Map(_repo.GetAll(), id);
        }
    }
}
