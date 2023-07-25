using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class ObstacleAvoidance : Seek
    {
        CollisionDetector detector;

        float avoidDistance;

        float lookahead;

        public ObstacleAvoidance(Kinematic character, float maxAcceleration, float avoidDistance, float lookahead)
            : base(character,maxAcceleration)
        {
            detector = new CollisionDetector();
            this.avoidDistance = avoidDistance;
            this.lookahead = lookahead;
        }

        public override SteeringOutput GetSteering()
        {
            Vector3 ray = character.velocity;
            ray.Normalize();
            ray *= lookahead;

            Collision collision = detector.GetCollision(character.position, ray);

            if (collision == null) return null;

            Kinematic k = new Kinematic();
            k.position = collision.position + collision.normal * avoidDistance;
            target = k;

            return base.GetSteering();
        }
    }
}