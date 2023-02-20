using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Models;

namespace TrainerServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        ILogic logic;
        //Trainer_Login login = new Trainer_Login();
        public EducationController(ILogic _logic)
        {
            logic = _logic;
        }
        [HttpPost("AddTrainerEducation")]
        public ActionResult Add([FromBody] Trainer_Education education)
        {
            //education.emailid = email;
            try
            {
                logic.AddE(education);

                return Ok("Trainer education Added Successfully");

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
        [HttpGet("GetTrainersEducation")]
        public ActionResult Get(string email)
        {
            try
            {
                var trainers = logic.GetTrainersEducation(email);


                return Ok(trainers);


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
        [HttpGet("GetTrainersEducationByType")]
        public ActionResult Get(string email, string edu)
        {
            try
            {
                var trainers = logic.GetTrainersEducation(email, edu);


                return Ok(trainers);


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
        [HttpDelete("DeleteTrainersEducation/{email}/{educationType}")]
        public ActionResult Delete(string email,string educationType)
        {
            try
            {
                 logic.DeleteEducation(email,educationType);


                return Ok("Education deleted successfully");


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
        [HttpPut("UpdateTrainersEducation")]
        public ActionResult Update([FromBody]Trainer_Education education, string email, string educationType )
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    logic.UpdateEducation(education,email,educationType);
                    return Ok(education);
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
