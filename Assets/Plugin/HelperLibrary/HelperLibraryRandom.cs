using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HelperLibrary
{
    public struct RandomPlus
    {
        public static bool RandomBool() => UnityEngine.Random.Range(0, 2) == 1;
    }

    public static partial class Extentions
    {
        public static T RandomElement<T>(this List<T> list) =>  (list is null || list.Count == 0) ?  default : (list.Count == 1) ?  list[0] : list[UnityEngine.Random.Range(0, list.Count)];
    }
}