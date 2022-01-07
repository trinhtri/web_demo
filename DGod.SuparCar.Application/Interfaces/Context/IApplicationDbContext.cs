using System.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DGod.SuparCar.Application.Interfaces.Context;

public interface IApplicationDbContext
{
    IDbConnection Connection { get; }
    bool HasChanges { get; }

    EntityEntry Entry(object entity);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}