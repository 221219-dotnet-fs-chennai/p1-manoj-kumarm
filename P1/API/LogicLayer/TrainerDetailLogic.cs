using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models;

namespace LogicLayer
{
    public class TrainerDetailLogic : ITrainerDetailLogic
    {
        //private static DataFluentApi.Entities.TrainersDbContext context = new DataFluentApi.Entities.TrainersDbContext();
        private readonly DataFluentApi.ITrainerDetailEFRepo _repo;
        private readonly Utility _Utility;
        public TrainerDetailLogic(DataFluentApi.ITrainerDetailEFRepo repo, Utility util)
        {
            _repo = repo;
            _Utility = util;
        }
        
        public string DeleteTrainerDetails(Models.DeleteTrainer _data)
        {
            int i = _Utility.GetTrainerIdByEmail(_data.Email);
            return _repo.DeleteTrainerDetails(i, Mapper.Map(_data));
        }

        public string UpdateTrainerDetails(string email, Models.TrainerUpdate _data)
        {
            DataFluentApi.Entities.TrainerDetail t;
            int id = _Utility.GetTrainerIdByEmail(email);
            if(id.ToString().IsNullOrEmpty())
            {
                return "-1";
            }
            else
            {
                t = _Utility.CheckForNullsAndUpdate(id, _data);
                _repo.UpdateTrainerDetails(t);
                return "1";
            }
        }
        public string AddTrainerSignUp(Models.TrainerSingUp _data)
        {
            return _repo.AddTrainerSignUp(Mapper.Map(_data));
        }


        public IEnumerable<Models.All> GetTrainerByAge(int i, int j)
        {
            return _repo.GetTrainerByAge(i,j);
        }
        

        public IEnumerable<Models.All> GetAllInfo()
        {
            return _repo.GetAllInfo();
        }

        public IEnumerable<Models.All> GetTrainerById(int id) 
        {
            return _repo.GetTrainerById(id);
        }

        public IEnumerable<Models.All> GetMe(string email)
        {
            return _repo.GetMe(_Utility.GetTrainerIdByEmail(email));
        }

        public int GetCount()
        {
            return _repo.GetCount();
        }
    }
}