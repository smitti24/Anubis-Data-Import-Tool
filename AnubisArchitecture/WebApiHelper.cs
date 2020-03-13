using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AnubisArchitecture
{
    public static class WebApiHelper
    {
        public enum EnumAcceptHeaders
        {
            JSON
        }

        public static async Task<typeModel> GetModelFromRepsonceAsync<typeModel>(string requestUrl, EnumAcceptHeaders acceptHeaders, string selectToken = "")
        {
            typeModel model;
            RestRequest restRequest;
            RestClient restClient;
            IRestResponse restResponse;

            model = Activator.CreateInstance<typeModel>();

            restClient = new RestClient(requestUrl);
            restRequest = new RestRequest(Method.GET);

            restRequest.AddHeader("accept", "application/json");

            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                if (!string.IsNullOrEmpty(selectToken))
                {
                    JToken jToken = JToken.Parse(restResponse.Content);
                    model = (jToken.SelectToken(selectToken)).ToObject<typeModel>();
                }
                else
                {
                    model = JsonConvert.DeserializeObject<typeModel>(restResponse.Content);
                }
            }

            return model;
        }
    }
}
