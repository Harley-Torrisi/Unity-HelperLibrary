using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelperLibrary
{
    public static partial class Extentions
    {
        #region Position
        public static Transform PositionX(this Transform transform, float x) => transform.ChangePositionAxi(Axis.x, x);

        public static Transform PositionY(this Transform transform, float y) => transform.ChangePositionAxi(Axis.y, y);

        public static Transform PositionZ(this Transform transform, float z) => transform.ChangePositionAxi(Axis.z, z);

        public static Transform LocalPositionX(this Transform transform, float x) => transform.ChangePositionAxi(Axis.x, x, false);

        public static Transform LocalPositionY(this Transform transform, float y) => transform.ChangePositionAxi(Axis.y, y, false);

        public static Transform LocalPositionZ(this Transform transform, float z) => transform.ChangePositionAxi(Axis.z, z, false);

        public static Transform ChangePositionAxi(this Transform transform, Axis axi, float val, bool worldPos = true)
        {
            Vector3 newPos = new Vector3()
            {
                x = (axi == Axis.x) ? val : transform.position.x,
                y = (axi == Axis.y) ? val : transform.position.y,
                z = (axi == Axis.z) ? val : transform.position.z
            };

            if (worldPos)
                transform.position = newPos;
            else
                transform.localPosition = newPos;

            return transform;
        }

        public enum Axis
        {
            x,
            y,
            z
        }
        #endregion


        #region Rotation
        /// <summary>
        /// Already calculates delta-time, no need to use in function call.
        /// </summary>
        public static Transform LookAtOverTime(this Transform transform, Transform target, float speed, IgnoreAxis ignoreAxi = IgnoreAxis.none)
        {
            Vector3 targetDirection = target.position - transform.position;
            switch (ignoreAxi)
            {
                case IgnoreAxis.x:
                    targetDirection.x = 0;
                    break;
                case IgnoreAxis.y:
                    targetDirection.y = 0;
                    break;
                case IgnoreAxis.z:
                    targetDirection.z = 0;
                    break;
                default:
                    break;
            }
            var targetRotation = Quaternion.LookRotation(targetDirection);
            var deltaAngle = Quaternion.Angle(transform.rotation, targetRotation);

            if (deltaAngle != 0.00F)
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime / deltaAngle);

            return transform;
        }

        public enum IgnoreAxis
        {
            none,
            x,
            y,
            z
        }
        #endregion
    }
}