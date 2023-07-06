using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class Arrive
    {
        public Kinematic target;
        Kinematic character;        

        float maxAcceleration;
        float maxSpeed;

        float targetRadius = 5;
        float slowRadius = 10;

        float timeToTarget = 0.1f;

        float maxAccelerationSquared;
        float targetRadiusSquared;
        float slowRadiusSquared;

        public Arrive(Kinematic character, float maxAcceleration, float maxSpeed)
        {
            this.character = character;
            this.maxAcceleration = maxAcceleration;
            this.maxSpeed = maxSpeed;

            maxAccelerationSquared = maxAcceleration * maxAcceleration;
            targetRadiusSquared = targetRadius * targetRadius;
            slowRadiusSquared = slowRadius * slowRadius;
        }

        public virtual SteeringOutput GetSteering()
        {
            SteeringOutput result = new SteeringOutput();

            Vector3 direction = target.position - character.position;
            float distanceSquared = direction.sqrMagnitude;
            float distance = Mathf.Sqrt(distanceSquared);

            //Maybe just return result right away?
            if (distanceSquared < targetRadiusSquared) return null;

            float targetSpeed = 0;

            if (distanceSquared > slowRadiusSquared) targetSpeed = maxSpeed;
            else targetSpeed = (maxSpeed * distance) / slowRadius;


            Vector3 targetVelocity = direction;
            targetVelocity.Normalize();
            targetVelocity *= targetSpeed;

            result.linear = targetVelocity - character.velocity;
            result.linear /= timeToTarget;

            if(result.linear.sqrMagnitude > maxAccelerationSquared)
            {
                result.linear.Normalize();
                result.linear.x *= maxAcceleration;
            }

            result.angular = 0;
            return result;
        }
    }
}