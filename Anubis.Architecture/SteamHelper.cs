using System.Collections.Generic;
using Anubis.Models;
using PostgreSQLCopyHelper;

namespace Anubis.Architecture
{
    public static class SteamHelper
    {
        private const string SteamApiKey = "2C7079CA074F0700F97801596AF7E1DC";
        private const string SteamBaseUrl = "http://api.steampowered.com/";
        private const string SteamStoreBaseUrl = "http://store.steampowered.com/api/";

        public static List<GameData> GetAllSteamGames()
        {
            string steamGamesUrl = SteamBaseUrl + $"ISteamApps/GetAppList/v0002/?&format=json";
            GameDataResponse gameResponse = WebApiHelper.GetModelFromRepsonce<GameDataResponse>(steamGamesUrl, WebApiHelper.EnumAcceptHeaders.Json);

            List<GameData> gameList = new List<GameData>();
            if (gameResponse.GameResponseInfo.ListGames.Count > 0)
            {
                gameList = gameResponse.GameResponseInfo.ListGames;
            }

            return gameList;
        }

        private static PostgreSQLCopyHelper<GameData> MapToSteamGamesListTableSchema()
        {
            PostgreSQLCopyHelper<GameData> gameDataBulkCopyHelper = new PostgreSQLCopyHelper<GameData>("demo", "game_list")
                .MapText("app_id", gameData => gameData.AppId)
                .MapText("name", gameData => gameData.Name);

            return gameDataBulkCopyHelper;
        }

        public static void BulkCopySteamGamesToDatabase(List<GameData> gameData)
        {
            PostgreSQLCopyHelper<GameData> gameDataBulkCopyHelper = MapToSteamGamesListTableSchema();
            SqlDbHelper.BulkWriteToDatabase(gameDataBulkCopyHelper, gameData);
        }

        public static void ImportSteamGames(List<GameData> gameData, int totalRows, int completedRowsCount)
        {
            string sqlQuery = "INSERT INTO demo.game_list (app_id, name) VALUES ";

            if (gameData == null) return;

            List<string> queryValues = new List<string>();
            foreach (GameData game in gameData)
            {
                if (game.Name.Contains("'"))
                {
                    game.Name = game.Name.Replace("'", "''");
                }

                queryValues.Add($"('{game.AppId}', '{game.Name}')");
            }

            sqlQuery = sqlQuery + string.Join(",", queryValues);

            SqlDbHelper.ExecuteBatchSqlQuery(sqlQuery, totalRows, completedRowsCount);
        }
    }
}
