using System.Collections.Generic;
using System.Threading.Tasks;
using MasterDance.Persistence.QueryTypes;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Persistence.Queries
{
    public class DatabaseQueries : IDatabaseQueries
    {
        private readonly MasterDanceDbContext _context;

        public DatabaseQueries(MasterDanceDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MembershipsAndPayments> GetMembershipsAndPayments(int? memberId)
        {
            return _context.MembershipsAndPayments.FromSql($"EXECUTE GetMembershipsAndPayments {memberId}");
        }
    }
}