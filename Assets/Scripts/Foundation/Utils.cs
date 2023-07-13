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

        public static float DistNearestPointSegment(Vector3 pos, Vector3 segStart, Vector3 segEnd)
        {
            Vector3 qPrime = PointSegment(pos, segStart, segEnd);
            Vector3 distance = qPrime - pos;
            return distance.magnitude;
        }

        public static Vector3 PointSegment(Vector3 pos,Vector3 segStart, Vector3 segEnd)
        {
            Vector3 qMinusStart = pos - segStart;
            Vector3 v = segEnd - segStart;
            float vDotQMinusStart = Vector3.Dot(v,qMinusStart);
            float vDotv = Vector3.Dot(v, v);
            float t = vDotQMinusStart / vDotv;
            Vector3 qPrime = Vector3.zero;

            if (t < 0) qPrime = segStart;
            else if (t > 1) qPrime = segEnd;
            else qPrime = segStart + (v * t);

            return qPrime;
        }
    }
}