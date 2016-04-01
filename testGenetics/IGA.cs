namespace Genetics
{
    interface IGA<T>
    {
        IChromosome<T>[] SelectParents(GenericArray<IChromosome<T>> population);

        IChromosome<T>[] CreateChildren(IChromosome<T>[] parents);

        IChromosome<T> Mutate(IChromosome<T> chromosome);

        GenericArray<IChromosome<T>> SortPopulationByFitness(GenericArray<IChromosome<T>> population);
    }
}
