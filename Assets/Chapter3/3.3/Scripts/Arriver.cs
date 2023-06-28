using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class Arriver : MonoBehaviour
    {
        [SerializeField] Player target;

        Arrive mArrive;
        Kinematic mKinematic;

        private void Awake()
        {
            mKinematic = new Kinematic();
            mKinematic.position = transform.position;
        }

        // Start is called before the first frame update
        void Start()
        {
            mArrive = new Arrive(mKinematic, target.GetKinematic(), 1f,3f);
        }

        // Update is called once per frame
        void Update()
        {
            SteeringOutput steering = mArrive.GetSteering();
            
            if(steering != null) mKinematic.Update(mArrive.GetSteering(), 10f, Time.deltaTime);

            transform.position = new Vector3(mKinematic.position.x, 0.5f, mKinematic.position.z);
            transform.eulerAngles = new Vector3(0, mKinematic.orientation * Mathf.Rad2Deg, 0);
        }
    }
}