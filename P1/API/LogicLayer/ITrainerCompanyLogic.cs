
namespace LogicLayer
{
    public interface ITrainerCompanyLogic
    {
        /// <summary>
        /// calls add method from EFRepo
        /// </summary>
        /// <param name="_data"></param>
        string AddTrainerCompany(string email, Models.AddTrainerCompany _data);

        /// <summary>
        /// calls update method form EFRepo
        /// </summary>
        /// <param name="_data"></param>
        string UpdateTrainerCompany(string email,string companyname, Models.UpdateTrainerCompany _data);

        /// <summary>
        /// calls delete method from EFRepo
        /// </summary>
        /// <param name="_data"></param>
        string DeleteTrainerCompany(string email, string name);
    }
}