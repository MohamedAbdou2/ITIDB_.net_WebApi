using ITIDB_.net_WebApi.Models;
using ITIDB_.net_WebApi.repositories;

namespace ITIDB_.net_WebApi.UniitOfWorks
{
    public class UnitWork
    {
        private readonly ITIContext context;
        GenericRepository<Student> studentRepository;
        GenericRepository<Department> departmentRepository;

        public UnitWork(ITIContext context)
        {
            this.context = context;
        }

        public GenericRepository<Student> StudentRepository
        {
            get {
                if(studentRepository == null)
                {
                    studentRepository = new GenericRepository<Student>(context);
                }
                return studentRepository;
            }
        }

        public GenericRepository<Department> DepartmentRepository
        {
            get
            {
                if(departmentRepository == null)
                {
                    departmentRepository = new GenericRepository<Department>(context);
                }
                return departmentRepository;
            }
        }

        public void save()
        {
            context.SaveChanges();
        }
    }
}
