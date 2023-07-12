using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class Wanderer : MonoBehaviour
    {
        Wander mWander;
        Kinematic mKinematic;
        public Transform target;

        private void Awake()
        {
            mKinematic = new Kinematic();
            mKinematic.position = transform.position;
        }

        // Start is called before the first frame update
        void Start()
        {
            mWander = new Wander(mKinematic, 10f, 10f);
        }

        // Update is called once per frame
        void Update()
        {
            SteeringOutput steering = mWander.GetSteering();

            if (steering != null) mKinematic.Update(steering, 10f, Time.deltaTime);

            Debug.Log(mKinematic.velocity);

            transform.position = new Vector3(mKinematic.position.x, 0.5f, mKinematic.position.z);
            transform.eulerAngles = new Vector3(0, mKinematic.orientation * Mathf.Rad2Deg, 0);

            target.position = mWander.target.position;

        }
    }
}