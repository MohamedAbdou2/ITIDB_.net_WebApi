using ITIDB_.net_WebApi.interfaces;
using ITIDB_.net_WebApi.Models;

namespace ITIDB_.net_WebApi.repositories
{
    public class DepartmentRepository : IDepartmentRepo
    {
        private readonly ITIContext _context;

        public DepartmentRepository(ITIContext context)
        {
            _context = context;
        }

        public List<Department> GetAll()
        {
           return _context.Departments.ToList();    
        }

        public Department GetById(int id)
        {
            return _context.Departments.Find(id);
        }
        public void Add(Department department)
        {
           _context.Departments.Add(department);

        }

        public void Delete(int id)
        {
          _context.Departments.Remove(GetById(id)); 
        }

       

        public void Update(Department department)
        {
            _context.Entry(department).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void save()
        {
           _context.SaveChanges();
        }
    }
}
