using DpWorld.Visitor.Application.Interfaces;
using VisitorReg.Infrastructure.Persistence;

namespace DpWorld.Visitor.Infrastructure.Persistence;

public class VisitorRepository : IVisitorRepository
{
    private readonly InMemoryDatabase _db;

    public VisitorRepository(InMemoryDatabase db)
    {
        _db = db;
    }

    public void Add(DpWorld.Visitor.Domain.Entities.Visitor visitor)
    {
        _db.Visitors.Add(visitor);
    }

    public IEnumerable<DpWorld.Visitor.Domain.Entities.Visitor> GetAll()
    {
        return _db.Visitors;
    }
}
