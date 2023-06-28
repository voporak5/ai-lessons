namespace AI.Demos.Three.Three
{
    public class Seek
    {
        Kinematic character;
        Kinematic target;

        float maxAcceleration;

        public Seek(Kinematic character, Kinematic target, float maxAcceleration)
        {
            this.character = character;
            this.target = target;
            this.maxAcceleration = maxAcceleration;
        }

        public SteeringOutput GetSteering()
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