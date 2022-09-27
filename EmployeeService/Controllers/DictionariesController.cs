using EmployeeService.Models;
using EmployeeService.Models.Dto;
using EmployeeService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]/employee-types")]
    [ApiController]
    public class DictionariesController : ControllerBase
    {

        #region Services 

        private readonly IEmployeeTypeRepository _employeeTypeRepository;

        #endregion

        #region Constructors

        public DictionariesController(IEmployeeTypeRepository employeeTypeRepository)
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
        public ActionResult<EmployeeTypeDto> GetAllEmployeeById([FromQuery] int id)
        {
            EmployeeType result;

            result = _employeeTypeRepository.GetById(id);
            return Ok(new EmployeeType
            {
                Id = result.Id,
                Description = result.Description
            });
        }



        [HttpDelete("delete")]
        public ActionResult<bool> DeleteEmployeeType([FromQuery] int id)
        {
            return Ok(_employeeTypeRepository.Delete(id));
        }

        [HttpPut("update")]
        public ActionResult<bool> UpdateEmployeType([FromQuery] int id)
        {
            return true;
        }

        #endregion

    }
}
