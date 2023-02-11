namespace LogicLayer
{
    public class TrainerLocationLogic : ITrainerLocationLogic
    {
        private readonly DataFluentApi.ITrainerLocationEFRepo _repo;
        private readonly Utility _Utility;

        public TrainerLocationLogic(DataFluentApi.ITrainerLocationEFRepo repo, Utility utility)
        {
            _repo = repo;
            _Utility = utility;
        }
        public string AddTrainerLocation(string email, Models.EditTrainerLocation _data)
        {
            if (!_Utility.CheckIdExists(_Utility.GetTrainerIdByEmail(email))) return "-1";
            else
            {
                _repo.AddTrainerLocation(_Utility.GetTrainerIdByEmail(email), Mapper.Map(_data));
                return $"{_data}";
            } 
        }

        public string DeleteTrainerLocation(string email)
        {
            if (!_Utility.CheckIdExists(_Utility.GetTrainerIdByEmail(email))) return "-1";
            else
            {
                DataFluentApi.Entities.TrainerLocation t;
                _repo.DeleteTrainerLocation(_Utility.GetTrainerIdByEmail(email));
                return "1";
            }
        }

        public string UpdateTrainerLocation(Models.EditTrainerLocation _data, string email)
        {
            if (!_Utility.CheckIdExists(_Utility.GetTrainerIdByEmail(email))) return "-1";
            else {
                DataFluentApi.Entities.TrainerLocation t;
                t = _Utility.CheckForNullsAndUpdate(_Utility.GetTrainerIdByEmail(email), _data);
                _repo.UpdateTrainerLocation(t);
                return $"{_data}";
            } 
        }
    }
}
