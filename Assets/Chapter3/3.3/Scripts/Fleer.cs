using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class Fleer : MonoBehaviour
    {
        [SerializeField] Player target;

        Flee mFlee;
        Kinematic mKinematic;

        private void Awake()
        {
            mKinematic = new Kinematic();
            mKinematic.position = transform.position;
        }

        // Start is called before the first frame update
        void Start()
        {
            mFlee = new Flee(mKinematic, 1f);
            mFlee.target = target.GetKinematic();
        }

        // Update is called once per frame
        void Update()
        {
            mKinematic.Update(mFlee.GetSteering(), 1f, Time.deltaTime);

            transform.position = new Vector3(mKinematic.position.x, 0.5f, mKinematic.position.z);
            transform.eulerAngles = new Vector3(0, mKinematic.orientation * Mathf.Rad2Deg, 0);


        }
    }
}