using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Implemntaion
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepo(AppDbContext context )
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }
        public void Create(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Add(entity);

        }

        public void Delete(int id )
        {
            var item = _dbSet.Find(id);
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _dbSet.Remove(item);
        }

        public ICollection<T> GetAll()
        {
            var items = _dbSet.ToList();

            if(items == null || items.Count == 0)
            {
                throw new ArgumentNullException(nameof(items));
            }

            return items;
        }

        public T GetById(int id)
        {
            var item = _dbSet.Find(id);

            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            return item;
        }

        public void Update(int id,T entity)
        {
            var item = _dbSet.Find(id);
            if (item == null) 
                throw new ArgumentNullException(nameof(item));

            _dbSet.Update(entity);

        }
    }
}
