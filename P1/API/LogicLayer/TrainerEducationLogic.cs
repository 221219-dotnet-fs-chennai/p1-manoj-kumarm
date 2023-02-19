using DataFluentApi;
using Models;

namespace LogicLayer
{
    public class TrainerEducationLogic : ITrainerEducationLogic
    {
        private readonly ITrainerEducationEFRepo _repo;
        private readonly Utility _Utility;
        public TrainerEducationLogic (ITrainerEducationEFRepo repo, Utility utility)
        {
            _repo = repo;
            _Utility = utility;
        }
        public string AddTrainerEducation(string email, AddTrainerEducation _data)
        {
            int id = _Utility.GetTrainerIdByEmail(email);
            if (_Utility.CheckIdExists(id))
            {
                if (!_Utility.ReachedMaxEducationCount(id))
                {
                    _repo.AddTrainerEducation(id, Mapper.Map(_data));
                    return $"{_data}";
                }
                else
                {
                    return "max";
                }
            }

            else
            {
                return "-1";
            }
        }

        public string DeleteTrainerEducation(string email, string eduname)
        {
            if (_Utility.CheckIdExists(_Utility.GetTrainerIdByEmail(email)))
            {
                _repo.DeleteTrainerEducation(_Utility.GetTrainerIdByEmail(email), eduname);
                return $"{eduname}";
            }
            else
            {
                return "-1";
            }
        }

        public string UpdateTrainerEducation(string email, string eduname, UpdateTrainerEducation _data)
        {
            if (_Utility.CheckIdExists(_Utility.GetTrainerIdByEmail(email)))
            {
                DataFluentApi.Entities.TrainerEducation t;
                t = _Utility.CheckForNullsAndUpdate(_Utility.GetTrainerIdByEmail(email), eduname, _data);
                _repo.UpdateTrainerEducation(t);
                return $"{_data}";
            }
            else return "-1";
        }
    }
}
