using ITIDB_.net_WebApi.interfaces;
using ITIDB_.net_WebApi.Models;

namespace ITIDB_.net_WebApi.repositories
{
    public class StudentRepository : IStudentRepo
    {
        private readonly ITIContext _context;

        public StudentRepository(ITIContext context)
        {
            _context = context;
        }
        public List<Student> GetAll()
        {
          return  _context.Students.ToList();
          
        }

        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        }

        public void Add(Student student)
        {
            _context.Students.Add(student);
           // _context.SaveChanges();

        }

        public void Delete(int id)
        {
            if (id != null)
            {
                _context.Students.Remove(GetById(id));
               // _context.SaveChanges();

            }
        }

      
        public void Update(Student student)
        {
            _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
           // _context.SaveChanges();
        }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
