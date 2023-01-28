namespace Models
{
    public interface IRepo<T>
    {
        List<T> GetAll();
        T Add(T t);
        T Update(T t);
        IEnumerable<T> SearchByFilters(string filters);
        IEnumerable<T> SearchByFilters();
        string IsEmailExists(string str);
        int IsIdExists(int i);
        T IsTrainerExists(T t);
        string GetId(string str);   
    }
}