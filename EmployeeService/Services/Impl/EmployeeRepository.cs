using EmployeeService.Data;
using EmployeeService.Models;

namespace EmployeeService.Services.Impl
{
    public class EmployeeRepository : IEmployeeRepository
    {        
        EmployeeServiceDbContext _context;

        public EmployeeRepository(EmployeeServiceDbContext context)
        {
            _context = context;
        }

        public Guid Create(Employee data)
        {
            _context.Employees.Add(data);
            _context.SaveChanges();
            return data.Id;
        }

        public bool Delete(Guid id)
        {
            Employee employee = GetById(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IList<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(Guid id)
        {
            return _context.Employees.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(Employee data)
        {
            Employee employee = GetById(data.Id);
            if (employee != null)
            {
                _context.Employees.Update(employee);
                var res = _context.SaveChanges();
                return res > 0;
            }
            return false;
        }
    }
}
