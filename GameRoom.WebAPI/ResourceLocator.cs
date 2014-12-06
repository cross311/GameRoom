﻿using GameRoom.GameService;
using GameRoom.GameService.Data;
using GameRoom.GameService.Data.InMemory;

namespace GameRoom.WebAPI
{
    internal static class ResourceLocator
    {
        public static readonly GameServiceDataRepository GameServiceData = new InMemoryGameServiceDataRepositoryFactory().Build();

        public static readonly IGameRoomApplication GameRoomApplication = new GameService.GameRoomApplication(GameServiceData);
    }
}