namespace Genetics
{
    class GeneticLiniarArray<T> : IGA<T>
    {
        public IChromosome<T>[] CreateChildren(IChromosome<T>[] parents)
        {
            IChromosome<T> child1 = new ChromosomeLiniarArray<T>();
            IChromosome<T> child2 = new ChromosomeLiniarArray<T>();
            child1.Data = new GenericArray<T>(parents[0].Data.Size());
            child2.Data = new GenericArray<T>(parents[0].Data.Size());

            System.Random rand = new System.Random();
            int crossoverPoint = rand.Next(0, parents[0].Data.Size() - 1);

            for(int i = 0; i < parents[0].Data.Size(); ++i)
            {
                if (i < crossoverPoint)
                {
                    child1.Data.Set(parents[0].Data.Get(i), i);
                    child2.Data.Set(parents[1].Data.Get(i), i);
                }
                else
                {
                    child1.Data.Set(parents[1].Data.Get(i), i);
                    child2.Data.Set(parents[0].Data.Get(i), i);
                }
            }

            return new IChromosome<T>[] { child1, child2 };
        }

        public IChromosome<T> Mutate(IChromosome<T> chromosome)
        {
            System.Random rand = new System.Random();
            int swapPoint1 = rand.Next(0, chromosome.Data.Size() - 1);
            int swapPoint2 = rand.Next(0, chromosome.Data.Size() - 1);
            double chance = rand.NextDouble();

            while (chance < .5)
            {
                T temp = chromosome.Data.Get(swapPoint1);
                chromosome.Data.Set(chromosome.Data.Get(swapPoint2), swapPoint1);
                chromosome.Data.Set(temp, swapPoint2);
                chance = rand.NextDouble();
            }

            return chromosome;
        }

        public IChromosome<T>[] SelectParents(GenericArray<IChromosome<T>> population)
        {
            double accumulatedFitness = 0.0;
            double totalFitenss = 0.0;
            IChromosome<T>[] parents = new ChromosomeLiniarArray<T>[2];
            System.Random rand = new System.Random();

            for(int i = 0; i < population.Size(); ++i)
            {
                totalFitenss += population.Get(i).Fitness;
            }

            for(int i = 0; i < population.Size(); ++i)
            {
                accumulatedFitness += population.Get(i).Fitness / totalFitenss;
                population.Get(i).AccumulatedFitnes = accumulatedFitness;
            }

            double chance, score;

            for(int i = 0; i < 2; ++i)
            {
                chance = rand.NextDouble();

                for(int j = 0; j < population.Size(); ++j)
                {
                    score = population.Get(i).AccumulatedFitnes;
                    if(parents[0] != null)
                    {
                        if (!population.Get(j).Equals(parents[0]))
                        {
                            if(score > chance)
                            {
                                parents[i] = population.Get(j);
                                break;
                            }
                        }
                    }
                    else if(score > chance)
                    {
                        parents[i] = population.Get(j);
                        break;
                    }
                    if(j >= population.Size() - 1)
                    {
                        parents[i] = population.Get(population.Size() - 1);
                        break;
                    }
                }
            }

            if(parents[1] == null)
            {
                System.Console.WriteLine("SELECTION FUCKED");
            }

            return parents;
        }

        public GenericArray<IChromosome<T>> SortPopulationByFitness(GenericArray<IChromosome<T>> population)
        {
            GenericArray<IChromosome<T>> sortedPopulation = new GenericArray<IChromosome<T>>(population.Size());

            double max;
            int index;

            for(int i = 0; i < population.Size(); ++i)
            {
                max = double.MinValue;
                index = -1;

                for(int j = 0; j < population.Size(); ++j)
                {
                    if (population.Get(j) != null)
                    {
                        if(max < population.Get(j).Fitness)
                        {
                            max = population.Get(j).Fitness;
                            index = j;
                        }
                    }
                }

                sortedPopulation.Set(population.Get(index), i);
                population.Set(null, index);
            }

            return sortedPopulation;
        }
    }

   
}
