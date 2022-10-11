using EmployeeService.Data;
using EmployeeService.Models;
using EmployeeService.Models.Dto;
using EmployeeService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        
        #region Services 

        private readonly IEmployeeRepository _employeeRepository;

        #endregion

        #region Constructors

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        #endregion

        #region Public Methods
        
        [HttpGet("all")]
        public ActionResult<IList<EmployeeDto>> GetAllEmployees()
        {
            return Ok(_employeeRepository.GetAll().Select(et =>
                new EmployeeDto
                {
                    Id = et.Id,
                    Patronymic = et.Patronymic,
                    Salary = et.Salary,
                    Surname = et.Surname,
                    DepartmentId = et.DepartmentId,
                    FirstName = et.FirstName,
                    EmployeeTypeId = et.EmployeeTypeId
                }
            ).ToList());
        }

        [HttpGet("getbyid")]
        public ActionResult<EmployeeDto> GetEmployeeById([FromQuery] Guid id)
        {
            Employee result;

            result = _employeeRepository.GetById(id);
            return Ok(new EmployeeDto
            {
                Id = result.Id,
                Patronymic = result.Patronymic,
                Salary = result.Salary,
                Surname = result.Surname,
                DepartmentId = result.DepartmentId,
                FirstName = result.FirstName,
                EmployeeTypeId = result.EmployeeTypeId
            });
        }
        
        [HttpPost("create")]
        public ActionResult<Guid> CreateEmployee([FromBody] Employee employee)
        {
            return Ok(_employeeRepository.Create(new Employee
            {
                Id = employee.Id,
                Patronymic = employee.Patronymic,
                Salary = employee.Salary,
                Surname = employee.Surname,
                DepartmentId = employee.DepartmentId,
                FirstName = employee.FirstName,
                EmployeeTypeId = employee.EmployeeTypeId
            }));
        }
        [HttpDelete("delete")]
        public ActionResult<bool> DeleteEmployee([FromQuery] Guid id)
        {
            return Ok(_employeeRepository.Delete(id));
        }

        [HttpPut("update")]
        public ActionResult<bool> UpdateEmployee([FromQuery] Guid id)
        {
            return true;
        }
        
        #endregion

    }
}
