using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Demos.Three.Three
{
    public class FollowPath : Seek
    {
        public Path path;

        public int pathOffset = 2;

        public int currentParam;

        public FollowPath(Kinematic character, float maxAcceleration)
             : base(character, maxAcceleration)
        {

        }

        public override SteeringOutput GetSteering()
        {
            currentParam = path.GetParam(character.position, currentParam);

            int targetParam = currentParam + pathOffset;
            
            target = new Kinematic();
            target.position = path.GetPosition(targetParam);

            return base.GetSteering();
        }
    }
}