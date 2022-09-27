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
                    Id = GuidConverter.FromGuid(et.Id),
                    Description = et.Description
                }
            ).ToList());
        }

        [HttpGet("getbyid")]
        public ActionResult<DepartmentDto> GetDepartmentById([FromQuery] int id)
        {
            Department result;

            result = _departmentRepository.GetById(GuidConverter.ToGuid(id));
            return Ok(new DepartmentDto
            {
                Id = GuidConverter.FromGuid(result.Id),
                Description = result.Description
            });
        }
        
        [HttpPost("create")]
        public ActionResult<int> CreateDepartment([FromQuery] string description)
        {
            return Ok(_departmentRepository.Create(new Department
            {
                Description = description
            }));
        }
        [HttpDelete("delete")]
        public ActionResult<bool> DeleteDepartment([FromQuery] int id)
        {
            return Ok(_departmentRepository.Delete(GuidConverter.ToGuid(id)));
        }

        [HttpPut("update")]
        public ActionResult<bool> UpdateDepartment([FromQuery] int id)
        {
            return true;
        }
        
        #endregion
    }
}
