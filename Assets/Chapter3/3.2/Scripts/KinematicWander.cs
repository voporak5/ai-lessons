using UnityEngine;

namespace AI.Demos.Three.Two
{
    public class KinematicWander
    {
        public Vector3 position;
        public float orientation;

        public float maxSpeed = 0.5f;
        public float maxRotation = Mathf.PI;

        private KinematicSteeringOutput mKinematicSteeringOutput;

        public KinematicWander()
        {
            mKinematicSteeringOutput = new KinematicSteeringOutput();
        }

        public void Update(Vector3 fwd, float deltaTime)
        {
            position += mKinematicSteeringOutput.velocity * deltaTime;
            orientation += mKinematicSteeringOutput.rotation * deltaTime;

            SetSteering(fwd);
        }

        private void SetSteering(Vector3 fwd)
        {
            mKinematicSteeringOutput.velocity = maxSpeed * fwd; ;
            mKinematicSteeringOutput.rotation = maxRotation * (UnityEngine.Random.Range(0f, 1f) - UnityEngine.Random.Range(0f, 1f));   
        }
    }
}