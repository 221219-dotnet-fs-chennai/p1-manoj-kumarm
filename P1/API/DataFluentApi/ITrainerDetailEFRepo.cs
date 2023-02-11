namespace DataFluentApi
{
    public interface ITrainerDetailEFRepo
    {
        string UpdateTrainerDetails(DataFluentApi.Entities.TrainerDetail _data);
        /// <summary>
        /// Removes data from the trainerDetails table
        /// </summary>
        /// <param name="_data"></param>
        string DeleteTrainerDetails(int i, DataFluentApi.Entities.TrainerDetail _data);

        /// <summary>
        /// Adding signup details
        /// </summary>
        /// <param name="_data"></param>
        string AddTrainerSignUp(DataFluentApi.Entities.TrainerDetail _data);

        /// <summary>
        /// Gets the total number of users present in the database
        /// </summary>
        /// <returns></returns>
        int GetCount();

        /// <summary>
        /// Used to fetch all the user details by age
        /// </summary>
        /// <returns>Generic collection which can be iterated</returns>
        IEnumerable<Models.All> GetTrainerByAge(int i, int j);

        /// <summary>
        /// Used to fetch all the user details
        /// </summary>
        /// <returns></returns>
        IEnumerable<Models.All> GetAllInfo();

        /// <summary>
        /// Used to fetch all the user details of a specific user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<Models.All> GetTrainerById(int id);

        /// <summary>
        /// Used to fetch all the user details of a current user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<Models.All> GetMe(int id);
    }
}