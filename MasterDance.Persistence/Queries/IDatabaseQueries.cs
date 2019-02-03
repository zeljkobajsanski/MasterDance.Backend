using System.Collections.Generic;
using System.Threading.Tasks;
using MasterDance.Persistence.QueryTypes;

namespace MasterDance.Persistence.Queries
{
    public interface IDatabaseQueries
    {
        IEnumerable<MembershipsAndPayments> GetMembershipsAndPayments(int? memberId);
    }
}