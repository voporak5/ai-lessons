using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI.Demos.Three.Three
{
    public class CollisionAvoidance
    {
        public Kinematic[] targets;
        protected Kinematic character;

        float maxAcceleration;
        float radius;

        public CollisionAvoidance(Kinematic character, float maxAcceleration, float radius)
        {
            this.character = character;
            this.maxAcceleration = maxAcceleration;
            this.radius = radius;
        }

        public virtual SteeringOutput GetSteering()
        {
            SteeringOutput result = new SteeringOutput();
            float shortestTime = float.PositiveInfinity;

            Kinematic firstTarget = null;
            float firstMinSeparation = 0;
            float firstDistance = 0;
            Vector3 firstRelativePos = Vector3.zero;
            Vector3 firstRelativeVel = Vector3.zero;
            Vector3 relativePos = Vector3.zero;

            for (int i = 0; i < targets.Length; i++)
            {
                Kinematic target = targets[i];

                relativePos = character.position- target.position;
                Vector3 relativeVel = character.velocity - target.velocity;
                float distance = relativePos.magnitude;
                float relativeSpeed = relativeVel.magnitude;

                if (relativeSpeed == 0)
                {
                    continue;
                }

                float timeToCollision = -1 * Vector3.Dot(relativePos, relativeVel) / (relativeSpeed * relativeSpeed);

                /* Check if they will collide at all */
                Vector3 separation = relativePos + relativeVel * timeToCollision;
                float minSeparation = separation.magnitude;

                if (minSeparation > 2 * radius) continue;

                //The book uses the below math but it doesn't seem to produce good results
                //whereas the above code copied from https://github.com/sturdyspoon/unity-movement-ai/blob/master/Assets/UnityMovementAI/Scripts/Units/Movement/CollisionAvoidance.cs
                //actually produces very good results.
                //The differences are minor and I am guessing it has something to do with the 
                //direction of Z positive
                /*relativePos = target.position - character.position;
                Vector3 relativeVel = target.velocity - character.velocity;
                float relativeSpeed = relativeVel.magnitude;
                float timeToCollision = Vector3.Dot(relativePos, relativeVel) / relativeVel.sqrMagnitude;

                float distance = relativePos.magnitude;
                float minSeparation = distance - (relativeSpeed * timeToCollision);

                if (minSeparation > 2 * radius) continue;*/

                if (timeToCollision > 0 && timeToCollision < shortestTime)
                {
                    shortestTime = timeToCollision;
                    firstTarget = target;
                    firstMinSeparation = minSeparation;
                    firstDistance = distance;
                    firstRelativePos = relativePos;
                    firstRelativeVel = relativeVel;
                }
            }

            if (firstTarget == null) return result;

            if(firstMinSeparation <= 0 || firstDistance < 2 * radius)
            {
                //Book suggests the commented code
                //but https://github.com/sturdyspoon/unity-movement-ai/blob/master/Assets/UnityMovementAI/Scripts/Units/Movement/CollisionAvoidance.cs
                //suggests the uncommented code which produces desireable behavior
                //relativePos = firstTarget.position - character.position;
                relativePos =  character.position - firstTarget.position;
            }
            else
            {
                relativePos = firstRelativePos + (firstRelativeVel * shortestTime);
            }

            relativePos.Normalize();
            
            result.linear = relativePos * maxAcceleration;
            result.angular = 0;

            return result;
        }
    }
}