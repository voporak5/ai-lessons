namespace AI.Demos.Three.Three
{
    public class Attraction : Separation
    {
        //Only difference between attraction and separation is the signage of maxAcceleration
        public Attraction(Kinematic character, float maxAcceleration, float threshold, float decayCoefficient)
            : base(character,-maxAcceleration,threshold,decayCoefficient) { }
    }
}