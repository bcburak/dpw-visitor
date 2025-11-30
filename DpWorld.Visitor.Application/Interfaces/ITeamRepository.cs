using DpWorld.Visitor.Domain.Entities;

namespace DpWorld.Visitor.Application.Interfaces;

public interface ITeamRepository
{
    IEnumerable<Team> GetAll();
    Team? GetById(int id);
}
