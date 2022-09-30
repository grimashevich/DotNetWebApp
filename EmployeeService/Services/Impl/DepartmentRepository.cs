using EmployeeService.Data;
using EmployeeService.Models;

namespace EmployeeService.Services.Impl
{
    public class DepartmentRepository : IDepartmentRepository
    {
		EmployeeServiceDbContext _context;

        public DepartmentRepository(EmployeeServiceDbContext context)
        {
            _context = context;
        }

        public Guid Create(Department data)
        {
            _context.Departments.Add(data);
            _context.SaveChanges();
            return data.Id;
        }

        public bool Delete(Guid id)
        {
            Department department = GetById(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IList<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

        public Department GetById(Guid id)
        {
            return _context.Departments.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(Department data)
        {
			Department department = GetById(data.Id);
			if (department != null)
			{
				_context.Departments.Update(department);
				var res = _context.SaveChanges();
				return res > 0;
			}
			return false;
		}
    }
}
