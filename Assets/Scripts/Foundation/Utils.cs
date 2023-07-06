using UnityEngine;

namespace AI.Foundation
{
    public static class Utils
    {
        public static float MapFromMinusPiToPi(float rotation)
        {
            float absRotation = Mathf.Abs(rotation);
            if (absRotation <= Mathf.PI) return rotation;

            int divisibleBy = (int)(rotation / Mathf.PI);
            if (divisibleBy % 2 != 0) divisibleBy++;
            rotation -= (Mathf.PI * 2 * (divisibleBy / 2));
            return rotation;
        }
    }
}