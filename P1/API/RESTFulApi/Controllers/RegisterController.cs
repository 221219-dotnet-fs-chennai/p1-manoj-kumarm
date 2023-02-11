using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;

namespace RESTFulApiBasics.Controllers
{
    [Route("V1/api/[controller]")]
    public class RegisterController : Controller
    {
        private readonly ITrainerDetailLogic _logic;
        public RegisterController(ITrainerDetailLogic logic)
        {
            _logic = logic;
        }

        [HttpPost("signup")]
        public IActionResult SignUp([FromBody][BindRequired] Models.TrainerSingUp t)
        {
            try
            {
                var res = _logic.AddTrainerSignUp(t);
                if (res == "-1") return BadRequest("something went wrong");
                else return Created("ok", t.Email);
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
