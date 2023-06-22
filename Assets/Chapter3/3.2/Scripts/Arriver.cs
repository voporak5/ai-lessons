using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Demos.Three.Two
{
    public class Arriver : MonoBehaviour
    {
        private KinematicArrive mKinematicArrive;

        [SerializeField] Transform mTarget;

        // Start is called before the first frame update
        void Awake()
        {
            mKinematicArrive = new KinematicArrive();
            mKinematicArrive.position = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            mKinematicArrive.target = mTarget.position;
            mKinematicArrive.Update(Time.deltaTime);

            transform.position = new Vector3(mKinematicArrive.position.x, 0.5f, mKinematicArrive.position.z);
            transform.eulerAngles = new Vector3(0, mKinematicArrive.orientation * Mathf.Rad2Deg, 0);
        }
    }
}