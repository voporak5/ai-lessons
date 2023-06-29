using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class Align
    {
        Kinematic character;
        Kinematic target;

        float maxAngularAcceleration;
        float maxRotation;

        float targetRadius = 0f;
        float slowRadius = Mathf.PI/4;

        float timeToTarget = 0.1f;

        public Align(Kinematic character, Kinematic target, float maxAngularAcceleration, float maxRotation)
        {
            this.character = character;
            this.target = target;
            this.maxAngularAcceleration = maxAngularAcceleration;
            this.maxRotation = maxRotation;
        }

        public SteeringOutput GetSteering()
        {
            SteeringOutput result = new SteeringOutput();

            float rotation = target.orientation - character.orientation;
            float rotationSize = 0;
            float targetRotation = 0;
            float angularAcceleration = 0;

            //Limit angle from -pi to pi
            if (Mathf.Abs(rotation) > Mathf.PI)
            {
                int divisibleBy = (int)(rotation / Mathf.PI);
                if (divisibleBy % 2 != 0) divisibleBy++;
                rotation -= (Mathf.PI * 2 * (divisibleBy/2));
                
            }

            rotationSize = Mathf.Abs(rotation);

            if (rotationSize < targetRadius) return null;
            if (rotationSize == 0) return null;

            if (rotationSize > slowRadius) targetRotation = maxRotation;
            else targetRotation = rotationSize / slowRadius;

            targetRotation *= rotation / rotationSize;

            result.angular = targetRotation - character.rotation;
            result.angular /= timeToTarget;

            angularAcceleration = Mathf.Abs(result.angular);
            if(angularAcceleration > maxAngularAcceleration)
            {
                result.angular /= angularAcceleration;
                result.angular *= maxAngularAcceleration;
            }

            result.linear = Vector3.zero;
            return result;
        }
    }
}