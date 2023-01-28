using Models;
using ef = DataFluentApi;

namespace LogicLayer
{
    public class Logic : ILogic
    {
        IRepo<ef.Entities.TrainerDetail> _repo;
        Models.TrainerDetail _data = new();
        public Logic()
        {
            _repo = new ef.EFRepo();
        }

        public int GetTrainerIdByEmail(string str)
        {
            return Mapper.MapGetTrainerIdByEmail(_repo.GetId(str));
        }
        public bool CheckTrainerExists(ef.Entities.TrainerDetail t)
        {
            return Mapper.MapExistingTrainer(_repo.IsTrainerExists(t));
        }
        public void AddTrainerSignUp(ef.Entities.TrainerDetail t)
        {
            Mapper.MapAddTrainerSignUp(_repo.Add(t));
        }
        public bool CheckIdExists(int i) {
            return Mapper.MapTrainerId(_repo.IsIdExists(i));
        }
        public bool CheckEmailExists(string str)
        {
            return Mapper.MapTrainerEmail(_repo.IsEmailExists(str));
        }
        public IEnumerable<Models.TrainerDetail> GetTrainerByAge(int i, int j) {
            return Mapper.Map(_repo.SearchByFilters(), i, j);
        }
        public IEnumerable<Models.TrainerDetail> GetTrainerDetails()
        {
            return Mapper.Map(_repo.GetAll());
        }

        
    }
}