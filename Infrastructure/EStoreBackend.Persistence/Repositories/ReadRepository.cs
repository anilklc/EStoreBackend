using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Domain.Common;
using EStoreBackend.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepostiory<T> where T : BaseEntity
    {
        private readonly EStoreDbContext _context;

        public ReadRepository(EStoreDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = (!tracking) ? Table.AsNoTracking() : Table.AsQueryable();
            return query;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = (!tracking) ? Table.AsNoTracking() : Table.AsQueryable();
            return await query.FirstOrDefaultAsync(x=>x.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = (!tracking) ? Table.AsNoTracking() : Table.AsQueryable();
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = (!tracking) ? Table.AsNoTracking() : Table.AsQueryable();
            return query.Where(method);
        }
    }
}
