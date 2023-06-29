using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class SteeringOutput
    {
        public Vector3 linear;
        public float angular;

        public override string ToString()
        {
            return string.Format("Linear: {0}, Angular: {1}",linear.ToString(),angular);
        }
    }
}