using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class Pursuer : MonoBehaviour
    {
        [SerializeField] Player target;

        Pursue mPursue;
        Kinematic mKinematic;

        private void Awake()
        {
            mKinematic = new Kinematic();
            mKinematic.position = transform.position;
        }

        // Start is called before the first frame update
        void Start()
        {
            mPursue = new Pursue(mKinematic,1f, 2f);
            mPursue.target = target.GetKinematic();
        }

        // Update is called once per frame
        void Update()
        {
            mKinematic.Update(mPursue.GetSteering(), 10f, Time.deltaTime);

            transform.position = new Vector3(mKinematic.position.x, 0.5f, mKinematic.position.z);
            transform.eulerAngles = new Vector3(0, mKinematic.orientation * Mathf.Rad2Deg, 0);


        }
    }
}