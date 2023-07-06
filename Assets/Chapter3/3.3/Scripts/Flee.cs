namespace AI.Demos.Three.Three
{
    public class Flee
    {
        public Kinematic target;
        Kinematic character;
        
        float maxAcceleration;

        public Flee(Kinematic character, float maxAcceleration)
        {
            this.character = character;
            this.maxAcceleration = maxAcceleration;
        }

        public virtual SteeringOutput GetSteering()
        {
            SteeringOutput result = new SteeringOutput();

            result.linear = character.position - target.position;

            result.linear.Normalize();
            result.linear *= maxAcceleration;

            result.angular = 0;
            return result;
        }
    }
}