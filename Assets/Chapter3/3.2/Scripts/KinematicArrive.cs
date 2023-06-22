using UnityEngine;

namespace AI.Demos.Three.Two
{
    public class KinematicArrive
    {
        public Vector3 target;
        public Vector3 position;
        public float orientation;

        public float maxSpeed = 0.5f;
        private float maxSpeedSquared;

        public float radius = 2;
        private float radiusSquared;
        public float timeToTarget = 0.25f;

        private KinematicSteeringOutput mKinematicSteeringOutput;

        public KinematicArrive()
        {
            mKinematicSteeringOutput = new KinematicSteeringOutput();
            maxSpeedSquared = maxSpeed * maxSpeed;
            radiusSquared = radius * radius;
        }

        public void Update(float deltaTime)
        {
            position += mKinematicSteeringOutput.velocity * deltaTime;

            SetSteering();
        }

        private void SetSteering()
        {
            mKinematicSteeringOutput.velocity = target - position;

            if(mKinematicSteeringOutput.velocity.magnitude < radiusSquared)
            {
                mKinematicSteeringOutput.velocity = Vector3.zero;
                return;
            }

            mKinematicSteeringOutput.velocity /= timeToTarget;

            if (mKinematicSteeringOutput.velocity.magnitude > maxSpeedSquared)
            {
                mKinematicSteeringOutput.velocity.Normalize();
                mKinematicSteeringOutput.velocity *= maxSpeed;
            }

            //Get angle in radians based on the vector
            orientation = Mathf.Atan2(mKinematicSteeringOutput.velocity.x, mKinematicSteeringOutput.velocity.z);
        }
    }
}