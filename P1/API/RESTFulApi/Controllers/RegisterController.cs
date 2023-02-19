using LogicLayer;
using Microsoft.AspNetCore.Cors;
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

        //[EnableCors("AllowAllPolicy")]
        [HttpPost("signup")]
        public IActionResult SignUp([FromBody][BindRequired] Models.TrainerSingUp t)
        {
            try
            {
                var res = _logic.AddTrainerSignUp(t);
                if (res == "-1") return BadRequest("account already exists");
                return Redirect("https://localhost:7009/V1/api/Users/all");
                //else return Created("ok", t.Email);

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
