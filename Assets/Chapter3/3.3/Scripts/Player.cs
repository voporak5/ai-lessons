using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class Player : MonoBehaviour
    {
        private Kinematic mKinematic;
        private SteeringOutput mSteering;

        // Start is called before the first frame update
        void Awake()
        {
            mKinematic = new Kinematic();
            mSteering = new SteeringOutput();
            mKinematic.position = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            mSteering.linear = Vector3.zero;

            if (Input.GetKey(KeyCode.W)) mSteering.linear += transform.forward * 1;
            else if (Input.GetKey(KeyCode.S)) mSteering.linear += transform.forward * -1;

            if (Input.GetKey(KeyCode.A)) mSteering.linear += transform.right * -1;
            else if (Input.GetKey(KeyCode.D)) mSteering.linear += transform.right * 1;

            mKinematic.Update(mSteering, 10f,Time.deltaTime);

            transform.position = new Vector3(mKinematic.position.x, 0.5f, mKinematic.position.z);
            transform.eulerAngles = new Vector3(0, mKinematic.orientation * Mathf.Rad2Deg, 0);
        }

        public Kinematic GetKinematic()
        {
            return mKinematic;
        }
    }
    
}