using DpWorld.Visitor.Application.Interfaces;
using DpWorld.Visitor.Domain.Entities;

namespace DpWorld.Visitor.Application.Services;

public class VisitorService : IVisitorService
{
    private readonly IVisitorRepository _visitorRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IEntranceRepository _entranceRepository;

    public VisitorService(
        IVisitorRepository visitorRepository,
        ITeamRepository teamRepository,
        IEntranceRepository entranceRepository)
    {
        _visitorRepository = visitorRepository;
        _teamRepository = teamRepository;
        _entranceRepository = entranceRepository;
    }

    public DpWorld.Visitor.Domain.Entities.Visitor CheckIn(string name, string email, string company, int teamId, string entranceId, bool rulesAccepted)
    {
        // Business Rule: Entrance ID must be present
        if (string.IsNullOrWhiteSpace(entranceId))
        {
            throw new ArgumentException("Entrance ID is required.");
        }

        // Validate Entrance ID
        var entrance = _entranceRepository.GetById(entranceId);
        if (entrance == null)
        {
            throw new ArgumentException("Invalid Entrance ID.");
        }

        // Validate Team
        var team = _teamRepository.GetById(teamId);
        if (team == null)
        {
            throw new ArgumentException("Invalid Team selected.");
        }

        // Business Rule: Rules & Policies must be accepted
        if (!rulesAccepted)
        {
            throw new ArgumentException("You must accept the rules and policies.");
        }

        var visitor = new DpWorld.Visitor.Domain.Entities.Visitor
        {
            Name = name,
            Email = email,
            Company = company,
            TeamId = teamId,
            EntranceId = entranceId,
            CheckInTime = DateTime.UtcNow
        };

        _visitorRepository.Add(visitor);

        return visitor;
    }

    public IEnumerable<Team> GetTeams()
    {
        return _teamRepository.GetAll();
    }
}
