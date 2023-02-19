using DataFluentApi.Entities;
using DataFluentApi;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class TrainerCompanyLogic : ITrainerCompanyLogic
    {
        private readonly ITrainerCompanyEFRepo _repo;
        private readonly Utility _Utility;
        //private readonly Mapper _mapper;

        public TrainerCompanyLogic(ITrainerCompanyEFRepo repo, Utility utility)
        {
            _repo = repo;
            _Utility = utility;
        }
        public string AddTrainerCompany(string email, AddTrainerCompany _data)
        {
            int id = _Utility.GetTrainerIdByEmail(email);
            if(_Utility.CheckIdExists(id))
            {
                if (!_Utility.ReachedMaxCompanyCount(id))
                {
                    _repo.AddTrainerCompany(id, Mapper.Map(_data));
                    return $"{_data}";
                }
                else
                {
                    return "max";
                }
            }
            
            else
            {
                return "-1";
            }
        }

        public string DeleteTrainerCompany(string email, string name)
        {
            if (_Utility.CheckIdExists(_Utility.GetTrainerIdByEmail(email)))
            {
                _repo.DeleteTrainerCompany(name, _Utility.GetTrainerIdByEmail(email));
                return $"{name}";
            }
            else
            {
                return "-1";
            }
        }

        public Models.TrainerCompany UpdateTrainerCompany(string email, string companyname, UpdateTrainerCompany _data)
        {
            if (_Utility.CheckIdExists(_Utility.GetTrainerIdByEmail(email)))
            {
                DataFluentApi.Entities.TrainerCompany t;
                t = _Utility.CheckForNullsAndUpdate(_Utility.GetTrainerIdByEmail(email), companyname, _data);
                _repo.UpdateTrainerCompany(t);
                return Mapper.Map(t);
            }
            else return null;
        }
    }
}
