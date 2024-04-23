using ITIDB_.net_WebApi.Models;

namespace ITIDB_.net_WebApi.repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private readonly ITIContext _context;

        public GenericRepository(ITIContext context)
        {
            _context = context;
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();    
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);

        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            _context.Set<TEntity>().Remove(GetById(id));
        }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
