
namespace DataFluentApi
{
    public interface ITrainerEducationEFRepo
    {
        /// <summary>
        /// inserts data into trainer education table
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_data"></param>
        void AddTrainerEducation(int id, DataFluentApi.Entities.TrainerEducation _data);

        /// <summary>
        /// updates the data in the education table
        /// </summary>
        /// <param name="_data"></param>
        void UpdateTrainerEducation(DataFluentApi.Entities.TrainerEducation _data);

        /// <summary>
        /// deletes one education detail
        /// </summary>
        /// <param name="i"></param>
        /// <param name="educationName"></param>
        void DeleteTrainerEducation(int id, string educationName);

    }
}
