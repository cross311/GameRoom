using System.Collections.Generic;

namespace GameRoom.GameService.Data
{
    public interface IPlayerRepository
    {
        Player RegisterPlayer(Player player);

        IEnumerable<Player> GetPlayers();

        Player GetPlayerForAccessToken(AccessToken accessToken);
    }
}