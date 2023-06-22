using UnityEngine;

namespace AI.Demos.Three.One
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
            orientation += rotation * deltaTime;

            velocity += steering.linear * deltaTime;
            rotation += steering.angular * deltaTime;
        }
    }
}