namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interface
{
    public interface IGenericRepo<T> where T : class
    {
        public ICollection<T> GetAll();

        public T GetById(int id);
        public void Create(T entity);   
        public void Update(int id,T entity);
        public void Delete(int id);



    }
}
