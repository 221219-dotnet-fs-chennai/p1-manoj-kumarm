using DataFluentApi.Entities;
using Microsoft.IdentityModel.Tokens;

namespace LogicLayer
{
    public class Utility
    {
        internal readonly int MaxCount = 2;
        private TrainersDbContext context;

        public Utility(TrainersDbContext _context) { 
            context = _context;
        }

        public bool CheckSkillExists(int id, Models.UpdateTrainerSkill _data)
        {
            if (context.TrainerSkills.Where(item => item.Trainerskillid == id && item.Skill == _data.Skill).Any()) return false;
            else return true;
        }

        public DataFluentApi.Entities.TrainerEducation CheckForNullsAndUpdate(int id, string name, Models.UpdateTrainerEducation _data)
        {
            try
            {
                var trainer = context.TrainerEducations.Where(item => item.Trainereducationid == id && item.Institute == name).FirstOrDefault();
                if (trainer != null)
                {
                    if (trainer.Institute != null && _data.Institute.IsNullOrEmpty() || _data.Institute == null || _data.Institute == "" || _data.Institute == " ") trainer.Institute = trainer.Institute;
                    else trainer.Institute = _data.Institute;
                    if (trainer.Degreename != null && _data.Degreename.IsNullOrEmpty() || _data.Degreename == null || _data.Degreename == "" || _data.Degreename == " ") trainer.Degreename = trainer.Degreename;
                    else trainer.Degreename = _data.Degreename;
                    if (trainer.Gpa != null && _data.Gpa.IsNullOrEmpty() || _data.Gpa == null || _data.Gpa == "" || _data.Gpa == " ") trainer.Gpa = trainer.Gpa;
                    else trainer.Gpa = _data.Gpa;
                    if (trainer.Startdate != null && _data.Startdate.IsNullOrEmpty() || _data.Startdate == null || _data.Startdate == "" || _data.Startdate == " ") trainer.Startdate = trainer.Startdate;
                    else trainer.Startdate = _data.Startdate;
                    if (trainer.Enddate != null && _data.Enddate.IsNullOrEmpty() || _data.Enddate == null || _data.Enddate == "" || _data.Enddate == " ") trainer.Enddate = trainer.Enddate;
                    else trainer.Enddate = _data.Enddate;
                }
                return trainer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public DataFluentApi.Entities.TrainerCompany CheckForNullsAndUpdate(int id, string name, Models.UpdateTrainerCompany _data)
        {
            try
            {
                var trainer = context.TrainerCompanies.Where(item=>item.Trainercompanyid == id && item.Companyname == name).First();
                if(trainer != null)
                {
                    if(trainer.Companyname != null && _data.Companyname.IsNullOrEmpty() || _data.Companyname == "" || _data.Companyname == " " || _data.Companyname == null) trainer.Companyname = trainer.Companyname;
                    else trainer.Companyname = _data.Companyname;
                    if (trainer.Title != null && _data.Title.IsNullOrEmpty() || _data.Title == "" || _data.Title == " " || _data.Title == null) trainer.Title = trainer.Title;
                    else trainer.Title = _data.Title; 
                    if (trainer.Startyear != null && _data.Startyear.IsNullOrEmpty() || _data.Startyear == "" || _data.Startyear == " " || _data.Startyear == null) trainer.Startyear = trainer.Startyear;
                    else trainer.Startyear = _data.Startyear; 
                    if (trainer.Endyear != null && _data.Endyear.IsNullOrEmpty() || _data.Endyear == "" || _data.Endyear == " " || _data.Endyear == null) trainer.Endyear = trainer.Endyear;
                    else trainer.Endyear = _data.Endyear;
                }
                return trainer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public DataFluentApi.Entities.TrainerLocation CheckForNullsAndUpdate(int id, Models.EditTrainerLocation _data)
        {
            try
            {
                var trainer = context.TrainerLocations.Where(item => item.Trainerlocationid == id).First();
                if(trainer != null)
                {
                    if (trainer.Zipcode != null && _data.Zipcode.IsNullOrEmpty() || _data.Zipcode == null || _data.Zipcode == "" || _data.Zipcode == " ") trainer.Zipcode = trainer.Zipcode;
                    else trainer.Zipcode = _data.Zipcode;
                    if (trainer.City != null && _data.City.IsNullOrEmpty() || _data.City == null || _data.City == "" || _data.City == " ") trainer.City = trainer.City;
                    else trainer.City = _data.City;
                }
                return trainer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public DataFluentApi.Entities.TrainerSkill CheckForNullsAndUpdate(int id, Models.UpdateTrainerSkill _data, string oldSkill)
        {
            try
            {
                var trainer = context.TrainerSkills.Where(item => item.Trainerskillid == id && item.Skill == oldSkill).First();
                if (trainer != null)
                {
                    if (trainer.Skill != null && _data.Skill.IsNullOrEmpty() || _data.Skill == null || _data.Skill == "" || _data.Skill == " ")
                    {
                        trainer.Skill = trainer.Skill;
                    }
                    else
                    {
                        trainer.Skill = _data.Skill;
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
        /// Updates only the specified column in the Db
        /// </summary>
        /// <param name="_data"></param>
        /// <returns>Object of type DataFluentApi.Entities.TrainerDetail</returns>
        public DataFluentApi.Entities.TrainerDetail CheckForNullsAndUpdate(int i, Models.TrainerUpdate _data)
        {
            try
            {
                var trainer = context.TrainerDetails.Where(item => item.Trainerid == i).First();
                if (trainer != null)
                {
                    if (trainer.Fullname != null && _data.Fullname.IsNullOrEmpty() || _data.Fullname == "" || _data.Fullname == " " || _data.Fullname == null)
                    {
                        trainer.Fullname = trainer.Fullname;
                    }
                    else
                    {
                        trainer.Fullname = _data.Fullname;
                    }
                    if (trainer.Phone != null && _data.Phone.IsNullOrEmpty() || _data.Phone == "" || _data.Phone == " " || _data.Phone == null)
                    {
                        trainer.Phone = trainer.Phone;
                    }
                    else
                    {
                        trainer.Phone = _data.Phone;
                    }
                    if (trainer.Website != null && _data.Website.IsNullOrEmpty() || _data.Website == "" || _data.Website == " " || _data.Website == null)
                    {
                        trainer.Website = trainer.Website;
                    }
                    else
                    {
                        trainer.Website = _data.Website;
                    }
                    if (trainer.Aboutme != null && _data.Aboutme.IsNullOrEmpty() || _data.Aboutme == "" || _data.Aboutme == " " || _data.Aboutme == null)
                    {
                        trainer.Aboutme = trainer.Aboutme;
                    }
                    else
                    {
                        trainer.Aboutme = _data.Aboutme;
                    }
                    if (trainer.Age != null && _data.Age.IsNullOrEmpty() || _data.Age == "" || _data.Age == " " || _data.Age == null)
                    {
                        trainer.Age = trainer.Age;
                    }
                    else
                    {
                        trainer.Age = _data.Age;
                    }
                    if (trainer.Gender != null && _data.Gender.IsNullOrEmpty() || _data.Gender == "" || _data.Gender == " " || _data.Gender == null)
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
        public bool ReachedMaxEducationCount(int id)
        {
            int t = context.TrainerEducations.Where(item => item.Trainereducationid == id).Count();
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
        /// Counts the number of records present in the table for a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if the number of records reached the maximum count else False</returns>
        public bool ReachedMaxCompanyCount(int id)
        {
            int t = context.TrainerCompanies.Where(item => item.Trainercompanyid == id).Count();
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
        /// Counts the number of records present in the table for a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if the number of records reached the maximum count else False</returns>
        public bool ReachedMaxSkillCount(int id) {
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
        public bool CheckEmailExists(string email)
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
        public bool CheckIdExists(int i)
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
        public bool CheckTrainerExists(string email, string password)
        {
            try
            {
                var trainer = context.TrainerDetails.Where(item => item.Email == email).First();
                if (trainer.Email == email && trainer.Password == password)
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
        public int GetTrainerIdByEmail(string email)
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
        public int GenerateRandomNo()
        {
            int _min = 1;
            int _max = 9999;
            Random _rdm = new();
            return _rdm.Next(_min, _max);
        }
    }
}
