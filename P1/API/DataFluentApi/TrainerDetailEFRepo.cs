using DataFluentApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DataFluentApi
{
    public class TrainerDetailEFRepo : ITrainerDetailEFRepo
    {
        private readonly TrainersDbContext _context;
        public TrainerDetailEFRepo(TrainersDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Models.All> GetTrainerById(int id)
        {
            var tr = _context.TrainerDetails;
            var sk = _context.TrainerSkills;
            var tl = _context.TrainerLocations;
            var tc = _context.TrainerCompanies;
            var te = _context.TrainerEducations;
            var res = (from t in tr
                       where t.Trainerid == id
                       select new Models.All
                       {
                           Email = t.Email,
                           Name = t.Fullname,
                           Age = t.Age,
                           Gender = t.Gender,
                           Phone = t.Phone,
                           Website = t.Website,
                           AboutMe = t.Aboutme,
                           Location = (from l in tl
                                       where l.Trainerlocationid == t.Trainerid
                                       select new Models.EditTrainerLocation {City = l.City, Zipcode = l.Zipcode }).ToList(),
                           Skills = (from r in sk
                                        where r.Trainerskillid == t.Trainerid
                                        orderby r.Skill
                                        select r.Skill).Take(3).ToList(),
                           Education = (from e in te
                                        where e.Trainereducationid == t.Trainerid
                                        select new Models.UpdateTrainerEducation
                                        { 
                                            Institute = e.Institute,
                                            Degreename = e.Degreename,
                                            Gpa = e.Gpa,
                                            Startdate = e.Startdate,
                                            Enddate = e.Enddate
                                        }).Take(3).ToList(),
                           Companies = (from c in tc
                                        where c.Trainercompanyid == t.Trainerid
                                        select new Models.UpdateTrainerCompany {
                                            Companyname = c.Companyname,
                                            Title = c.Title,
                                            Startyear = c.Startyear,
                                            Endyear = c.Endyear
                                        }).Take(3).ToList()
                       }); ;
            return res.ToList();
        }

        public IEnumerable<Models.All> GetAllInfo()
        {
            var tr = _context.TrainerDetails;
            var tl = _context.TrainerLocations;
            var sk = _context.TrainerSkills;
            var tc = _context.TrainerCompanies;
            var te = _context.TrainerEducations;
            var res = (from t in tr
                       select new Models.All
                       {
                           Email = t.Email,
                           Name = t.Fullname,
                           Age = t.Age,
                           Gender = t.Gender,
                           Phone = t.Phone,
                           Website = t.Website,
                           AboutMe = t.Aboutme,
                           Location = (from l in tl
                                       where l.Trainerlocationid == t.Trainerid
                                       select new Models.EditTrainerLocation { City = l.City, Zipcode = l.Zipcode }).ToList(),
                           Skills = (from r in sk
                                     where r.Trainerskillid == t.Trainerid
                                     orderby r.Skill
                                     select r.Skill).Take(3).ToList(),
                           Education = (from e in te
                                        where e.Trainereducationid == t.Trainerid
                                        select new Models.UpdateTrainerEducation
                                        {
                                            Institute = e.Institute,
                                            Degreename = e.Degreename,
                                            Gpa = e.Gpa,
                                            Startdate = e.Startdate,
                                            Enddate = e.Enddate
                                        }).Take(3).ToList(),
                           Companies = (from c in tc
                                        where c.Trainercompanyid == t.Trainerid
                                        select new Models.UpdateTrainerCompany
                                        {
                                            Companyname = c.Companyname,
                                            Title = c.Title,
                                            Startyear = c.Startyear,
                                            Endyear = c.Endyear
                                        }).Take(3).ToList()

                       }); ;
            return res.ToList();
        }

        public IEnumerable<Models.All> GetTrainerByAge(int i, int j)
        {
            var Trainer = _context.TrainerDetails;
            var Skill = _context.TrainerSkills;
            var tl = _context.TrainerLocations;
            var tc = _context.TrainerCompanies;
            var te = _context.TrainerEducations;
            var res = (from t in Trainer
                       where Convert.ToInt32(t.Age) >= i && Convert.ToInt32(t.Age) <= j
                       select new Models.All
                       {
                           Email = t.Email,
                           Name = t.Fullname,
                           Age = t.Age,
                           Gender = t.Gender,
                           Phone = t.Phone,
                           Website = t.Website,
                           AboutMe = t.Aboutme,
                           Location = (from l in tl
                                       where l.Trainerlocationid == t.Trainerid
                                       select new Models.EditTrainerLocation { City = l.City, Zipcode = l.Zipcode }).ToList(),
                           Skills = (from r in Skill
                                        where r.Trainerskillid == t.Trainerid
                                        orderby r.Skill
                                        select r.Skill).Take(3).ToList(),
                           Education = (from e in te
                                        where e.Trainereducationid == t.Trainerid
                                        select new Models.UpdateTrainerEducation
                                        {
                                            Institute = e.Institute,
                                            Degreename = e.Degreename,
                                            Gpa = e.Gpa,
                                            Startdate = e.Startdate,
                                            Enddate = e.Enddate
                                        }).Take(3).ToList(),
                           Companies = (from c in tc
                                        where c.Trainercompanyid == t.Trainerid
                                        select new Models.UpdateTrainerCompany
                                        {
                                            Companyname = c.Companyname,
                                            Title = c.Title,
                                            Startyear = c.Startyear,
                                            Endyear = c.Endyear
                                        }).Take(3).ToList()
                       });
            return res.ToList();
        }

        public int GetCount()
        {
            var total = _context.TrainerDetails.Count();
            return total;
        }
        public IEnumerable<Models.All> GetMe(int id)
        {
            var tr = _context.TrainerDetails;
            var sk = _context.TrainerSkills;
            var tl = _context.TrainerLocations;
            var tc = _context.TrainerCompanies;
            var te = _context.TrainerEducations;
            var res = (from t in tr
                       where t.Trainerid == id
                       select new Models.All
                       {
                           Email = t.Email,
                           Name = t.Fullname,
                           Age = t.Age,
                           Gender = t.Gender,
                           Phone = t.Phone,
                           Website = t.Website,
                           AboutMe = t.Aboutme,
                           Location = (from l in tl
                                       where l.Trainerlocationid == t.Trainerid
                                       select new Models.EditTrainerLocation { City = l.City, Zipcode = l.Zipcode }).ToList(),
                           Skills = (from r in sk
                                     where r.Trainerskillid == t.Trainerid
                                     orderby r.Skill
                                     select r.Skill).Take(3).ToList(),
                           Education = (from e in te
                                        where e.Trainereducationid == t.Trainerid
                                        select new Models.UpdateTrainerEducation
                                        {
                                            Institute = e.Institute,
                                            Degreename = e.Degreename,
                                            Gpa = e.Gpa,
                                            Startdate = e.Startdate,
                                            Enddate = e.Enddate
                                        }).Take(3).ToList(),
                           Companies = (from c in tc
                                        where c.Trainercompanyid == t.Trainerid
                                        select new Models.UpdateTrainerCompany
                                        {
                                            Companyname = c.Companyname,
                                            Title = c.Title,
                                            Startyear = c.Startyear,
                                            Endyear = c.Endyear
                                        }).Take(3).ToList()
                       }); ;
            return res.ToList();
            /*var tr = _context.TrainerDetails;
            var sk = _context.TrainerSkills;
            var res = (from t in tr
                       where t.Trainerid == id
                       select new Models.All
                       {
                           Email = t.Email,
                           Name = t.Fullname,
                           Age = t.Age,
                           Gender = t.Gender,
                           Phone = t.Phone,
                           Website = t.Website,
                           AboutMe = t.Aboutme,
                           Skills = (from r in sk
                                     where r.Trainerskillid == t.Trainerid
                                     orderby r.Skill
                                     select r.Skill).Take(3).ToList()

                       }); ;
            return res.ToList();*/

        }
        public string UpdateTrainerDetails(DataFluentApi.Entities.TrainerDetail _data)
        {
            if(!CheckTrainerExists(_data.Email, _data.Password))
            {
                return "-1";
            }
            else
            {
                try
                {
                    _context.Update(_data);
                    _context.SaveChanges();
                    return "1";
                }
                catch (DbUpdateException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return "-1";
        }
        public string DeleteTrainerDetails(int i, DataFluentApi.Entities.TrainerDetail _data)
        {
            if (!CheckTrainerExists(_data.Email, _data.Password) || !CheckIdExists(i))
            {
                return "-1";
            }
            try
            {
                var t = _context.TrainerDetails.Where(item => item.Trainerid == i).First();
                _context.Remove(t);
                _context.SaveChanges();
                return "1";
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            return "-1";
        }
        public string AddTrainerSignUp(DataFluentApi.Entities.TrainerDetail _data)
        {
            try
            {
                DataFluentApi.Entities.TrainerDetail trainer = new();
                int id = 0;
                int _min = 1;
                int _max = 9999;
                Random _rdm = new();
                id = _rdm.Next(_min, _max);
                if(!CheckIdExists(id))
                {
                    _data.Trainerid = id;
                    if (!CheckEmailExists(_data.Email))
                    {
                        if (!CheckTrainerExists(_data.Email, _data.Password))
                        {
                            _context.Add(_data);
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                }
                else
                {
                    return "-1";
                }
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            return "-1";
        }

        public bool CheckIdExists(int i)
        {
            try
            {
                var t = _context.TrainerDetails.Where(item => item.Trainerid == i).First();
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

        public bool CheckTrainerExists(string email, string password)
        {
            try
            {
                var trainer = _context.TrainerDetails.Where(item => item.Email == email).First();
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
        public bool CheckEmailExists(string email)
        {
            try
            {
                var t = _context.TrainerDetails.Where(item => item.Email == email).First();
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
    }
}
