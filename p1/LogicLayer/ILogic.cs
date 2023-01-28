using Models;

namespace LogicLayer
{
    public interface ILogic
    {
        int GetTrainerIdByEmail(string str);
        bool CheckTrainerExists(DataFluentApi.Entities.TrainerDetail t);
        void AddTrainerSignUp(DataFluentApi.Entities.TrainerDetail t);
        bool CheckIdExists(int i);
        bool CheckEmailExists(string str);
        IEnumerable<Models.TrainerDetail> GetTrainerByAge(int i, int j);
        IEnumerable<Models.TrainerDetail> GetTrainerDetails();
        
    }
}
