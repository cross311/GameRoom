using System.Collections.Generic;
using GameRoom.GameService.Data.Models;

namespace GameRoom.GameService.Data
{
    public interface IPlayerRepository
    {
        Player RegisterPlayer(Player player);

        IEnumerable<Player> GetPlayers();

        Player GetPlayerForAccessToken(AccessToken accessToken);
    }
}