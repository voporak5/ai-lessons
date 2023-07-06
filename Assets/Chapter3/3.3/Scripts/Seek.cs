namespace AI.Demos.Three.Three
{
    public class Seek
    {
        public Kinematic target;
        private Kinematic character;
        
        float maxAcceleration;

        public Seek(Kinematic character, float maxAcceleration)
        {
            this.character = character;
            this.maxAcceleration = maxAcceleration;
        }

        public virtual SteeringOutput GetSteering()
        {
            SteeringOutput result = new SteeringOutput();

            result.linear = target.position - character.position;

            result.linear.Normalize();
            result.linear *= maxAcceleration;

            result.angular = 0;
            return result;
        }
    }
}