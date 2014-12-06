﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GameRoom.GameService;
using GameRoom.GameService.Data;
using GameRoom.GameService.Data.Models;

namespace GameRoom.WebAPI.Controllers
{
    public class GameTypesController : ApiController
    {
        private readonly IGameRoomApplication _GameRoom;

        public GameTypesController()
            : this(ResourceLocator.GameRoomApplication)
        {
        }

        public GameTypesController(IGameRoomApplication gameRoom)
        {
            _GameRoom = gameRoom;
        }

        public IEnumerable<GameType> Get()
        {
            return _GameRoom.GetGameTypes().HandleFailure(Request);
        }
    }
}
