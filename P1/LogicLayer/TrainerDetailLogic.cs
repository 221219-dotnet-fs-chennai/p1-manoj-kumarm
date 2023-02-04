using Microsoft.EntityFrameworkCore;
using Models;

namespace LogicLayer
{
    public class TrainerDetailLogic : ITrainerDetailLogic
    {
        private static DataFluentApi.Entities.TrainersDbContext context = new DataFluentApi.Entities.TrainersDbContext();
        Models.IRepo<DataFluentApi.Entities.TrainerDetail> _repo;
        
        public TrainerDetailLogic()
        {
            _repo = new DataFluentApi.TrainerDetailEFRepo();
        }
        
        public void AddTrainerSkills(Models.TrainerSkills _data)
        {
            try
            {
                context.Add(Mapper.Map(_data));
                context.SaveChanges();
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine("");
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine("");
            }
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
                DataFluentApi.Entities.TrainerDetail t;
                t = Utility.CheckForNullsAndUpdate(_data);
                context.Update(t);
                context.SaveChanges();
                
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
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

        public IEnumerable<Models.All> GetAllInfo()
        {
           return Mapper.Map();
        }
    }
}