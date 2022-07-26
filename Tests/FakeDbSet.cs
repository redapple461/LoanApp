using System.Collections.ObjectModel;
using System.Data.Entity;

public class FakeDbSet<T> : IDbSet<T> where T : class
{
    ObservableCollection<T> _data;
    IQueryable _query;

    public FakeDbSet()
    {
        _data = new ObservableCollection<T>();
        _query = _data.AsQueryable();
    }

    public virtual T Find(params object[] keyValues)
    {
        throw new NotImplementedException("Derive from FakeDbSet<T> and override Find");
    }

    public T Add(T item)
    {
        _data.Add(item);
        return item;
    }

    public T Remove(T item)
    {
        _data.Remove(item);
        return item;
    }

    public T Attach(T item)
    {
        _data.Add(item);
        return item;
    }

    public T Detach(T item)
    {
        _data.Remove(item);
        return item;
    }

    public T Create()
    {
        return Activator.CreateInstance<T>();
    }

    public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
    {
        return Activator.CreateInstance<TDerivedEntity>();
    }

    public ObservableCollection<T> Local
    {
        get { return _data; }
    }

    Type IQueryable.ElementType
    {
        get { return _query.ElementType; }
    }

    System.Linq.Expressions.Expression IQueryable.Expression
    {
        get { return _query.Expression; }
    }

    IQueryProvider IQueryable.Provider
    {
        get { return _query.Provider; }
    }

    ObservableCollection<T> IDbSet<T>.Local => throw new NotImplementedException();

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return _data.GetEnumerator();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return _data.GetEnumerator();
    }

    T IDbSet<T>.Find(params object[] keyValues)
    {
        throw new NotImplementedException();
    }

    T IDbSet<T>.Add(T entity)
    {
        throw new NotImplementedException();
    }

    T IDbSet<T>.Remove(T entity)
    {
        throw new NotImplementedException();
    }

    T IDbSet<T>.Attach(T entity)
    {
        throw new NotImplementedException();
    }

    T IDbSet<T>.Create()
    {
        throw new NotImplementedException();
    }

    TDerivedEntity IDbSet<T>.Create<TDerivedEntity>()
    {
        throw new NotImplementedException();
    }
}