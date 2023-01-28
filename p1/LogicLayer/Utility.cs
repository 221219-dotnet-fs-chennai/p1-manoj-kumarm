namespace LogicLayer
{
    public class Utility
    {
        /// <summary>
        /// generates a unique 4 digit number
        /// </summary>
        /// <returns>integer</returns>
        public static int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
    }
}
