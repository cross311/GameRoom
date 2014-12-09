using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using GameRoom.GameService;
using GameRoom.GameService.Data.InMemory;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GameRoom.WebAPI.Startup))]

namespace GameRoom.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var gameServiceDataRepository = DatabaseConfig.Setup();
            var gameRoomApplication = new GameRoomApplicationFactory(gameServiceDataRepository).Build();

            var config = new HttpConfiguration();
            WebApiConfig.Register(config, gameRoomApplication);
            app.UseWebApi(config);
        }
    }

    internal static class Config
    {
        public static string OrchestrateIOApiKey()
        {
            var apiKey = ConfigurationManager.AppSettings["orchestrate_apikey"];

            return apiKey;
        }
    }
}
