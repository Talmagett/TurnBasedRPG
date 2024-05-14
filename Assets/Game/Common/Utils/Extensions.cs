using UnityEngine;
using Random = System.Random;

namespace Game.Common.Utils
{
    public static class Extentions
    {
        public static Color GetRandomColor(this Color color)
        {
            return new Color(
                UnityEngine.Random.Range(0f, 1f),
                UnityEngine.Random.Range(0f, 1f),
                UnityEngine.Random.Range(0f, 1f)
            );
        }

        //randomizer

        public static void Shuffle<T>(this Random rng, T[] array)
        {
            var n = array.Length;
            while (n > 1)
            {
                var k = rng.Next(n--);
                var temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}