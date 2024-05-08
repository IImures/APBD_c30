namespace REST_API_CWICZNIA_4.Repository;

public interface ISimpleRepository<T>
{
    public T? GetById(long id);
    public List<T> GetAll();
    public void Add(T typeEntity);
    public T save(T typeEntity);
    public void deleteById(long id);
}
