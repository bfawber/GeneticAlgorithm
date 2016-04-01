namespace Genetics
{
    interface IChromosome<T>
    {
        double Fitness
        {
            get; set;
        }

        double AccumulatedFitnes
        {
            get; set;
        }

        GenericArray<T> Data
        {
            get; set;
        }
    }
}
