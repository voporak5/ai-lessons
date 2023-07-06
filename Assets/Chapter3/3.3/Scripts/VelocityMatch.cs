using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class VelocityMatch
    {
        Kinematic character;
        Kinematic target;

        float maxAcceleration;
        float timeToTarget = 0.1f;

        float maxAccelerationSquared;

        public VelocityMatch(Kinematic character, Kinematic target, float maxAcceleration)
        {
            this.character = character;
            this.target = target;
            this.maxAcceleration = maxAcceleration;

            maxAccelerationSquared = maxAcceleration * maxAcceleration;
        }

        public SteeringOutput GetSteering()
        {
            SteeringOutput result = new SteeringOutput();

            result.linear = target.velocity - character.velocity;
            result.linear /= timeToTarget;

            if(result.linear.sqrMagnitude > maxAccelerationSquared)
            {
                result.linear.Normalize();
                result.linear *= maxAcceleration;
            }

            result.angular = 0;
            return result;
        }
    }
}