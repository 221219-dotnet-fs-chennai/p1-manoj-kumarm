using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface ITrainerLocationLogic
    {
        /// <summary>
        /// calls add method from the EFRepo
        /// </summary>
        /// <param name="_data"></param>
        string AddTrainerLocation(string email, Models.EditTrainerLocation _data);

        /// <summary>
        /// calls update method from the EFRepo
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="i"></param>
        string UpdateTrainerLocation(Models.EditTrainerLocation _data, string email);

        /// <summary>
        /// calls delete method from the EFRepo
        /// </summary>
        /// <param name="_data"></param>
        string DeleteTrainerLocation(string email);

    }
}
