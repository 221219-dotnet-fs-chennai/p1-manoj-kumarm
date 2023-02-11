namespace LogicLayer
{
    public interface ITrainerSkillLogic
    {
        /// <summary>
        /// calls add method from EFRepo
        /// </summary>
        /// <param name="_data"></param>
        string AddTrainerSkill(string email, Models.UpdateTrainerSkill _data);

        /// <summary>
        /// calls update method from EFRepo
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="str"></param>
        string UpdateTrainerSkill(string email, Models.UpdateTrainerSkill _data, string oldskill);

        /// <summary>
        /// calls delete method from EFRepo
        /// </summary>
        /// <param name="str"></param>
        /// <param name="i"></param>
        string DeleteTrainerskill(string email, string skillname);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<Models.TrainerSkills> GetTrainerSkills(int id);
    }
}
