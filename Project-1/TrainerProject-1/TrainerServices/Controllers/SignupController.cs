using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using BusinessLogic;
using Microsoft.Data.SqlClient;
using EntityLayer.Entities;

namespace TrainerServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        
        ILogic logic;
        Trainer_Login login = new Trainer_Login();
        public SignupController(ILogic _logic) 
        {
            logic = _logic;
        }
        [HttpGet("GetAllTrainers")]
        public ActionResult Get()
        {
            try
            {
                var trainers = logic.GetAllTrainers();
                if(trainers.Count>0)
                {
                    return Ok(trainers);
                }
                else
                {
                    return BadRequest("NO users have created an account");
                }
            }
            catch(SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);  
            }
        }
        [HttpPost("AddTrainer")]
        public ActionResult Add([FromForm]Trainer_Signup signup)
        {
            login.emailId = signup.emailId;
            login.password = signup.password;
            try
            {
                logic.AddSignupLogin(signup,login);
                //if (trainers.Count > 0)
                //{
                   return Ok("Trainer Added Successfully");
                //}
                //else
                //{
                //    return BadRequest("NO users have created an account");
                //}
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
