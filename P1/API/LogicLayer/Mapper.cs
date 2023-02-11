using Models;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LogicLayer
{
    /// <summary>
    /// Used to convert Models to Entities and vice versa
    /// </summary>
    public class Mapper
    {
        internal static Utility _Utility;
        public Mapper(Utility util)
        {
            _Utility = util;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainers"></param>
        /// <returns></returns>

        
        public static IEnumerable<Models.TrainerSkills> Map(IEnumerable<DataFluentApi.Entities.TrainerSkill> skills, int id)
        {
            try
            {
                var query = from t in skills
                            where t.Trainerskillid == id
                            select t;
                return query.Select(Map);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        /// <summary>
        /// This method converts from Models TrainerCompany object to EF TrainerCompany Entity
        /// </summary>
        /// <param name="t"></param>
        /// <returns>EF TrainerCompany entity</returns>
        public static DataFluentApi.Entities.TrainerCompany Map(Models.AddTrainerCompany t)
        {
            return new DataFluentApi.Entities.TrainerCompany()
            {
                Companyname = t.Companyname,
                Title = t.Title,
                Startyear = t.Startyear,
                Endyear = t.Endyear,
            };
        }

        /// <summary>
        /// This method converts from Models TrainerCompany object to EF TrainerCompany Entity
        /// </summary>
        /// <param name="t"></param>
        /// <returns>EF TrainerCompany entity</returns>
        public static DataFluentApi.Entities.TrainerCompany Map(Models.TrainerCompany t)
        {
            return new DataFluentApi.Entities.TrainerCompany()
            {
                Id = t.Id,
                Companyname = t.Companyname,
                Title = t.Title,
                Startyear = t.Startyear,
                Endyear = t.Endyear,
                Trainercompanyid = t.Trainercompanyid
            };
        }

        /// <summary>
        /// This method converts from Models TrainerEducation object to EF TrainerEducation Entity
        /// </summary>
        /// <param name="t"></param>
        /// <returns>EF TrainerEducation entity</returns>
        public static DataFluentApi.Entities.TrainerEducation Map(Models.AddTrainerEducation t)
        {
            return new DataFluentApi.Entities.TrainerEducation()
            {
                Institute = t.Institute,
                Degreename = t.Degreename,
                Gpa = t.Gpa,
                Startdate = t.Startdate,
                Enddate = t.Enddate,
            };
        }

        /// <summary>
        /// This method converts from Models TrainerEducation object to EF TrainerEducation Entity
        /// </summary>
        /// <param name="t"></param>
        /// <returns>EF TrainerEducation entity</returns>
        public static DataFluentApi.Entities.TrainerEducation Map(Models.TrainerEducation t)
        {
            return new DataFluentApi.Entities.TrainerEducation()
            {
                Id = t.Id,
                Institute = t.Institute,
                Degreename = t.Degreename,
                Gpa = t.Gpa,
                Startdate = t.Startdate,
                Enddate = t.Enddate,
                Trainereducationid = t.Trainereducationid,
            };
        }

        /// <summary>
        /// This method converts from Models TrainerLocation object to EF TrainerLocation Entity
        /// </summary>
        /// <param name="t"></param>
        /// <returns>EF TrainerLocation entity</returns>
        public static DataFluentApi.Entities.TrainerLocation Map(Models.EditTrainerLocation t)
        {
            return new DataFluentApi.Entities.TrainerLocation()
            {
                City = t.City,
                Zipcode = t.Zipcode,
            };
        }

        /// <summary>
        /// This method converts from Models TrainerLocation object to EF TrainerLocation Entity
        /// </summary>
        /// <param name="t"></param>
        /// <returns>EF TrainerLocation entity</returns>
        public static DataFluentApi.Entities.TrainerLocation Map(Models.TrainerLocation t)
        {
            return new DataFluentApi.Entities.TrainerLocation()
            {
                Id = t.Id,
                City = t.City,
                Zipcode = t.Zipcode,
                Trainerlocationid = t.Trainerlocationid
            };
        }

        /// <summary>
        /// This method converts from Models TrainerSkill object to EF TrainerSkill Entity
        /// </summary>
        /// <param name="t"></param>
        /// <returns>EF TrainerSkill Entity</returns>
        public static DataFluentApi.Entities.TrainerSkill Map(Models.TrainerSkills t)
        {
            return new DataFluentApi.Entities.TrainerSkill()
            {
                Id = t.Id,
                Skill = t.Skill,
                Trainerskillid = t.Trainerskillid
            };
        }

        /// <summary>
        /// This method converts from Models TrainerSkill object to EF TrainerSkill Entity
        /// </summary>
        /// <param name="t"></param>
        /// <returns>EF TrainerSkill Entity</returns>
        public static DataFluentApi.Entities.TrainerSkill Map(Models.UpdateTrainerSkill t)
        {
            return new DataFluentApi.Entities.TrainerSkill()
            {
                Skill = t.Skill,
            };
        }

        /// <summary>
        /// This method converts from Models TrainerDetails object to EF TrainerDetails Entity
        /// </summary>
        /// <param name="t"></param>
        /// <returns>EF TrainerDetails Entity</returns>
        public static DataFluentApi.Entities.TrainerDetail Map(Models.TrainerDetail t)
        {
            return new DataFluentApi.Entities.TrainerDetail()
            {
                Fullname = t.Fullname,
                Phone = t.Phone,
                Website = t.Website,
                Aboutme = t.Aboutme,
                Gender  = t.Gender,
                Age = t.Age,
                Email= t.Email,
                Password = t.Password,
                Trainerid = t.Trainerid
            };
        }

        public static DataFluentApi.Entities.TrainerDetail Map(Models.TrainerSingUp t)
        {
            DataFluentApi.Entities.TrainerDetail trainer = new();
           /* int id = _Utility.GenerateRandomNo();
            if (!_Utility.CheckIdExists(id))
            {
                trainer.Trainerid = id;
            }*/
            trainer.Email = t.Email; 
            trainer.Password = t.Password;
            return trainer;
        }

        public static DataFluentApi.Entities.TrainerDetail Map(Models.DeleteTrainer t)
        {
            DataFluentApi.Entities.TrainerDetail trainer = new();
            trainer.Email = t.Email;
            trainer.Password = t.Password;
            return trainer;
        }

        /*public static DataFluentApi.Entities.TrainerDetail Map(Models.DeleteTrainer t)
        {
            DataFluentApi.Entities.TrainerDetail trainer = new();
            trainer.Email = t.Email;
            trainer.Password = t.Password;
            return trainer;
        }*/

        //TO ITERATE

        /// <summary>
        /// This method converts to Models TrainerCompany object from EF TrainerCompany Entity
        /// </summary>
        /// <param name="t"></param>
        /// <returns>Models TrainerCompany object</returns>
        public static Models.TrainerCompany Map(DataFluentApi.Entities.TrainerCompany t)
        {
            return new Models.TrainerCompany()
            {
                Id = t.Id,
                Companyname = t.Companyname,
                Title = t.Title,
                Startyear = t.Startyear,
                Endyear = t.Endyear,
                Trainercompanyid = t.Trainercompanyid,
            };
        }
        //TO_DO Get company specific to the trainer in logic layer

        /// <summary>
        /// This method converts to Models TrainerEducation object from EF TrainerEducation Entity
        /// </summary>
        /// <param name="t"></param>
        /// <returns>Models TrainerEducation object</returns>
        public static Models.TrainerEducation Map(DataFluentApi.Entities.TrainerEducation t)
        {
            return new Models.TrainerEducation()
            {
                Id = t.Id,
                Institute = t.Institute,
                Startdate = t.Startdate,
                Enddate = t.Enddate,
                Trainereducationid = t.Trainereducationid,
                Gpa = t.Gpa,
                Degreename = t.Degreename,
            };
        }
        //TO_DO Get education specific to the trainer in logic layer

        /// <summary>
        /// This method converts to Models TrainerLocation object from EF TrainerLocation Entity
        /// </summary>
        /// <param name="t"></param>
        /// <returns>Models TrainerLocation object</returns>
        public static Models.TrainerLocation Map(DataFluentApi.Entities.TrainerLocation t)
        {
            return new Models.TrainerLocation()
            {
                Id = t.Id,
                City = t.City,
                Zipcode= t.Zipcode,
                Trainerlocationid = t.Trainerlocationid
            };
        }
        //TO_DO Get location specific to the trainer in logic layer

        /// <summary>
        /// This method converts to Models TrainerSkill object from EF TrainerSkill Entity
        /// </summary>
        /// <param name="t"></param>
        /// <returns>Models TrainerSkill object</returns>
        public static Models.TrainerSkills Map(DataFluentApi.Entities.TrainerSkill t)
        {
            return new Models.TrainerSkills()
            {
                Id = t.Id,
                Skill = t.Skill,
                Trainerskillid = t.Trainerskillid
            };
        }
        //TO_DO Get skill specific to the trainer in logic layer

        /// <summary>
        /// This method converts to Models TrainerDetails object from EF TrainerDetails Entity
        /// </summary>
        /// <param name="t"></param>
        /// <returns>Models TrainerDetails object</returns>
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
        /// 
        /// </summary>
        /// <param name="trainers"></param>
        /// <returns></returns>
        public static IEnumerable<Models.TrainerSkills> Map(IEnumerable<DataFluentApi.Entities.TrainerSkill> skills)
        {
            try
            {
                return skills.Select(Map);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            return skills.Select(Map);
        }

        /// <summary>
        /// This method converts Models collection of TrainerDetail object to EF collection of TrainerDetail Entity
        /// </summary>
        /// <param name="trainers"></param>
        /// <returns>Iterable Collection</returns>
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
        /// <returns></returns>
        /*public static IEnumerable<Models.All> Map()
        {
            var tr = context.TrainerDetails;
            var sk = context.TrainerSkills;
            var res = (from t in tr
                       select new Models.All
                       {
                           Name = t.Fullname,
                           Age = t.Age,
                           Gender = t.Gender,
                           AllSkills = (from r in sk
                                         where r.Trainerskillid == t.Trainerid
                                         orderby r.Skill
                                         select r.Skill).Take(3).ToList()

                       }); ;
            return res.ToList();
        }*/

        /*public static IEnumerable<Models.All> Map(int i, int j)
        {
            var Trainer = context.TrainerDetails;
            var Skill = context.TrainerSkills;
            var res = (from t in Trainer
                        where Convert.ToInt32(t.Age) >= i && Convert.ToInt32(t.Age) <= j
                        select new Models.All
                        {
                            Name = t.Fullname,
                            Age = t.Age,
                            Gender = t.Gender,
                            AllSkills = (from r in Skill
                                         where r.Trainerskillid == t.Trainerid
                                         orderby r.Skill
                                         select r.Skill).Take(3).ToList()

                        }); 
            return res.ToList();
        }*/

        /// <summary>
        /// This method converts Models collection of TrainerDetail object to EF collection of TrainerDetail Entity
        /// </summary>
        /// <param name="trainer"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns>Iterable collection</returns>
        /*public static IEnumerable<Models.TrainerDetail>Map(IEnumerable<DataFluentApi.Entities.TrainerDetail> trainer, int i, int j)
        {
            var query = from t in trainer
                        where Convert.ToInt32(t.Age) >= i && Convert.ToInt32(t.Age) <= j
                        select t;
            return query.Select(Map);
        }*/

    }
}
