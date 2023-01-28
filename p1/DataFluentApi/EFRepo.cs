using DataFluentApi.Entities;
using Models;
namespace DataFluentApi
{
    public class EFRepo : IRepo<Entities.TrainerDetail>
    {
        TrainersDbContext context = new TrainersDbContext();

        public string GetId(string str)
        {
            return str;
        }
        public Entities.TrainerDetail IsTrainerExists(Entities.TrainerDetail t)
        {
            return t;
        }
        public int IsIdExists(int i)
        {
            return i;
        }
        public string IsEmailExists(string email) {
            return email;
        }
        public Entities.TrainerDetail Update(Entities.TrainerDetail trainer)
        {
            var t = context.TrainerDetails.Where(item => item.Trainerid == trainer.Trainerid && item.Fullname != trainer.Fullname).FirstOrDefault();
            if (t != null)
            {
                t.Fullname = trainer.Fullname;
                context.Update(t);
                context.SaveChanges();
            }
            return trainer;
        }
        public Entities.TrainerDetail Add(Entities.TrainerDetail trainer)
        {
            return trainer;
        }
        public List<Entities.TrainerDetail> GetAll()
        {
            return context.TrainerDetails.ToList();
        }
        public IEnumerable<Entities.TrainerDetail> SearchByFilters()
        {
            return context.TrainerDetails.ToList();
        }
        public IEnumerable<Entities.TrainerDetail> SearchByFilters(string filters)
        {
            throw new NotImplementedException();
        }
    }
}
