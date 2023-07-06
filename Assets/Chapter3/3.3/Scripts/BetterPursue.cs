using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class BetterPursue : Arrive
    {
        public new Kinematic target;

        private Kinematic character;

        private float maxPrediction;
        private float maxPredictionSquared;

        public BetterPursue(Kinematic character, float maxPrediction, float maxAcceleration, float maxSpeed)
            : base(character, maxAcceleration, maxSpeed)
        {
            this.character = character;
            this.maxPrediction = maxPrediction;

            maxPredictionSquared = maxPrediction * maxPrediction;
        }

        public override SteeringOutput GetSteering()
        {
            Vector3 direction = target.position - character.position;
            float distanceSquared = direction.sqrMagnitude;

            float speedSquared = character.velocity.sqrMagnitude;
            float prediction = 0;

            if (speedSquared <= distanceSquared / maxPredictionSquared)
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