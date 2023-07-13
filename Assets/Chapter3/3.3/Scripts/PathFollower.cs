using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class PathFollower : MonoBehaviour
    {
        FollowPath mFollowPath;
        Kinematic mKinematic;

        private void Awake()
        {
            mKinematic = new Kinematic();
            mKinematic.position = transform.position;
        }

        // Start is called before the first frame update
        void Start()
        {
            mFollowPath = new FollowPath(mKinematic, 2f);
            Vector3[] test = { 
                new Vector3(-40, 0.5f, -10),
                new Vector3(-40, 0.5f, -5),
                new Vector3(-35, 0.5f, 0),
                new Vector3(-30, 0.5f, 0),
                new Vector3(-25, 0.5f, 0),
                new Vector3(-20, 0.5f, 5),
                new Vector3(-20, 0.5f, 10),
                new Vector3(-20, 0.5f, 15),
                new Vector3(-25, 0.5f, 20),
                new Vector3(-30, 0.5f, 20),
                new Vector3(-35, 0.5f, 20),
                new Vector3(-40, 0.5f, 25),
                new Vector3(-40, 0.5f, 30)
            };
            mFollowPath.path = new Path(test);
        }

        // Update is called once per frame
        void Update()
        {
            SteeringOutput steering = mFollowPath.GetSteering();

            if (steering != null) mKinematic.Update(steering, 2f, Time.deltaTime);

            transform.position = new Vector3(mKinematic.position.x, 0.5f, mKinematic.position.z);
            transform.eulerAngles = new Vector3(0, mKinematic.orientation * Mathf.Rad2Deg, 0);
        }
    }
}