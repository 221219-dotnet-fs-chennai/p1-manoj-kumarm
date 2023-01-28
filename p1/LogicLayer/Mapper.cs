using DataFluentApi;
using DataFluentApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogicLayer
{
    /// <summary>
    /// We are using Mapper class to convert Models to Entity Models
    /// </summary>
    public class Mapper
    {
        private static TrainersDbContext context = new TrainersDbContext();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static int MapGetTrainerIdByEmail(string email)
        {
            try
            {
                int id = 0;
                var t = context.TrainerDetails.Where(item => item.Email == email).First();
                if (t.Email == email)
                {
                    id = t.Trainerid;
                }
                return id;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("");
            }
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool MapExistingTrainer(DataFluentApi.Entities.TrainerDetail t)
        {
            try
            {
                var trainer = context.TrainerDetails.Where(item => item.Email == t.Email).First();
                if(trainer.Email == t.Email && trainer.Password == t.Password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        public static void MapAddTrainerSignUp(DataFluentApi.Entities.TrainerDetail t)
        {
            try
            {
                context.Add(t);
                context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool MapTrainerId(int i)
        {
            try
            {
                var t = context.TrainerDetails.Where(item => item.Trainerid == i).First();
                if (t.Trainerid == i)
                {
                    return true;
                }
                else if (t.Trainerid != i)
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("");
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool MapTrainerEmail(string email) {
            try {
                var t = context.TrainerDetails.Where(item => item.Email == email).First();
                if (t.Email == email)
                {
                    return true;
                }
                else if (t.Email != email || t.Email == null)
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch (InvalidOperationException e) {
                Console.WriteLine(e.Message);
            }
            return false;
        }
        
        /// <summary>
        /// This method converts Models TrainerDetails object to EF TrainerDetails Entity
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Models.TrainerDetail Map(DataFluentApi.Entities.TrainerDetail t)
        {
            return new Models.TrainerDetail()
            {
                Fullname= t.Fullname,
                Phone = t.Phone,
                Website = t.Website,
                Aboutme = t.Aboutme,
                Gender = t.Gender,
                Age = t.Age,
                Trainerid = t.Trainerid,
                Email = t.Email,
                Password = t.Password,
            };
        }

        /// <summary>
        /// This method converts Models collection of TrainerDetail object to EF collection of TrainerDetail Entity
        /// </summary>
        /// <param name="trainers"></param>
        /// <returns></returns>
        public static IEnumerable<Models.TrainerDetail> Map(IEnumerable<DataFluentApi.Entities.TrainerDetail> trainers) {
            try
            {
                return trainers.Select(Map);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            return trainers.Select(Map);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainer"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public static IEnumerable<Models.TrainerDetail>Map(IEnumerable<DataFluentApi.Entities.TrainerDetail> trainer, int i, int j)
        {
            var query = from t in trainer
                        where Convert.ToInt32(t.Age) >= i && Convert.ToInt32(t.Age) <= j
                        select t;
            return query.Select(Map);
        }
    }
}
