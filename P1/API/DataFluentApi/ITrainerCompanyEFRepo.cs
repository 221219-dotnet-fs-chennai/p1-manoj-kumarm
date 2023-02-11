namespace DataFluentApi
{
    public interface ITrainerCompanyEFRepo
    {
        /// <summary>
        /// Inserts data into the company table
        /// </summary>
        /// <param name="_data"></param>
        void AddTrainerCompany(int id, DataFluentApi.Entities.TrainerCompany _data);

        /// <summary>
        /// updates the data in the company table
        /// </summary>
        /// <param name="_data"></param>
        void UpdateTrainerCompany(DataFluentApi.Entities.TrainerCompany _data);

        /// <summary>
        /// Deletes the data specific to name and id
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="id"></param>
        void DeleteTrainerCompany(string name, int id);
    }
}
