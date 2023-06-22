using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Demos.Three.Two
{
    public class Fleer : MonoBehaviour
    {
        private KinematicFlee mKinematicFlee;

        [SerializeField] Transform mTarget;

        // Start is called before the first frame update
        void Awake()
        {
            mKinematicFlee = new KinematicFlee();
            mKinematicFlee.position = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            mKinematicFlee.target = mTarget.position;
            mKinematicFlee.Update(Time.deltaTime);

            transform.position = new Vector3(mKinematicFlee.position.x, 0.5f, mKinematicFlee.position.z);
            transform.eulerAngles = new Vector3(0, mKinematicFlee.orientation * Mathf.Rad2Deg, 0);
        }
    }
}