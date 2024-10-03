using DataAccess.Interface;
 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Linq.Expressions;


namespace DataAccess.Repository
{
    public class DataAccess<T> : IDataAccess<T> where T : class
    {
        private readonly AppHealthContext _appHealthContext;
        private readonly DbSet<T> table;
        public DataAccess(AppHealthContext appHealthContext)
        {

            _appHealthContext = appHealthContext;
            table = _appHealthContext.Set<T>();
        }


        public Task Delete(object id)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteRange(T[] obj)
        {
            table.RemoveRange(obj);
            await Save();
        }
        public async Task<List<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public async Task<T?> GetById(object id)
        {
            T? t = await table.FindAsync(id);
            return t;
        }

        public async Task<T?> GetByParam(Expression<Func<T, bool>> obj)
        {
            T? t = await table.AsNoTracking().FirstOrDefaultAsync(obj);
            return t;
        }

        public async Task<List<T>> GetListByParam(Expression<Func<T, bool>> obj)
        {
            return await table.Where(obj).ToListAsync();
        }


        public async Task<List<T>> GetAllByParamIncluding(Expression<Func<T, bool>> obj, params Expression<Func<T, object>>[] includeProperties)
        {

            IQueryable<T> query = table.AsQueryable();

            if (obj is not null)
            {
                query = query.Where(obj);
            }

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            List<T> result = await query.ToListAsync();
            return result;
        }

        public async Task Insert(T obj)
        {
            table.Add(obj);
            await Save();
        }

        public async Task InsertRange(T[] obj)
        {
            await table.AddRangeAsync(obj);
            await Save();
        }


        public async Task Save()
        {
            await _appHealthContext.SaveChangesAsync();
        }

        public async Task Update(T obj)
        {
            table.Update(obj);
            await Save();
        }

    }
}
