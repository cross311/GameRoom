using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using GameRoom.GameService;
using GameRoom.GameService.Data;
using GameRoom.GameService.Data.InMemory;
using GameRoom.GameService.Data.Models;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;
using WebGrease.Css.Extensions;

namespace GameRoom.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config, IGameRoomApplication application)
        {
            // dependancy injection
            var container = new UnityContainer();
            container.RegisterInstance(application);
            config.DependencyResolver = new UnityDependencyResolver(container);

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Use camel case for JSON data.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

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
                new {Name = "Dan Hoizner", Email = "glindsey@mdsol.com", State = PlayerState.Available, Message = "Oh Ay" },
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
