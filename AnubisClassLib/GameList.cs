using System.Collections.Generic;
using Newtonsoft.Json;

namespace Anubis.Models
{
    public class GameDataResponse
    {
        [JsonProperty("applist")]
        public GamesInfo GameResponseInfo { get; set; }
    }

    public class GamesInfo
    {
        [JsonProperty("apps")]
        public List<GameData> ListGames { get; set; }
    }

    public class GameData
    {
        [JsonProperty("appid")]
        public string AppId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
