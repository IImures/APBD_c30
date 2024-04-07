namespace REST_API_CWICZNIA_4.Repository;

public class SimpleRepository<T, B> : ISimpleRepository<T> where T : IEntity where B : ICollection<T>
{
    B _db;

    public SimpleRepository(B db)
    {
        _db = db;
    }

    public T GetById(long id)
    {
        var find = _db.FirstOrDefault(t => t.Id == id);
        if (find == null)
        {
            throw new Exception("Entity with id " + id + " not found");
        }
        return find;
    }

    public List<T> GetAll()
    {
        return _db.ToList();
    }

    public void Add(T typeEntity)
    {
        _db.Add(typeEntity);
    }

    public T save(T typeEntity)
    {
        typeEntity.Id = GetMaxId() + 1;
        _db.Add(typeEntity);
        return typeEntity;
    }

    public long GetMaxId()
    {
        return _db.Max(t => t.Id);
    }

    public void deleteById(long id)
    {
        var find = _db.FirstOrDefault(t => t.Id == id);
        if (find != null)
        {
            _db.Remove(find);
        }else
        {
            throw new Exception("Not found");
        }
    }
}

