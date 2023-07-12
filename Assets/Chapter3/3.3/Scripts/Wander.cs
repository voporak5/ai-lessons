using UnityEngine;
using AI.Foundation;

namespace AI.Demos.Three.Three
{
    public class Wander : Face
    {
        float wanderOffset = 0f;
        float wanderRadius = 10f;

        float wanderRate = Mathf.PI;

        float wanderOrientation;

        float maxAcceleration = 10f;

        public Wander(Kinematic character, float maxAngularAcceleration, float maxRotation)
            : base(character, maxAngularAcceleration, maxRotation)
        {

        }

        public override SteeringOutput GetSteering()
        {
            //Pick a random left/right rotation direction
            float binomial = Utils.RandomBinomial();
            wanderOrientation += binomial * wanderRate;
            
            float targetOrientation = wanderOrientation + character.orientation;

            //Define center point of circle based on target orientation
            //and pick a random point from the radius distance of the center point
            //and set that as the target to face
            target = new Kinematic();
            target.position = character.position + (wanderOffset * Utils.OrientationAsVector(character.orientation));
            target.position += wanderRadius * Utils.OrientationAsVector(targetOrientation);
            
            //Set velocity to be forward of the character
            SteeringOutput result = base.GetSteering();
            Vector3 dir = Utils.OrientationAsVector(character.orientation);
            result.linear = maxAcceleration * dir;

            return result;
        }
    }
}