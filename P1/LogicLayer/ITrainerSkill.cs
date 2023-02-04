namespace LogicLayer
{
    public interface ITrainerSkill
    {
        void AddTrainerSkill(Models.TrainerSkills _data);
        void UpdateTrainerSkill(Models.TrainerSkills _data, string str);
        void DeleteTrainerskill(Models.TrainerSkills _data);
        IEnumerable<Models.TrainerSkills> GetTrainerSkills(int id);
    }
}
