using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Demos.Three.Two
{
    public class Wanderer : MonoBehaviour
    {
        private KinematicWander mKinematicWander;


        // Start is called before the first frame update
        void Awake()
        {
            mKinematicWander = new KinematicWander();
            mKinematicWander.position = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            mKinematicWander.Update(transform.forward, Time.deltaTime);

            transform.position = new Vector3(mKinematicWander.position.x, 0.5f, mKinematicWander.position.z);
            transform.eulerAngles = new Vector3(0, mKinematicWander.orientation * Mathf.Rad2Deg, 0);
        }
    }
}