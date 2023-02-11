namespace DataFluentApi
{
    public interface ITrainerLocationEFRepo
    {
        /// <summary>
        /// inserts data into the Location table in the database
        /// </summary>
        /// <param name="_data"></param>
        void AddTrainerLocation(int i, DataFluentApi.Entities.TrainerLocation _data);
        /// <summary>
        /// Updates the location table
        /// </summary>
        /// <param name="_data"></param>
        void UpdateTrainerLocation(DataFluentApi.Entities.TrainerLocation _data);
        /// <summary>
        /// deletes the location details of a specific user
        /// </summary>
        /// <param name="_data"></param>S
        void DeleteTrainerLocation(int i);
    }
}
