using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class Obstacle : MonoBehaviour
    {
        Kinematic mKinematic;

        private void Awake()
        {
            mKinematic = new Kinematic();
            mKinematic.position = transform.position;

            mKinematic.velocity = transform.forward * 3f;
        }

        void Update()
        {
            mKinematic.Update(new SteeringOutput(), 10f, Time.deltaTime);

            transform.position = new Vector3(mKinematic.position.x, 0.5f, mKinematic.position.z);
            //transform.eulerAngles = new Vector3(0, mKinematic.orientation * Mathf.Rad2Deg, 0);
        }

        public Kinematic GetKinematic()
        {
            return mKinematic;
        }
    }
}