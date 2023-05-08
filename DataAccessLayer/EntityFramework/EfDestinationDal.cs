﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public Destination GetDestinationWithGuide(int id)
        {
            using (var c = new Context())
            {
                return c.Destinations.Where(y=>y.DestinationID==id).Include(x => x.Guide).FirstOrDefault();
            }
        }

        public List<Destination> GetLastFourDestinations()
        {
            using (var c = new Context())
            {
                var values = c.Destinations.OrderByDescending(x => x.DestinationID).Take(4).ToList();
                return values;
            }
        }
    }
}
