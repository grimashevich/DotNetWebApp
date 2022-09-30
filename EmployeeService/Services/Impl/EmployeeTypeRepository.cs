using EmployeeService.Data;
using EmployeeService.Models;
using NLog.LayoutRenderers;
using System.Security.Cryptography.Xml;

namespace EmployeeService.Services.Impl
{
    public class EmployeeTypeRepository : IEmployeeTypeRepository
    {

        EmployeeServiceDbContext _context;
        public EmployeeTypeRepository(EmployeeServiceDbContext context)
        {
            _context = context;
        }

        public Guid Create(EmployeeType data)
        {
            _context.EmployeeTypes.Add(data);
            _context.SaveChanges();
            return data.Id;
        }

        public bool Delete(Guid id)
        {
            EmployeeType employeeType = GetById(id);
            if (employeeType != null)
            {
                _context.EmployeeTypes.Remove(employeeType);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IList<EmployeeType> GetAll()
        {
            return _context.EmployeeTypes.ToList();
        }

        public EmployeeType GetById(Guid id)
        {
            return _context.EmployeeTypes.FirstOrDefault(et => et.Id == id);
        }

        public EmployeeType GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(EmployeeType data)
        {
			EmployeeType employeeType = GetById(data.Id);
			if (employeeType != null)
			{
                _context.EmployeeTypes.Update(employeeType);
                var res = _context.SaveChanges();
                return res > 0;
			}
			return false;
		}
    }
}
