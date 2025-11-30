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
        Teams.Add(new Team { Id = 1, Name = "Engineering" });
        Teams.Add(new Team { Id = 2, Name = "Product" });
        Teams.Add(new Team { Id = 3, Name = "Sales" });
        Teams.Add(new Team { Id = 4, Name = "Marketing" });
        Teams.Add(new Team { Id = 5, Name = "HR" });

        // Seed Entrances
        Entrances.Add(new Entrance { Id = "MAIN-LOBBY", Description = "Main Lobby Entrance" });
        Entrances.Add(new Entrance { Id = "SIDE-DOOR", Description = "Side Staff Entrance" });
        Entrances.Add(new Entrance { Id = "VIP-GATE", Description = "VIP Gate" });
    }
}
