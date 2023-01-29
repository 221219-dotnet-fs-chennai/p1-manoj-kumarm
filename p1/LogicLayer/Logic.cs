using Microsoft.EntityFrameworkCore;

namespace LogicLayer
{
    public class Logic : ILogic
    {
        private static DataFluentApi.Entities.TrainersDbContext context = new DataFluentApi.Entities.TrainersDbContext();
        Models.IRepo<DataFluentApi.Entities.TrainerDetail> _repo;
        
        public Logic()
        {
            _repo = new DataFluentApi.EFRepo();
        }

        public void DeleteTrainerDetails(Models.TrainerDetail _data)
        {
            try
            {
                var trainer = context.TrainerDetails.Where(item => item.Trainerid == _data.Trainerid).First();
                if (trainer != null)
                {
                    context.Remove(trainer);
                    context.SaveChanges();
                }
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void UpdateTrainerDetails(Models.TrainerDetail _data)
        {
            try
            {
                var trainer = context.TrainerDetails.Where(item => item.Trainerid == _data.Trainerid).First();
                if (trainer != null)
                {
                    trainer.Fullname = _data.Fullname;
                    trainer.Phone = _data.Phone;
                    trainer.Website = _data.Website;
                    trainer.Aboutme = _data.Aboutme;
                    trainer.Age = _data.Age;
                    trainer.Gender = _data.Gender;
                    context.Update(trainer);
                    context.SaveChanges();
                }
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void AddTrainerSignUp(Models.TrainerDetail _data)
        {
            try
            {
                context.Add(Mapper.Map(_data));
                context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine("");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("");
            }
        }
        public IEnumerable<Models.TrainerDetail> GetTrainerByAge(int i, int j) {
            return Mapper.Map(_repo.SearchByFilters(), i, j);
        }
        public IEnumerable<Models.TrainerDetail> GetTrainerDetails()
        {
            return Mapper.Map(_repo.GetAll());
        }
    }
}