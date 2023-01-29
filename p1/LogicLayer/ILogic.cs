namespace LogicLayer
{
    public interface ILogic
    {
        void DeleteTrainerDetails(Models.TrainerDetail _data);
        /// <summary>
        /// Insertes data into the TrainerDetails table in the Db
        /// </summary>
        /// <param name="_data"></param>
        void AddTrainerSignUp(Models.TrainerDetail _data);

        /// <summary>
        /// Updates the existing data present in the TrainerDetails table in the Db
        /// </summary>
        /// <param name="_data"></param>
        void UpdateTrainerDetails(Models.TrainerDetail _data);

        /// <summary>
        /// Used to fetch details of all the trainers
        /// </summary>
        /// <returns>Collection of objects which are iteratable</returns>
        IEnumerable<Models.TrainerDetail> GetTrainerDetails();

        /// <summary>
        /// Used to fetch details of all the trainers by age
        /// </summary>
        /// <param name="i">Starting age</param>
        /// <param name="j">Ending age</param>
        /// <returns>Collection of objects which are iteratable</returns>
        IEnumerable<Models.TrainerDetail> GetTrainerByAge(int i, int j);
    }
}
