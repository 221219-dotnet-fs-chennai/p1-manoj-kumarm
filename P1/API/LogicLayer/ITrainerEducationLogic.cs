using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface ITrainerEducationLogic
    {
        /// <summary>
        /// calls add method from EFRepo
        /// </summary>
        /// <param name="email"></param>
        /// <param name="_data"></param>
        /// <returns></returns>
        string AddTrainerEducation(string email, Models.AddTrainerEducation _data);

        /// <summary>
        /// calls update method from EFRepo
        /// </summary>
        /// <param name="email"></param>
        /// <param name="eduname"></param>
        /// <param name="_data"></param>
        /// <returns></returns>
        string UpdateTrainerEducation(string email, string eduname,Models.UpdateTrainerEducation _data);

        /// <summary>
        /// calls delete method from EFRepo
        /// </summary>
        /// <param name="email"></param>
        /// <param name="eduname"></param>
        /// <returns></returns>
        string DeleteTrainerEducation(string email, string eduname);
    }
}
