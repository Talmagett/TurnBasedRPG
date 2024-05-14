using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Game.App.SaveSystem.SaveSystem
{
    public sealed class GameRepository : IGameRepository
    {
        private const string GAME_SAVE_FILENAME = "save.txt";

        private Dictionary<string, string> gameState = new();

        public T GetData<T>()
        {
            var serializedData = gameState[typeof(T).Name];
            return JsonConvert.DeserializeObject<T>(serializedData);
        }

        public bool TryGetData<T>(out T value)
        {
            if (gameState.TryGetValue(typeof(T).Name, out var serializedData))
            {
                value = JsonConvert.DeserializeObject<T>(serializedData);
                return true;
            }

            value = default;
            return false;
        }

        public void SetData<T>(T value)
        {
            var serializedData = JsonConvert.SerializeObject(value);

            gameState[typeof(T).Name] = serializedData;
        }

        public void LoadState()
        {
            var path = Application.persistentDataPath + $"/{GAME_SAVE_FILENAME}";
            if (File.Exists(path))
            {
                var reader = new StreamReader(path);

                var data = reader.ReadToEnd();
                reader.Close();

                var gameData = CryptoServiceAES.Decrypt(data);
                gameState = JsonConvert.DeserializeObject<Dictionary<string, string>>(gameData);
            }
            else
            {
                gameState = new Dictionary<string, string>();
            }
        }

        public void SaveState()
        {
            var serializedState = JsonConvert.SerializeObject(gameState);

            var encrypt = CryptoServiceAES.Encrypt(serializedState);

            var path = Application.persistentDataPath + $"/{GAME_SAVE_FILENAME}";
            var writer = new StreamWriter(path, false);
            writer.WriteLine(encrypt);
            writer.Close();
        }
    }
}