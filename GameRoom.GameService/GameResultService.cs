using System;
using System.Collections.Generic;
using GameRoom.GameService.Data;
using GameRoom.GameService.Data.Models;
using GameRoom.GameService.Response;

namespace GameRoom.GameService
{
    internal class GameResultService : IGameResultService
    {
        private readonly IGameTypeRepository _GameTypeRepository;
        private readonly IGameResultRepository _GameResultRepository;

        public GameResultService(
            IGameTypeRepository gameTypeRepository,
            IGameResultRepository gameResultRepository)
        {
            if (ReferenceEquals(gameTypeRepository, null)) throw new ArgumentNullException("gameTypeRepository");
            if (ReferenceEquals(gameResultRepository, null)) throw new ArgumentNullException("gameResultRepository");

            _GameTypeRepository = gameTypeRepository;
            _GameResultRepository = gameResultRepository;
        }

        public IGameRoomResponse<IEnumerable<GameType>> AvailableGameTypes()
        {
            return _GameTypeRepository.GetGameTypes().Success();
        }

        public IGameRoomResponse<IEnumerable<GameResult>> All()
        {
            return _GameResultRepository.GetGameResults().Success();
        }

        public IGameRoomResponse<IEnumerable<GameResult>> AllForPlayer(int playerId)
        {
            return _GameResultRepository.GetGameResultsForPlayer(playerId).Success();
        }

        public IGameRoomResponse<GameResult> Record(GameResult gameResult)
        {
            return _GameResultRepository.RecordGameResults(gameResult).Success();
        }

        public IGameRoomResponse<GameResult> Update(GameResult gameResult)
        {
            return _GameResultRepository.UpdateGameResults(gameResult).Success();
        }
    }
}