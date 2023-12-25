using UnityEngine;

namespace Tools
{
    public static class Layers
    {
        public static LayerMask Ground = 1<<9;
        public static LayerMask Enemies = 1<<13;
        public static LayerMask Units = 1<<23;
    }
}
