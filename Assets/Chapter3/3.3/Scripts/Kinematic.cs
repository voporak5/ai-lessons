using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class Kinematic
    {
        public Vector3 position;
        public float orientation;
        public Vector3 velocity;
        public float rotation;

        public void Update(SteeringOutput steering, float maxSpeed, float deltaTime)
        {
            position += velocity * deltaTime;
            orientation += rotation * deltaTime;

            velocity += steering.linear * deltaTime;
            rotation += steering.angular * deltaTime;

            //Limit acceleration to a max speed.
            //Typically drag will handle this
            if(velocity.sqrMagnitude > maxSpeed * maxSpeed)
            {
                velocity.Normalize();
                velocity *= maxSpeed;
            }
        }

        public Kinematic Clone()
        {
            Kinematic clone = new Kinematic();

            clone.position = position;
            clone.orientation = orientation;
            clone.velocity = velocity;
            clone.rotation = rotation;

            return clone;
        }
    }
}