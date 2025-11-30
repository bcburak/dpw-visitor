namespace DpWorld.Visitor.Application.Interfaces;

public interface IVisitorRepository
{
    void Add(DpWorld.Visitor.Domain.Entities.Visitor visitor);
    IEnumerable<DpWorld.Visitor.Domain.Entities.Visitor> GetAll();
}
