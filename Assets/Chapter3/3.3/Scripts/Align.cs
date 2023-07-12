using UnityEngine;
using AI.Foundation;

namespace AI.Demos.Three.Three
{
    public class Align
    {
        public Kinematic target;
        protected Kinematic character;        

        float maxAngularAcceleration;
        float maxRotation;

        float targetRadius = 0f;
        float slowRadius = Mathf.PI/4;

        float timeToTarget = 0.1f;

        public Align(Kinematic character, float maxAngularAcceleration, float maxRotation)
        {
            this.character = character;
            this.maxAngularAcceleration = maxAngularAcceleration;
            this.maxRotation = maxRotation;
        }

        public virtual SteeringOutput GetSteering()
        {
            SteeringOutput result = new SteeringOutput();

            float rotation = target.orientation - character.orientation;
            float rotationSize = 0;
            float targetRotation = 0;
            float angularAcceleration = 0;

            //Limit angle from -pi to pi
            rotation = Utils.MapFromMinusPiToPi(character.orientation,target.orientation);
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