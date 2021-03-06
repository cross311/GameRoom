using System;
using System.Linq;
using GameRoom.GameService.Data;
using GameRoom.GameService.Data.InMemory;
using GameRoom.GameService.Data.Models;
using GameRoom.GameService.Data.OrchestrateIO;
using WebGrease.Css.Extensions;

namespace GameRoom.WebAPI
{
    public static class DatabaseConfig
    {
        public static GameServiceDataRepository Setup()
        {
            var inMemoryDatabase = new InMemoryGameServiceDataRepositoryFactory().Build();
            var orchestrateIODatabase = BuildOrchestrateIODatabase(inMemoryDatabase);

            if (ReferenceEquals(orchestrateIODatabase, null))
            {
                inMemoryDatabase = Seed(inMemoryDatabase);
                return inMemoryDatabase;
            }

            return orchestrateIODatabase;
        }

        private static GameServiceDataRepository BuildOrchestrateIODatabase(GameServiceDataRepository inMemoryDatabase)
        {
            if(ReferenceEquals(inMemoryDatabase, null)) throw new ArgumentNullException("inMemoryDatabase");

            var apiKey = Config.OrchestrateIOApiKey();

            if (string.IsNullOrWhiteSpace(apiKey))
                return null;

            var orchestrateIODatabase =
                new OrchestrateIOGameServiceDataRepositoryFactory(apiKey, inMemoryDatabase.PlayerStateRepository,
                    inMemoryDatabase.GameTypeRepository).Build();

            return orchestrateIODatabase;
        }

        private static GameServiceDataRepository Seed(GameServiceDataRepository database)
        {
            var players = new []
            {
                new {Name = "Connor Ross", Email = "cross@mdsol.com", State = PlayerState.Available , Message = "Hey"},
                new {Name = "Dan Hoizner", Email = "dhoizner@mdsol.com", State = PlayerState.Available, Message = "Bam" },
                new {Name = "Gerrard Lindsay", Email = "glindsay@mdsol.com", State = PlayerState.Available, Message = "Oh Ay" },
                new {Name = "Matt Cochran", Email = "mcochran@mdsol.com", State = PlayerState.Available, Message = "Ya Ha" }
            }
                .Select(person =>
                {
                    var player = database.PlayerRepository.RegisterPlayer(new Player(person.Name, person.Email));
                    var status = database.PlayerStatusRepository.UpdatePlayerStatus(new PlayerStatus(player.Id, person.State, person.Message, DateTime.UtcNow));
                    return new {Player = player, Status = status};
                })
                .ToList();

            var rand = new Random();

            database.GameTypeRepository.GetGameTypes()
                .ForEach(gameType =>{
                    var n = players.Count;
                    var index = rand.Next(n);
                    database.GameResultRepository.RecordGameResults(
                        new GameResult(
                            gameType.Name,
                            new TeamResult(rand.Next(20), new[]
                            {
                                players[index % n].Player.Id, players[(index + 1) % n].Player.Id
                            }),
                            new TeamResult(rand.Next(20), new[]
                            {
                                players[(index + 2) % n].Player.Id, players[(index + 3) % n].Player.Id
                            })
                        ));
                });

            return database;
        }
    }
}