using UnityEngine;

namespace AI.Demos.Three.Two
{
    public class Kinematic
    {
        public Vector3 position;
        public float orientation;
        public Vector3 velocity;
        public float rotation;

        public void Update(SteeringOutput steering, float deltaTime)
        {
            position += velocity * deltaTime;
            orientation = SetOrientation();

            velocity += steering.linear * deltaTime;
        }

        private float SetOrientation()
        {
            if(velocity != Vector3.zero) return Mathf.Atan2(velocity.x, velocity.z);

            return orientation;
        }
    }
}