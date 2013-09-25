namespace RobotWars.GeneticStuff
{
    internal interface IMutator
    {
        IIndividual Mutate(IIndividual individual);
    }
}
