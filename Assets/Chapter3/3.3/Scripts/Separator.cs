using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class Separator : MonoBehaviour
    {
        Separation mSeparation;
        Kinematic mKinematic;
        public Player[] targets;

        private void Awake()
        {
            mKinematic = new Kinematic();
            mKinematic.position = transform.position;
        }

        // Start is called before the first frame update
        void Start()
        {
            mSeparation = new Separation(mKinematic, 50f, 5f,20f);

            mSeparation.targets = new Kinematic[targets.Length];
            for(int i = 0; i < targets.Length; i++)
            {
                mSeparation.targets[i] = targets[i].GetKinematic();
            }

        }

        // Update is called once per frame
        void Update()
        {
            SteeringOutput steering = mSeparation.GetSteering();

            if (steering != null) mKinematic.Update(steering, 10f, Time.deltaTime);

            transform.position = new Vector3(mKinematic.position.x, 0.5f, mKinematic.position.z);
            transform.eulerAngles = new Vector3(0, mKinematic.orientation * Mathf.Rad2Deg, 0);
        }

        public Kinematic GetKinematic()
        {
            return mKinematic;
        }
    }
}