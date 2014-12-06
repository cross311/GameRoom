using System.Collections.Generic;

namespace GameRoom.GameService.Data
{
    public interface IGameTypeRepository
    {
        IEnumerable<GameType> GetGameTypes();
    }
}