using ClassesTimetable.Core.Entities;
using ClassesTimetable.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ClassesTimetable.Infrastructure.Data
{
    public class Repository<T> : IRepository<T>
        where T : BaseEntity
    {

        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DatabaseContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
            _dbSet = context.Set<T>();
        }

        public object Teachers => throw new NotImplementedException();

        public async Task<T> AddAsync(T entity)
        {
            //var tmp = _dbSet.AddAsync(entity).Result;
            //return Task.CompletedTask;

            var result = await _dbSet.AddAsync(entity);
            return result.Entity;
        }

        public async Task DeleteAsync(T entity)
        {
            var toRemove = await _dbSet.FindAsync(entity.Id);
            _dbSet.Remove(toRemove);

            //_dbSet.Remove(entity.Id); так потому что сначала нужно найти а потом удалить
            //await _context.SaveChangesAsync();
        }

        public Task<T> GetByIdAsync(int id)
        {
            return _dbSet.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<T>> ListAsync()
        {
            return await _dbSet.ToListAsync();

            //return await _dbSet.Take(10);
            //return await _dbSet.Skip(10).Take(10);

        }

        public async Task UpdateAsync(T entity) //почему тут не Task<T>
        {
            var found = await _dbSet.FindAsync(entity.Id);
            if (found == null)
            {
                throw new ArgumentException();
            }

            _context.Entry(found).CurrentValues.SetValues(entity);
        }
    }
}
