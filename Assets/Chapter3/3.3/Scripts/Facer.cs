using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class Facer : MonoBehaviour
    {
        [SerializeField] Player target;

        Face mFace;
        Kinematic mKinematic;

        private void Awake()
        {
            mKinematic = new Kinematic();
            mKinematic.position = transform.position;
        }

        // Start is called before the first frame update
        void Start()
        {
            mFace = new Face(mKinematic, 1f, 3f);
            mFace.target = target.GetKinematic();
        }

        // Update is called once per frame
        void Update()
        {
            SteeringOutput steering = mFace.GetSteering();

            if (steering != null) mKinematic.Update(mFace.GetSteering(), 10f, Time.deltaTime);

            transform.position = new Vector3(mKinematic.position.x, 0.5f, mKinematic.position.z);
            transform.eulerAngles = new Vector3(0, mKinematic.orientation * Mathf.Rad2Deg, 0);
        }
    }
}