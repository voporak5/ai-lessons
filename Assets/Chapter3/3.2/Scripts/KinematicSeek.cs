using UnityEngine;

namespace AI.Demos.Three.Two
{
    public class KinematicSeek
    {
        public Vector3 target;
        public Vector3 position;
        public float orientation;

        public float maxSpeed = 0.5f;

        private KinematicSteeringOutput mKinematicSteeringOutput;

        public KinematicSeek()
        {
            mKinematicSteeringOutput = new KinematicSteeringOutput();
        }

        public void Update(float deltaTime)
        {
            position += mKinematicSteeringOutput.velocity * deltaTime;

            SetSteering();
        }

        private void SetSteering()
        {
            mKinematicSteeringOutput.velocity = target - position;
            mKinematicSteeringOutput.velocity.Normalize();
            mKinematicSteeringOutput.velocity *= maxSpeed;

            //Get angle in radians based on the vector
            orientation = Mathf.Atan2(mKinematicSteeringOutput.velocity.x, mKinematicSteeringOutput.velocity.z);
        }
    }
}