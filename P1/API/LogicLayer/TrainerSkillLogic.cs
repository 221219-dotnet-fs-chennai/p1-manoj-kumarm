using DataFluentApi;
using DataFluentApi.Entities;
using Microsoft.EntityFrameworkCore;
using Models;

namespace LogicLayer
{
    public class TrainerSkillLogic : ITrainerSkillLogic
    {
        private readonly DataFluentApi.Entities.TrainersDbContext _context;
        private readonly ITrainerSkillEFRepo _repo;
        private readonly Utility _Utility;

        public TrainerSkillLogic(TrainersDbContext context, ITrainerSkillEFRepo repo, Utility utility)
        {
            _context = context;
            _repo = repo;
            _Utility = utility;
        }

        public string AddTrainerSkill(string email, Models.UpdateTrainerSkill _data)
        {
            if(_Utility.CheckSkillExists(_Utility.GetTrainerIdByEmail(email), _data)){
                if (!_Utility.ReachedMaxSkillCount(_Utility.GetTrainerIdByEmail(email)))
                {
                    _repo.AddTrainerSkills(_Utility.GetTrainerIdByEmail(email), Mapper.Map(_data));
                    return "1";
                }
                else
                {
                    return "data must be unique";
                }
            }
            else
            {
                return "-1";
            }
        }

        public string DeleteTrainerskill(string email, string skillname)
        {
            if (_Utility.CheckIdExists(_Utility.GetTrainerIdByEmail(email)))
            {
                _repo.DeleteTrainerSkill(skillname, _Utility.GetTrainerIdByEmail(email));
                return "1";
            }
            else
            {
                return "-1";
            }
        }

        public string UpdateTrainerSkill(string email, Models.UpdateTrainerSkill _data, string oldSkill)
        {
            if (_Utility.CheckIdExists(_Utility.GetTrainerIdByEmail(email)))
            {
                DataFluentApi.Entities.TrainerSkill t;
                t = _Utility.CheckForNullsAndUpdate(_Utility.GetTrainerIdByEmail(email),_data, oldSkill);
                _repo.UpdateTrainerSkills(t);
                return $"{_data.Skill}";
            }
            else
            {
                return "-1";
            }
        }

        public IEnumerable<Models.TrainerSkills> GetTrainerSkills(int id)
        {
            return Mapper.Map(_repo.GetAllTrainerSkill(id));
        }
    }
}
