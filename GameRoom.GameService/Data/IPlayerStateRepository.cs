using System.Collections.Generic;

namespace GameRoom.GameService.Data
{
    public interface IPlayerStateRepository
    {
        IEnumerable<PlayerState> GetPossiblePlayerStates();
    }
}