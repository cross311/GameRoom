using System;
using Newtonsoft.Json.Linq;
using Orchestrate.Net;

namespace GameRoom.GameService.Data.OrchestrateIO
{
    internal class OrchestrateResultToModelMapper<TModel> : IOrchestrateResultToModelMapper<TModel>
    {
        public TModel Build<TJsonModel>(Result result) where TJsonModel : IJsonModel<TModel>
        {
            if (ReferenceEquals(result, null)) throw new ArgumentNullException("result");
            if (ReferenceEquals(result.Value, null)) throw new NotSupportedException("result.Value must not be null");

            var value = result.Value as JObject;

            if (ReferenceEquals(value, null)) throw new NotSupportedException("result.value must be a JObject");

            var model = value.ToObject<TJsonModel>();
            return model.ToModel();
        }
    }
}