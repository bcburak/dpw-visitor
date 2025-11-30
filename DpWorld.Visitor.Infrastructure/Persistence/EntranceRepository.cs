using DpWorld.Visitor.Application.Interfaces;
using DpWorld.Visitor.Domain.Entities;
using VisitorReg.Infrastructure.Persistence;

namespace DpWorld.Visitor.Infrastructure.Persistence;

public class EntranceRepository : IEntranceRepository
{
    private readonly InMemoryDatabase _db;

    public EntranceRepository(InMemoryDatabase db)
    {
        _db = db;
    }

    public Entrance? GetById(string id)
    {
        return _db.Entrances.FirstOrDefault(e => e.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
    }
}
