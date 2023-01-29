using DataFluentApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogicLayer
{
    public class Utility
    {
        internal static readonly int MaxCount = 2;
        private static TrainersDbContext context = new TrainersDbContext();

        /// <summary>
        /// Updates only the specified column in the Db
        /// </summary>
        /// <param name="_data"></param>
        /// <returns>Object of type DataFluentApi.Entities.TrainerDetail</returns>
        public static DataFluentApi.Entities.TrainerDetail CheckForNullsAndUpdate(Models.TrainerDetail _data)
        {
            try
            {
                var trainer = context.TrainerDetails.Where(item => item.Trainerid == _data.Trainerid).First();
                if (trainer != null)
                {
                    if (trainer.Fullname != null && _data.Fullname == null)
                    {
                        trainer.Fullname = trainer.Fullname;
                    }
                    else
                    {
                        trainer.Fullname = _data.Fullname;
                    }
                    if (trainer.Phone != null && _data.Phone == null)
                    {
                        trainer.Phone = trainer.Phone;
                    }
                    else
                    {
                        trainer.Phone = _data.Phone;
                    }
                    if (trainer.Website != null && _data.Website == null)
                    {
                        trainer.Website = trainer.Website;
                    }
                    else
                    {
                        trainer.Website = _data.Website;
                    }
                    if (trainer.Aboutme != null && _data.Aboutme == null)
                    {
                        trainer.Aboutme = trainer.Aboutme;
                    }
                    else
                    {
                        trainer.Aboutme = _data.Aboutme;
                    }
                    if (trainer.Age != null && _data.Age == null)
                    {
                        trainer.Age = trainer.Age;
                    }
                    else
                    {
                        trainer.Age = _data.Age;
                    }
                    if (trainer.Gender != null && _data.Gender == null)
                    {
                        trainer.Gender = trainer.Gender;
                    }
                    else
                    {
                        trainer.Gender = _data.Gender;
                    }
                }
                return trainer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        
        /// <summary>
        /// Counts the number of records present in the table for a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if the number of records reached the maximum count else False</returns>
        public static bool ReachedMaxCount(int id) {
            int t = context.TrainerSkills.Where(item => item.Trainerskillid == id).Count();
            if (t <= MaxCount)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Checks if the given email already exists in the Db
        /// </summary>
        /// <param name="email"></param>
        /// <returns>True if email exists else False</returns>
        public static bool CheckEmailExists(string email)
        {
            try
            {
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
            catch (InvalidOperationException e)
            {
                Console.WriteLine("");
            }
            return false;
        }

        /// <summary>
        /// Checks if the given ID already exists in the Db 
        /// </summary>
        /// <param name="i"></param>
        /// <returns>True if the ID exists else False</returns>
        public static bool CheckIdExists(int i)
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
        /// Checks for existing user
        /// </summary>
        /// <param name="_data"></param>
        /// <returns>True if user exists else false</returns>
        public static bool CheckTrainerExists(Models.TrainerDetail _data)
        {
            try
            {
                var trainer = context.TrainerDetails.Where(item => item.Email == _data.Email).First();
                if (trainer.Email == _data.Email && trainer.Password == _data.Password)
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
        /// fetches trainer id using email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Trainer id</returns>
        public static int GetTrainerIdByEmail(string email)
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
        /// Used to generates a unique 4 digit number
        /// </summary>
        /// <returns>integer</returns>
        public static int GenerateRandomNo()
        {
            int _min = 1;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
    }
}
