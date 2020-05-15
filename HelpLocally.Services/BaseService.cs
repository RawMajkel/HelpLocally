using HelpLocally.Domain;
using HelpLocally.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpLocally.Services
{
    public class BaseService
    {
        protected readonly HelpLocallyContext _context;

        public BaseService(HelpLocallyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAll<TEntity>() where TEntity : class
        {
            return await Task.FromResult(_context.Set<TEntity>().AsEnumerable());
        }
        public async Task Add<TEntity>(TEntity value) where TEntity : class
        {
            await _context.Set<TEntity>().AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task Delete<TEntity>(TEntity value) where TEntity : class
        {
            await Task.FromResult(_context.Set<TEntity>().Remove(value));
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> GetEntityById<TEntity>(Guid id)
            where TEntity : BaseEntity
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
