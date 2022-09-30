using EmployeeService.Data;
using EmployeeService.Models;
using EmployeeService.Models.Dto;
using EmployeeService.Services;
using EmployeeService.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]/employee-types")]
    [ApiController]
    public class EmployeTypeController : ControllerBase
    {

        #region Services 

        private readonly IEmployeeTypeRepository _employeeTypeRepository;

        #endregion

        #region Constructors

        public EmployeTypeController(IEmployeeTypeRepository employeeTypeRepository)
        {
            _employeeTypeRepository = employeeTypeRepository;
        }

        #endregion

        #region Public Methods

        [HttpGet("all")]
        public ActionResult<IList<EmployeeTypeDto>> GetAllEmployeeTypes()
        {
            return Ok(_employeeTypeRepository.GetAll().Select( et =>
                new EmployeeTypeDto
                {
                    Id = et.Id,
                    Description = et.Description
                }
                ).ToList());
        }        
        
        [HttpGet("getbyid")]
        public ActionResult<EmployeeTypeDto> GetAllEmployeeById([FromQuery] Guid id)
        {
            EmployeeType result;

            result = _employeeTypeRepository.GetById(id);
            return Ok(new EmployeeType
            {
                Id = result.Id,
                Description = result.Description
            });
        }

		[HttpPost("create")]
		public ActionResult<Guid> CreateEmployeType([FromQuery] string description)
        {
            return Ok(_employeeTypeRepository.Create(new EmployeeType
            {
                Description = description
            }));
		}

		[HttpDelete("delete")]
        public ActionResult<bool> DeleteEmployeeType([FromQuery] Guid id)
        {
            return Ok(_employeeTypeRepository.Delete(id));
        }

        [HttpPut("update")]
        public ActionResult<bool> UpdateEmployeType([FromQuery] Guid id)
        {
            return true;
        }

        #endregion

    }
}
