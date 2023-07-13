using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class Pursue : Seek
    {
        public new Kinematic target;

        private float maxPrediction;
        private float maxPredictionSquared;

        public Pursue(Kinematic character, float maxPrediction, float maxAcceleration)
            : base(character, maxAcceleration)
        {
            this.maxPrediction = maxPrediction;

            maxPredictionSquared = maxPrediction * maxPrediction;
        }

        public override SteeringOutput GetSteering()
        {
            Vector3 direction = target.position - character.position;
            float distanceSquared = direction.sqrMagnitude;

            float speedSquared = character.velocity.sqrMagnitude;
            float prediction = 0;

            if(speedSquared <= distanceSquared / maxPredictionSquared)
            {
                prediction = maxPrediction;   
            }
            else
            {
                prediction = direction.magnitude / character.velocity.magnitude;
            }

            base.target = target.Clone();
            base.target.position += target.velocity * prediction;

            return base.GetSteering();
        }
    }
}