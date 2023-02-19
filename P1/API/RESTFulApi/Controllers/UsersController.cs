using LogicLayer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;


namespace RESTFulApiBasics.Controllers
{
    
    [Route("V1/api/[controller]")]
    public class UsersController : Controller
    {
       
        readonly ITrainerDetailLogic _logic;
        readonly IMemoryCache _cache;
        public UsersController(ITrainerDetailLogic logic, IMemoryCache cache)
        {
            _logic = logic;
            _cache = cache;
        }

        [HttpGet("count")]
        public IActionResult FindUsersCount()
        {
            try
            {
                int count = _logic.GetCount();
                return Ok(count);
            }
            catch (SqlException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [EnableCors("AllowAllPolicy")]
        [HttpGet("all")]
        public IActionResult FindAllUsers()
        {
            try
            {
                var CacheList = new List<Models.All>();
                if (!_cache.TryGetValue("rain", out CacheList))
                {
                    CacheList = _logic.GetAllInfo().ToList();
                    _cache.Set("rain", CacheList, new TimeSpan(0, 0, 15));
                }
                return Ok(CacheList);
            }
            catch (SqlException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("by/age")]
        public IActionResult FindUsersByAge([BindRequired][FromQuery] int i, [BindRequired][FromQuery] int j) //[FromQuery] or [FromRoute]
        {
            var t = _logic.GetTrainerByAge(i,j);
            if (t.Count() < 0)
            {
                return BadRequest();
            }
            return Ok(t);
        }

        [HttpGet("by/id")]
        public IActionResult FindUsersById([BindRequired][FromQuery] int id) //[FromQuery] or [FromRoute]
        {
            try
            {
                var CacheList = new List<Models.All>();
                if (!_cache.TryGetValue("tdetail", out CacheList))
                {
                    CacheList = _logic.GetTrainerById(id).ToList();
                    _cache.Set("tdetail", CacheList, new TimeSpan(0, 0, 15));
                }
                return Ok(CacheList);
            }
            catch (SqlException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
