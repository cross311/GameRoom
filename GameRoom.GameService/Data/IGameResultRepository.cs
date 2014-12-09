using System;
using System.Collections.Generic;
using GameRoom.GameService.Data.Models;

namespace GameRoom.GameService.Data
{
    public interface IGameResultRepository
    {
        IEnumerable<GameResult> GetGameResults();

        IEnumerable<GameResult> GetGameResultsForPlayer(Guid playerId);

        IEnumerable<GameResult> GetGameResultsForGameType(string gameType);

        GameResult RecordGameResults(GameResult gameResult);

        GameResult UpdateGameResults(GameResult gameResult);
    }
}