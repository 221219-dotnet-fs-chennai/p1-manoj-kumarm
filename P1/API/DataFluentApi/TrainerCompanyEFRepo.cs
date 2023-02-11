using DataFluentApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFluentApi
{
    public class TrainerCompanyEFRepo : ITrainerCompanyEFRepo
    {
        private readonly TrainersDbContext _context;
        public TrainerCompanyEFRepo(TrainersDbContext context)
        {
            _context = context;
        }
        public void AddTrainerCompany(int id, TrainerCompany _data)
        {
            try
            {
                if (_data != null)
                {
                    _data.Trainercompanyid = id;
                    _context.Add(_data);
                    _context.SaveChanges();
                }
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DeleteTrainerCompany(string name, int id)
        {
            try
            {
                var l = _context.TrainerCompanies.Where(item => item.Trainercompanyid == id && item.Companyname == name).First();
                if (l != null)
                {
                    _context.Remove(l);
                    _context.SaveChanges();
                }
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void UpdateTrainerCompany(TrainerCompany _data)
        {
            try
            {
                _context.Update(_data);
                _context.SaveChanges();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
