using AngularCRUD_API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularCRUD_API.Models;
namespace AngularCRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly EmployeeContext employeeContext;
        public EmployeesController(EmployeeContext employeeContext)
        {
            this.employeeContext = employeeContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees =  await employeeContext.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employee =  await employeeContext.Employees.FirstOrDefaultAsync(x=>x.id == id);
            if(employee == null)
            {
                return NotFound();
            }


            return Ok(employee);

        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody]Employee employee)
        {
            employee.id = Guid.NewGuid();
            var _employee = await employeeContext.Employees.AddAsync(employee);
            await employeeContext.SaveChangesAsync();
            return Ok(employee);


        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id , Employee employee)
        {
            var _employee =  await employeeContext.Employees.FindAsync(id);
            if(_employee==null)
            {
                return NotFound();
            }

            _employee.name = employee.name;
            _employee.email = employee.email;
            _employee.phone = employee.phone;
            _employee.salary = employee.salary;
            _employee.department = employee.department;

            await employeeContext.SaveChangesAsync();
            return Ok(_employee);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var _employee = await employeeContext.Employees.FindAsync(id);
            if (_employee == null)
            {
                return NotFound();
            }
            employeeContext.Employees.Remove(_employee);
            await employeeContext.SaveChangesAsync();
            return Ok(_employee);
        }




    }
}
