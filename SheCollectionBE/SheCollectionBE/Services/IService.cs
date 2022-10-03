namespace SheCollectionBE.Services
{
    public interface IService<T>
    {
        T GetById(int id);
        List<T> GetAll();
        bool Delete(int id);
        List<T> GetBy(Func<T, bool> predicate);
        bool Update(int id, T entity);
        T Create(T entity);
    }
}
