using UnityEngine;

namespace AI.Foundation
{
    public static class Utils
    {
        /*public static float MapFromMinusPiToPi(float rotation)
        {
            float absRotation = Mathf.Abs(rotation);
            if (absRotation <= Mathf.PI) return rotation;

            int divisibleBy = (int)(rotation / Mathf.PI);
            if (divisibleBy % 2 != 0) divisibleBy++;
            rotation -= (Mathf.PI * 2 * (divisibleBy / 2));
            return rotation;
        }*/

        public static float MapFromMinusPiToPi(float current, float target)
        {
            float degrees = Mathf.DeltaAngle(Mathf.Rad2Deg * current, Mathf.Rad2Deg * target);
            return degrees * Mathf.Deg2Rad;
        }

        public static float RandomBinomial()
        {
            return Random.Range(0f, 1f) - Random.Range(0f, 1f);
        }

        public static Vector3 OrientationAsVector(float orientation)
        {
            float x = /*Mathf.Cos(0) */ 1 * Mathf.Sin(orientation);
            float y = 0;//-Mathf.Sin(0);
            float z = /*Mathf.Cos(0) */ 1 * Mathf.Cos(orientation);

            return new Vector3(x, y, z);
        }

    }
}