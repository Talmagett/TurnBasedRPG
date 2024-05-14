using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace SaveSystem.SaveSystem
{
    public sealed class GameRepository : IGameRepository
    {
        private const string GAME_SAVE_FILENAME = "save.txt";

        private Dictionary<string, string> gameState = new();
        
        public void LoadState()
        {
            string path = Application.persistentDataPath + $"/{GAME_SAVE_FILENAME}";
            if(File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                
                var data = reader.ReadToEnd();
                reader.Close();
                
                var gameData = (CryptoServiceAES.Decrypt(data));
                this.gameState = JsonConvert.DeserializeObject<Dictionary<string, string>>(gameData);
            }
            else
            {
                this.gameState = new Dictionary<string, string>();
            }
        }

        public void SaveState()
        {
            var serializedState = JsonConvert.SerializeObject(this.gameState);

            var encrypt = CryptoServiceAES.Encrypt(serializedState);

            string path = Application.persistentDataPath + $"/{GAME_SAVE_FILENAME}";
            StreamWriter writer = new StreamWriter(path, false);
            writer.WriteLine(encrypt);
            writer.Close();
        }

        public T GetData<T>()
        {
            var serializedData = this.gameState[typeof(T).Name];
            return JsonConvert.DeserializeObject<T>(serializedData);
        }

        public bool TryGetData<T>(out T value)
        {
            if (this.gameState.TryGetValue(typeof(T).Name, out var serializedData))
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

            this.gameState[typeof(T).Name] = serializedData;
        }
    }
}