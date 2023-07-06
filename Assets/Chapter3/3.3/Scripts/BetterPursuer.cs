using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class BetterPursuer : MonoBehaviour
    {
        [SerializeField] Player target;

        BetterPursue mBetterPursue;
        Kinematic mKinematic;

        private void Awake()
        {
            mKinematic = new Kinematic();
            mKinematic.position = transform.position;
        }

        // Start is called before the first frame update
        void Start()
        {
            mBetterPursue = new BetterPursue(mKinematic, 5f, 1f, 3f);
            mBetterPursue.target = target.GetKinematic();
        }

        // Update is called once per frame
        void Update()
        {
            SteeringOutput steering = mBetterPursue.GetSteering();

            if (steering != null) mKinematic.Update(mBetterPursue.GetSteering(), 10f, Time.deltaTime);

            transform.position = new Vector3(mKinematic.position.x, 0.5f, mKinematic.position.z);
            transform.eulerAngles = new Vector3(0, mKinematic.orientation * Mathf.Rad2Deg, 0);
        }
    }
}