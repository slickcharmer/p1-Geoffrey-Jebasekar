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
                if (trainers.Count > 0)
                {
                    return Ok(trainers);
                }
                else
                {
                    return BadRequest("NO users have created an account");
                }
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
        [HttpGet("GetAllTrainersByAge")]
        public ActionResult GetAge(int age)
        {
            try
            {
                var trainers = logic.GetTrainersByAge(age);
                //if ()
                //{
                    return Ok(trainers);
            //}
            //    else
            //{
            //    return badrequest("no users have created an account");
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
        [HttpGet("GetAllTrainersByLocation")]
        public ActionResult GetLocation(string location)
        {
            try
            {
                var trainers = logic.GetTrainersByLocation(location);
                // if (trainers.Count > 0)
                //{
                return Ok(trainers);
                //}
                //else
                //{
                //   return BadRequest("NO users have created an account");
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
        [HttpPost("AddTrainer")]
        public ActionResult Add([FromForm] Trainer_Signup signup)
        {
            login.emailId = signup.emailId;
            login.password = signup.password;
            try
            {
                logic.AddSignupLogin(signup, login);
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
        [HttpDelete("DeleteAccount")]
        public ActionResult Delete(string email)
        {
            try
            {
                logic.DeleteAccount(email);


                return Ok("Account deleted successfully");


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
        //[HttpPut("Update")]
        [HttpPut("UpdateTrainersProfile")]
        public ActionResult Update([FromBody] Trainer_Signup? signup, string email)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    logic.UpdateProfile(signup, email);
                    return Ok(signup);
                }
                else
                {
                    return BadRequest($"Something went wrong");
                }
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
