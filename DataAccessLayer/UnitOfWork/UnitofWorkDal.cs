using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitofWorkDal : IUnitOfWorkDal
    {
        private readonly Context _context;

        public UnitofWorkDal(Context context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();

        }
    }
}
