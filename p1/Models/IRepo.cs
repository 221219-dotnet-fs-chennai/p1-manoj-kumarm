namespace Models
{
    public interface IRepo<T>
    {
        /// <summary>
        /// Used to fetch all the details
        /// </summary>
        /// <returns>Generic collection list of objects</returns>
        List<T> GetAll();

        /// <summary>
        /// Used to fetch details using the specified filter
        /// </summary>
        /// <returns>Generic collection which can be iterated</returns>
        IEnumerable<T> SearchByFilters();
    }
}