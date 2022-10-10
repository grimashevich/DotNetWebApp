using EmployeeService.Data;
using EmployeeService.Models;
using EmployeeService.Models.Dto;
using EmployeeService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        #region Services 

        private readonly IDepartmentRepository _departmentRepository;

        #endregion

        #region Constructors

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        #endregion

        #region Public Methods
        
        [HttpGet("all")]
        public ActionResult<IList<DepartmentDto>> GetAllDepartments()
        {
            return Ok(_departmentRepository.GetAll().Select(et =>
                new DepartmentDto
                {
                    Id = et.Id,
                    Description = et.Description                 
                }
            ).ToList());
        }

        [HttpGet("getbyid")]
        public ActionResult<DepartmentDto> GetDepartmentById([FromQuery] Guid id)
        {
            Department result;

            result = _departmentRepository.GetById(id);
            return Ok(new DepartmentDto
            {
                Id = result.Id,
                Description = result.Description
            });
        }
        
        [HttpPost("create")]
        public ActionResult<Guid> CreateDepartment([FromQuery] string description)
        {
            return Ok(_departmentRepository.Create(new Department
            {
                Description = description
            }));
        }

        [HttpDelete("delete")]
        public ActionResult<bool> DeleteDepartment([FromQuery] Guid id)
        {
            return Ok(_departmentRepository.Delete(id));
        }

        [HttpPut("update")]
        public ActionResult<bool> UpdateDepartment([FromQuery] Guid id)
        {
            return true;
        }
        
        #endregion
    }
}
