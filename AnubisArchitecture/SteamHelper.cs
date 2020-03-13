using AnubisDataImport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnubisArchitecture
{
    public static class SteamHelper
    {
        private const string STEAM_API_KEY = "344FFBDB9F117DBBCE1A15C0F52E43E4";
        private const string STEAM_BASE_URL = "http://api.steampowered.com/";
        private const string STEAM_STORE_BASE_URL = "http://store.steampowered.com/api/";

        public static List<GameData> GetAllSteamGames()
        {
            List<GameData> games = new List<GameData>();
            GameData game = new GameData();

            string steamProfileUrl = STEAM_BASE_URL + $"ISteamApps/GetAppList/v0002/?&format=json";

            game = WebApiHelper.GetModelFromRepsonceAsync<GameData>(steamProfileUrl, WebApiHelper.EnumAcceptHeaders.JSON).Result;

            return games;
        }


    }
}
