namespace LogicLayer
{
    public interface ITrainerDetailLogic
    {
        /// <summary>
        /// Fetchs all the details for a specific user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> List<Models.All> </returns>
        IEnumerable<Models.All> GetTrainerById(int id);

        /// <summary>
        /// Removes data from the trainerDetails table
        /// </summary>
        /// <param name="_data"></param>
        string DeleteTrainerDetails(Models.DeleteTrainer _data);
        /// <summary>
        /// Insertes data into the TrainerDetails table in the Db
        /// </summary>
        /// <param name="_data"></param>
        string AddTrainerSignUp(Models.TrainerSingUp _data);

        /// <summary>
        /// Updates the existing data present in the TrainerDetails table in the Db
        /// </summary>
        /// <param name="_data"></param>
        string UpdateTrainerDetails(string email, Models.TrainerUpdate _data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        IEnumerable<Models.All> GetTrainerByAge(int i, int j);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Models.All> GetAllInfo();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Models.All> GetMe(string str);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int GetCount();

    }
}
