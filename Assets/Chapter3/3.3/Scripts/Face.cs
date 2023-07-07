using UnityEngine;
using AI.Foundation;

namespace AI.Demos.Three.Three
{
    public class Face : Align
    {
        public new Kinematic target;

        public Face(Kinematic character, float maxAngularAcceleration, float maxRotation)
            : base(character, maxAngularAcceleration, maxRotation)
        {
            
        }

        public override SteeringOutput GetSteering()
        {
            Vector3 direction = target.position - character.position;

            //Pseudo code says return target but target is a kinematic
            //so not sure what exactly to return...
            if (direction.sqrMagnitude == 0)
            {
                //Maybe it just needs to be empty SteeringOutput?
                return new SteeringOutput();
                //return base.GetSteering();
            }

            base.target = target.Clone();
            //Pseudo code says -direction.x but unity z forward is positive so
            //I think that's why it negative does not work and needs to be positive
            base.target.orientation = Mathf.Atan2(direction.x, direction.z);

            return base.GetSteering();
        }
    }
}