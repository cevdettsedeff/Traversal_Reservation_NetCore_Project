using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericUnitOfWorkRepository<T> : IGenericUnitOfWorkDal<T> where T : class
    {
        private readonly Context _context;

        public GenericUnitOfWorkRepository(Context context)
        {
            _context = context;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _context.Add(entity);
            
        }

        public void MultiUpdate(List<T> entity)
        {
            _context.UpdateRange(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
