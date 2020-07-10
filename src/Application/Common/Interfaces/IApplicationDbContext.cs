using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using XirgoTest.Domain.Entities;

namespace XirgoTest.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Vechile> Vechiles { get; set; }
        DbSet<VechileDetail> VechileDetails { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
