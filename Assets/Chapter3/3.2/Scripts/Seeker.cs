using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Demos.Three.Two
{
    public class Seeker : MonoBehaviour
    {
        private KinematicSeek mKinematicSeek;

        [SerializeField] Transform mTarget;

        // Start is called before the first frame update
        void Awake()
        {
            mKinematicSeek = new KinematicSeek();
            mKinematicSeek.position = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            mKinematicSeek.target = mTarget.position;
            mKinematicSeek.Update(Time.deltaTime);

            transform.position = new Vector3(mKinematicSeek.position.x, 0.5f, mKinematicSeek.position.z);
            transform.eulerAngles = new Vector3(0, mKinematicSeek.orientation * Mathf.Rad2Deg, 0);
        }
    }
}