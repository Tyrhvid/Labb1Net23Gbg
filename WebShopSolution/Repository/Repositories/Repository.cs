using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //Consume db Context
        //private readonly  Context context
        //use DbSet
        //private readonly DbSet dbset
        public Repository(/* Context context, DbSet dbSet */)
        {
            /*_context = context;
             _dbSet = context.Set<T>();
            */
        }
        public void Add(T item)
        {
           /*
             _dbSet.Add(item);
            */
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
