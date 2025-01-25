
using UnityEngine;
using System.Collections.Generic;

namespace BubbleOrNot.Utils
{
    public static class ExtensionUtils
    {
        private static readonly System.Random Random = new();

        public static void Shuffle<T>(this IList<T> list)  
        {  
            int n = list.Count;  
            while (n > 1) {  
                n--;  
                int k = Random.Next(n + 1);  
                (list[k], list[n]) = (list[n], list[k]);
            }  
        }

        public static bool IsInMask(this int layer, LayerMask mask) => (layer & mask) != 0;
    }
}