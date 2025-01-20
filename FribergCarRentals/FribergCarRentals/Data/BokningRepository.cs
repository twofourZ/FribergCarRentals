﻿using FribergCarRentals.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FribergCarRentals.Data
{
    public class BokningRepository : GenericRepository<Bokning>
    {
        public BokningRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<Bokning?> FirstOrDefaultAsync(Expression<Func<Bokning, bool>> predicate)
        {
            return await context.Bokningar
                .Include(x => x.Bil)
                .ThenInclude(x => x.Bokningar)
                .FirstOrDefaultAsync(predicate);
        }

        public override async Task<IEnumerable<Bokning>?> FindAllAsync(Expression<Func<Bokning, bool>> predicate)
        {
            return await context.Set<Bokning>()
                .Where(predicate)
                .Include(x => x.Bil)
                .ThenInclude(x => x.Bokningar)
                .ToListAsync();
        }
    }
}
