namespace RobotWars.GeneticStuff
{
    public interface IMutator
    {
        IIndividual Mutate(IIndividual individual);
    }
}
