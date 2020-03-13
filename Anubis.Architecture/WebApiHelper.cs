using System;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Anubis.Architecture
{
    public static class WebApiHelper
    {
        public enum EnumAcceptHeaders
        {
            Json
        }

        public static TEntity GetModelFromRepsonce<TEntity>(string requestUrl, EnumAcceptHeaders acceptHeaders, string selectToken = "") where TEntity : class, new()
        {
            TEntity model = Activator.CreateInstance<TEntity>();

            RestClient restClient = new RestClient(requestUrl);
            RestRequest restRequest = new RestRequest(Method.GET);

            restRequest.AddHeader("accept", "application/json");

            IRestResponse restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode != HttpStatusCode.OK) return model;

            if (!string.IsNullOrEmpty(selectToken))
            {
                var jToken = JToken.Parse(restResponse.Content);
                model = jToken.SelectToken(selectToken).ToObject<TEntity>();
            }
            else
            {
                model = JsonConvert.DeserializeObject<TEntity>(restResponse.Content);
            }

            return model;
        }
    }
}
