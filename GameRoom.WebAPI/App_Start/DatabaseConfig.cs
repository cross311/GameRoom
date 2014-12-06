using System;
using System.Linq;
using GameRoom.GameService.Data;
using GameRoom.GameService.Data.InMemory;
using GameRoom.GameService.Data.Models;
using WebGrease.Css.Extensions;

namespace GameRoom.WebAPI
{
    public static class DatabaseConfig
    {
        public static GameServiceDataRepository Setup()
        {
            var database = new InMemoryGameServiceDataRepositoryFactory().Build();

            database = Seed(database);
            return database;
        }

        private static GameServiceDataRepository Seed(GameServiceDataRepository database)
        {
            var players = new []
            {
                new {Name = "Connor Ross", Email = "cross@mdsol.com", State = PlayerState.Available , Message = "Hey"},
                new {Name = "Dan Hoizner", Email = "dhoizner@mdsol.com", State = PlayerState.Available, Message = "Bam" },
                new {Name = "Gerrard Lindsey", Email = "glindsey@mdsol.com", State = PlayerState.Available, Message = "Oh Ay" },
                new {Name = "Matt Cochran", Email = "mcochran@mdsol.com", State = PlayerState.Available, Message = "Ya Ha" }
            }
                .Select(person =>
                {
                    var player = database.PlayerRepository.RegisterPlayer(new Player(person.Name, person.Email));
                    var status = database.PlayerStatusRepository.UpdatePlayerStatus(new PlayerStatus(player.Id, person.State, person.Message, DateTime.UtcNow));
                    return new {Player = player, Status = status};
                })
                .ToList();

            database.GameTypeRepository.GetGameTypes()
                .ForEach(gameType => database.GameResultRepository.RecordGameResults(
                    new GameResult(
                        gameType.Name, 
                        new TeamResult(8, new[]
                        {
                            players[0].Player.Id, players[1].Player.Id
                        }), 
                        new TeamResult( 4, new[]
                        {
                            players[2].Player.Id, players[3].Player.Id
                        })
                        )));

            return database;
        }
    }
}