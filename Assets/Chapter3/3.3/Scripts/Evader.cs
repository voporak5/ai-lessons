using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class Evader : MonoBehaviour
    {
        [SerializeField] Player target;

        Evade mEvade;
        Kinematic mKinematic;

        private void Awake()
        {
            mKinematic = new Kinematic();
            mKinematic.position = transform.position;
        }

        // Start is called before the first frame update
        void Start()
        {
            mEvade = new Evade(mKinematic, 1f,10f);
            mEvade.target = target.GetKinematic();
        }

        // Update is called once per frame
        void Update()
        {
            mKinematic.Update(mEvade.GetSteering(), 1f, Time.deltaTime);

            transform.position = new Vector3(mKinematic.position.x, 0.5f, mKinematic.position.z);
            transform.eulerAngles = new Vector3(0, mKinematic.orientation * Mathf.Rad2Deg, 0);
        }
    }
}