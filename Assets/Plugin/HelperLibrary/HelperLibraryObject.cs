using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HelperLibrary
{
    public static partial class Extentions
    {
        public static T AutoMapProperties<T, R>(this T target, R reference)
        {
            var refernceInfos = typeof(R).GetProperties().Where(x => x.CanRead);
            typeof(T).GetProperties().Where(x => x.CanWrite).Join(
                refernceInfos,
                targetInfo => new { targetInfo.Name, targetInfo.GetMethod.ReturnType },
                refernceInfo => new { refernceInfo.Name, refernceInfo.GetMethod.ReturnType },
                (targetInfo, refernceInfo) => new { targetInfo, refernceInfo })
            .ToList().ForEach(x =>
                x.targetInfo.SetValue(target, x.refernceInfo.GetValue(reference)));
            return target;
        }

        public static T AutoMapFields<T, R>(this T target, R reference)
        {
            var refernceInfos = typeof(R).GetFields().Where(x => x.IsPublic);
            typeof(T).GetFields().Join(
                refernceInfos,
                targetInfo => new { targetInfo.Name, targetInfo.DeclaringType },
                refernceInfo => new { refernceInfo.Name, refernceInfo.DeclaringType },
                (targetInfo, refernceInfo) => new { targetInfo, refernceInfo })
            .ToList().ForEach(x =>
                x.targetInfo.SetValue(target, x.refernceInfo.GetValue(reference)));
            return target;
        }
    }
}