using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using GameRoom.GameService.Data;
using GameRoom.GameService.Data.Models;
using GameRoom.GameService.Response;

namespace GameRoom.GameService
{
    public interface IGameRoomApplication
    {
        IGameResultService GameResult { get; }

        IPlayerService Player { get; }

        IPlayerStatusService PlayerStatus { get; }
    }
}
