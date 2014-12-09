using System;
using Orchestrate.Net;

namespace GameRoom.GameService.Data.OrchestrateIO
{
    internal interface IOrchestrateResultToModelMapper<TModel>
    {
        TModel Build<TJsonModel>(Result result) where TJsonModel : IJsonModel<TModel>;
    }
}
