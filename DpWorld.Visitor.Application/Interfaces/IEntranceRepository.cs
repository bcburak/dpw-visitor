using DpWorld.Visitor.Domain.Entities;

namespace DpWorld.Visitor.Application.Interfaces;

public interface IEntranceRepository
{
    Entrance? GetById(string id);
}
