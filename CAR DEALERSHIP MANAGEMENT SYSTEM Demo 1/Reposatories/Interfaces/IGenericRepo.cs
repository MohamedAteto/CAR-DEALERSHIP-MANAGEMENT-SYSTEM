
namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        public ICollection<T> GetAll();
        public T GetById(int id );
        public void Add(T item);
        public void Update(int id ,T item);
        public void Delete(int id);


    }
}
