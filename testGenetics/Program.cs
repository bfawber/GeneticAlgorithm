using Genetics;

namespace testGenetics
{
    class Program
    {
        
        static void Main(string[] args)
        {
            GeneticLiniarArray<int> ga = new GeneticLiniarArray<int>();
            GenericArray<IChromosome<int>> population = createRandomPopulation(100);
            System.Random rand = new System.Random();

            for(int i = 0; i < population.Size(); ++i)
            {
                population.Get(i).Fitness = Score(population.Get(i));
            }

            population = ga.SortPopulationByFitness(population);

            while (population.Get(0).Fitness < 45)
            {
                System.Console.WriteLine("new Generation!");
                System.Console.WriteLine("Top Fitness = " + population.Get(0).Fitness);
                population = ga.SortPopulationByFitness(population);

                IChromosome<int>[] parents = ga.SelectParents(population);

                for (int i = population.Size() / 2; i < population.Size(); i+=2)
                {
                    IChromosome<int>[] children = ga.CreateChildren(parents);
                    double chance = rand.NextDouble();
                    if(chance < .15)
                    {
                        children[0] = ga.Mutate(children[0]);
                    }
                    chance = rand.NextDouble();
                    if (chance < .1)
                    {
                        children[1] = ga.Mutate(children[1]);
                    }
                    population.Set(children[0], i);
                    population.Set(children[1], i+1);
                    population.Get(i).Fitness = Score(population.Get(i));
                    population.Get(i+1).Fitness = Score(population.Get(i+1));
                }

                population = ga.SortPopulationByFitness(population);
            }
        }

        public static double Score(IChromosome<int> chromosome)
        {
            double score = 0;

            for(int i = 0; i < chromosome.Data.Size(); ++i)
            {
                if(chromosome.Data.Get(i) == i)
                {
                    score += 1.5;
                }
            }

            return score;
        }

        public static GenericArray<IChromosome<int>> createRandomPopulation(int size)
        {
            GenericArray<IChromosome<int>> population = new GenericArray<IChromosome<int>>(size);

            System.Random rand = new System.Random();
            int dataSize = rand.Next(50, 100);
            IChromosome<int> chromosome = new ChromosomeLiniarArray<int>();
            chromosome.Data = new GenericArray<int>(dataSize);

            for(int i = 0; i < population.Size(); ++i)
            {
                for(int j = 0; j < dataSize; ++j)
                {
                    chromosome.Data.Set(rand.Next(dataSize), j);
                }

                population.Set(chromosome, i);
            }

            return population;
        }
    }
}
