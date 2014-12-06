using System.Collections.Generic;

namespace GameRoom.GameService.Data
{
    public interface IGameResultRepository
    {
        IEnumerable<GameResult> GetGameResults();

        IEnumerable<GameResult> GetGameResultsForPlayer(int player);

        IEnumerable<GameResult> GetGameResultsForGameType(string gameType);

        GameResult RecordGameResults(GameResult gameResult);

        GameResult UpdateGameResults(GameResult gameResult);
    }
}