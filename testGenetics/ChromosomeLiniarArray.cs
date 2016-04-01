namespace Genetics
{
    class ChromosomeLiniarArray<T> : IChromosome<T>
    {
        private double _accumulatedFitness;

        public double AccumulatedFitnes
        {
            get
            {
                return this._accumulatedFitness;
            }

            set
            {
                    this._accumulatedFitness = value;
            }
        }

        private GenericArray<T> _data;

        public GenericArray<T> Data
        {
            get
            {
                return this._data;
            }

            set
            {
                this._data = value;
            }
        }
        
        private double _fitness;

        public double Fitness
        {
            get
            {
                return this._fitness;
            }

            set
            {
                    this._fitness = value;
            }
        }
    }
}
