using DataFluentApi.Entities;
using Models;
namespace DataFluentApi
{
    public class TrainerDetailEFRepo : IRepo<Entities.TrainerDetail>
    {
        TrainersDbContext context = new TrainersDbContext();

        public List<Entities.TrainerDetail> GetAll(int _)
        {
            return context.TrainerDetails.ToList();
        }

        public IEnumerable<Entities.TrainerDetail> SearchByFilters()
        {
            return context.TrainerDetails.ToList();
        }
    }
}
