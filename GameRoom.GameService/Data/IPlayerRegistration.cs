using System.Collections.Generic;

namespace GameRoom.GameService.Data
{
    public interface IPlayerRegistration
    {
        Player RegisterPlayer(PlayerRegistration playerRegistration);

        IEnumerable<Player> GetPlayers();

        Player GetPlayerForAccessToken(AccessToken accessToken);
    }
}