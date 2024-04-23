using ITIDB_.net_WebApi.Models;

namespace ITIDB_.net_WebApi.interfaces
{
    public interface IStudentRepo
    {
        List<Student> GetAll();

        Student GetById(int id);

        void Add(Student student);

        void Update(Student student);

        void Delete(int id);

        void save();

    }
}
