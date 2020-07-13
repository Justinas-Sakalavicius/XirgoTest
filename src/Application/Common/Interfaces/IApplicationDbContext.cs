using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using XirgoTest.Domain.Entities;

namespace XirgoTest.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Vehicle> Vehicles { get; set; }
        DbSet<VehicleDetail> VehiclesDetails { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
