using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class Aligner : MonoBehaviour
    {
        [SerializeField] Player target;

        Align mAlign;
        Kinematic mKinematic;

        private void Awake()
        {
            mKinematic = new Kinematic();
            mKinematic.position = transform.position;
        }

        // Start is called before the first frame update
        void Start()
        {
            mAlign = new Align(mKinematic, target.GetKinematic(), 1f, 3f);
        }

        // Update is called once per frame
        void Update()
        {
            SteeringOutput steering = mAlign.GetSteering();

            if (steering != null) mKinematic.Update(mAlign.GetSteering(), 10f, Time.deltaTime);

            transform.position = new Vector3(mKinematic.position.x, 0.5f, mKinematic.position.z);
            transform.eulerAngles = new Vector3(0, mKinematic.orientation * Mathf.Rad2Deg, 0);
        }
    }
}