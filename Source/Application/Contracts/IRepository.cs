using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Domain;

namespace DDD.Application.Contracts;

public interface IRepository<T> where T : class, IEntity
{
    public T GetOne(int id);

    public Task<IEnumerable<T>> GetAll();

    public void Create(T t);

    public T Update(T t);

    public Task SaveChanges();
}