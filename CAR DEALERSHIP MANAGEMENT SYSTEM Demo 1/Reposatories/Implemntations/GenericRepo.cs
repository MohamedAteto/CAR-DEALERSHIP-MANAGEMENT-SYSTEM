using System.Linq.Expressions;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Implemntations
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _Set;
        public GenericRepo(AppDbContext context)
        {
            _context = context;
            _Set = _context.Set<T>();
        }


        public void Add(T item)
        {
            _Set.Add(item);
        }

        public void Delete(int id)
        {
            var item = _Set.Find(id);

            if (item is null)
                throw new Exception("not found");

            _Set.Remove(item);

        }

        public ICollection<T> GetAll()
        {
            var items = _Set.ToList();

            if (items is null)
                throw new Exception("not found");

            return items;

        }

        public T GetById(int id)
        {
            var item = _Set.Find(id);

            if (item is null)
                throw new Exception("not found");

            return item;
        }

        public void Update(int id ,T item)
        {
            var exist = _Set.Find(id);

            if (item is null)
                throw new Exception("not found");

            _Set.Update(item);
        }
    }
}
