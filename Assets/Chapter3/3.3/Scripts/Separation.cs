using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class Separation
    {
        public Kinematic[] targets;
        protected Kinematic character;

        float maxAcceleration;
        float thresholdSquared;

        float decayCoefficient;

        public Separation(Kinematic character,float maxAcceleration, float threshold, float decayCoefficient)
        {
            this.character = character;
            this.maxAcceleration = maxAcceleration;
            this.decayCoefficient = decayCoefficient;

            thresholdSquared = threshold * threshold;
        }

        public virtual SteeringOutput GetSteering()
        {
            SteeringOutput result = new SteeringOutput();

            for(int i = 0; i < targets.Length; i++)
            {
                Kinematic target = targets[i];

                //Book says to do target - character but that points towards
                //the target and it's supposed to separate which it needs to be
                //character - target so I think that's a potential error in the book?
                //This guy also has it character - target so it definitely feels like a book error
                //https://github.com/sturdyspoon/unity-movement-ai/blob/master/Assets/UnityMovementAI/Scripts/Units/Movement/Separation.cs
                //Vector3 direction = target.position - character.position;
                Vector3 direction = character.position - target.position;
                float distanceSquared = direction.sqrMagnitude;

                //Compare squares to prevent unnecessary square root calculations
                if (distanceSquared < thresholdSquared)
                {
                    float strength = Mathf.Min(decayCoefficient / distanceSquared, maxAcceleration);
                    direction.Normalize();
                    result.linear += strength * direction;                    
                }
            }

            return result;
        }
    }
}