using DpWorld.Visitor.Domain.Entities;
using System.Collections.Concurrent;

namespace VisitorReg.Infrastructure.Persistence;

public class InMemoryDatabase
{
    public ConcurrentBag<Visitor> Visitors { get; } = new();
    public List<Team> Teams { get; } = new();
    public List<Entrance> Entrances { get; } = new();

    public InMemoryDatabase()
    {
        SeedData();
    }

    private void SeedData()
    {
        // Seed Teams
        Teams.Add(new Team { Id = 1, Name = "IT" });
        Teams.Add(new Team { Id = 2, Name = "Sales" });
        Teams.Add(new Team { Id = 3, Name = "Marketing" });
        Teams.Add(new Team { Id = 4, Name = "HR" });

        // Seed Entrances
        Entrances.Add(new Entrance { Id = "MAIN-ENTRANCE", Description = "Main Entrance" });
        Entrances.Add(new Entrance { Id = "SIDE-DOOR", Description = "Side Entrance" });
        Entrances.Add(new Entrance { Id = "VIP-GATE", Description = "VIP Gate" });
    }
}
