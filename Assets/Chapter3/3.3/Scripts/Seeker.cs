using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class Seeker : MonoBehaviour
    {
        [SerializeField] Player target;

        Seek mSeek;
        Kinematic mKinematic;

        private void Awake()
        {
            mKinematic = new Kinematic();
            mKinematic.position = transform.position;
        }

        // Start is called before the first frame update
        void Start()
        {
            mSeek = new Seek(mKinematic, 1f);
            mSeek.target = target.GetKinematic();
        }

        // Update is called once per frame
        void Update()
        {
            mKinematic.Update(mSeek.GetSteering(), 10f, Time.deltaTime);

            transform.position = new Vector3(mKinematic.position.x, 0.5f, mKinematic.position.z);
            transform.eulerAngles = new Vector3(0, mKinematic.orientation * Mathf.Rad2Deg, 0);

            
        }
    }
}