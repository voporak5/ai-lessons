using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Foundation;

namespace AI.Demos.Three.Three
{
    public class Path
    {
        private Vector3[] nodes;

        public Path(Vector3[] nodes)
        {
            this.nodes = nodes;
        }

        //TODO: implement coherence with lastParam
        //      to make sure next point is relatively near previous point
        public int GetParam(Vector3 position, int lastParam)
        {
            int param = -1;
            float distance = 0;

            //Can probably limit this to 1 or 2 executions based on lastParam
            //and direction moving along the path
            for(int i = 0, j = 1; i < nodes.Length - 1; i++,j++)
            {
                float tDistance = Utils.DistNearestPointSegment(position, nodes[i], nodes[j]);

                if(param == -1)
                {
                    param = i;
                    distance = tDistance;
                }
                else if(tDistance < distance)
                {
                    distance = tDistance;
                    param = i;
                }
            }

            return param;
        }

        public Vector3 GetPosition(int param)
        {
            param = Mathf.Clamp(param, 0, nodes.Length - 1);
            return nodes[param];
        }
    }
}