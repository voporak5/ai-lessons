using UnityEngine;
using AI.Foundation;

namespace AI.Demos.Three.Three
{
    public class LookWhereYoureGoing : Align
    {
        public LookWhereYoureGoing(Kinematic character, float maxAngularAcceleration, float maxRotation)
            : base(character, maxAngularAcceleration, maxRotation)
        {

        }

        public override SteeringOutput GetSteering()
        {
            Vector3 velocity = character.velocity;

            if (velocity.sqrMagnitude == 0) return null;

            //Pseudo code says -direction.x but unity z forward is positive so
            //I think that's why it negative does not work and needs to be positive
            target.orientation = Mathf.Atan2(velocity.x, velocity.z);

            return base.GetSteering();
        }
    }
}