using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WHEDU_OA_COMMON_INTERFACES
{
    public interface IDbContextCollection: IDisposable
    {
        TDbContext Get<TDbContext>() where TDbContext : DbContext;
    }
}
