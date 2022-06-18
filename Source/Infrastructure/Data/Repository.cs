using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Application.Contracts;
using DDD.Domain;
using DDD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure;
public class Repository<T> : IRepository<T> where T : class, IEntity
{
    protected readonly AppDBContext _dbContext;
    protected readonly DbSet<T> _dbSet;

    public Repository(AppDBContext context)
    {
        _dbContext = context;
        _dbSet = _dbContext.Set<T>();
    }

    public void Create(T t)
    {
        _dbSet.Add(t);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public T GetOne(int id)
    {
        return _dbSet.Find(id);
    }

    public async Task SaveChanges()
    {
        await _dbContext.SaveChangesAsync();
    }

    public T Update(T t)
    {
        return _dbSet.Update(t).Entity;
    }
}

