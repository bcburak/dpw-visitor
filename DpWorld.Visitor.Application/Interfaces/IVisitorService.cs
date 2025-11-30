using DpWorld.Visitor.Domain.Entities;

namespace DpWorld.Visitor.Application.Interfaces;

public interface IVisitorService
{
    DpWorld.Visitor.Domain.Entities.Visitor CheckIn(string name, string email, string company, int teamId, string entranceId, bool rulesAccepted);
    IEnumerable<Team> GetTeams();
}
