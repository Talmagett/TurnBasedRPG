using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
using System.Reflection;

namespace Sample
{
    public class DebugCharacter : MonoBehaviour
    {
        private Character _character;

        [Inject]
        public void Construct(Character character)
        {
            _character = character;
        }

        [Button]
        public void GetStats()
        {
            ClearLog();
            string printer="";
            foreach (var (key, value) in _character.GetStats()) 
                printer+=($"{key} : {value} \n");
            print(printer);
        }
        
        //этот класс не должен находиться здесь, чисто ради дебага оставил, ибо лень )
        private void ClearLog()
        {
            var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
            var type = assembly.GetType("UnityEditor.LogEntries");
            var method = type.GetMethod("Clear");
            method.Invoke(new object(), null);
        }
    }
}