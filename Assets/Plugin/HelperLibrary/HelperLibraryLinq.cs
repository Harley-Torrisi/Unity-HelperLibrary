using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HelperLibrary
{
    public static partial class Extentions
    {
        public static List<T> RemoveNullables<T>(this List<T> list) => list.Where(x => x != null).ToList();
    }
}
