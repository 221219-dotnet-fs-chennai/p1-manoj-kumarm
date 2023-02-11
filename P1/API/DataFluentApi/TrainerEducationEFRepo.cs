using DataFluentApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataFluentApi
{
    public class TrainerEducationEFRepo : ITrainerEducationEFRepo
    {
        private readonly TrainersDbContext _context;
        public TrainerEducationEFRepo(TrainersDbContext context)
        {
            _context = context;
        }
        public void AddTrainerEducation(int id, TrainerEducation _data)
        {
            try
            {
                if (_data != null)
                {
                    _data.Trainereducationid = id;
                    _context.Add(_data);
                    _context.SaveChanges();
                }
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DeleteTrainerEducation(int id, string educationName)
        {
            try
            {
                var l = _context.TrainerEducations.Where(item => item.Trainereducationid == id && item.Institute == educationName).First();
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void UpdateTrainerEducation(TrainerEducation _data)
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
