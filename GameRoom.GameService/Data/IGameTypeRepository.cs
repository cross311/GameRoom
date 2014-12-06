using System.Collections.Generic;
using GameRoom.GameService.Data.Models;

namespace GameRoom.GameService.Data
{
    public interface IGameTypeRepository
    {
        IEnumerable<GameType> GetGameTypes();
    }
}