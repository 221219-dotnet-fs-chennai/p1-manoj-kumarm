using DataFluentApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFluentApi
{
    public class TrainerLocationEFRepo : ITrainerLocationEFRepo
    {
        private readonly TrainersDbContext _context;
        public TrainerLocationEFRepo(TrainersDbContext context)
        {
            _context = context;
        }

        public void AddTrainerLocation(int id, TrainerLocation _data)
        {
            try
            {
                if (_data != null)
                {
                    _data.Trainerlocationid = id;
                    _context.Add(_data);
                    _context.SaveChanges();
                }
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DeleteTrainerLocation(int id)
        {
            try
            {

                var l = _context.TrainerLocations.Where(item => item.Trainerlocationid == id).First();
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
        }

        public void UpdateTrainerLocation(TrainerLocation _data)
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
