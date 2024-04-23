using ITIDB_.net_WebApi.Models;

namespace ITIDB_.net_WebApi.interfaces
{
    public interface IDepartmentRepo
    {
        List<Department> GetAll();

        Department GetById(int id);

        void Add(Department department);

        void Update(Department department);

        void Delete(int id);

        void save();
    }
}
