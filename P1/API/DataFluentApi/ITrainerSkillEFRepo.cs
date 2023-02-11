using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFluentApi
{
    public interface ITrainerSkillEFRepo
    {
        /// <summary>
        /// Adding skills into the database
        /// </summary>
        /// <param name="_data"></param>
        void AddTrainerSkills(int id, DataFluentApi.Entities.TrainerSkill _data);

        /// <summary>
        /// Updates the existing values
        /// </summary>
        /// <param name="_data"></param>
        void UpdateTrainerSkills(DataFluentApi.Entities.TrainerSkill _data);

        /// <summary>
        /// Removes the skill specified
        /// </summary>
        /// <param name="_data"></param>
        void DeleteTrainerSkill(string email, int i);

        /// <summary>
        /// Gets all skills for a specific user
        /// </summary>
        /// <param name="_data"></param>
        /// <returns></returns>
        IEnumerable<DataFluentApi.Entities.TrainerSkill> GetAllTrainerSkill(int i);
    }
}
