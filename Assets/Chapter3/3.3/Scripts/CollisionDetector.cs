using AI.Foundation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class CollisionDetector
    {
        float whiskersAngle = Mathf.PI / 6;

        public Collision GetCollision(Vector3 position, Vector3 moveAmount)
        {
            RaycastHit hit;
            Vector3 direction = moveAmount - position;
            float orientation = Mathf.Atan2(direction.x, direction.z);

            if (Physics.Raycast(position, moveAmount,out hit))
            {
                Collision collision = new Collision();
                collision.position = hit.point;
                collision.normal = hit.normal;
                return collision;
            }

            Utils.OrientationAsVector(orientation + whiskersAngle);
            if (Physics.Raycast(position, moveAmount, out hit))
            {
                Collision collision = new Collision();
                collision.position = hit.point;
                collision.normal = hit.normal;
                return collision;
            }

            Utils.OrientationAsVector(orientation - whiskersAngle);
            if (Physics.Raycast(position, moveAmount, out hit))
            {
                Collision collision = new Collision();
                collision.position = hit.point;
                collision.normal = hit.normal;
                return collision;
            }

            return null;
        }
    }
}