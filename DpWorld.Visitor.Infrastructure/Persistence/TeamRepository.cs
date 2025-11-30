using DpWorld.Visitor.Application.Interfaces;
using DpWorld.Visitor.Domain.Entities;
using VisitorReg.Infrastructure.Persistence;

namespace DpWorld.Visitor.Infrastructure.Persistence;

public class TeamRepository : ITeamRepository
{
    private readonly InMemoryDatabase _db;

    public TeamRepository(InMemoryDatabase db)
    {
        _db = db;
    }

    public IEnumerable<Team> GetAll()
    {
        return _db.Teams;
    }

    public Team? GetById(int id)
    {
        return _db.Teams.FirstOrDefault(t => t.Id == id);
    }
}
