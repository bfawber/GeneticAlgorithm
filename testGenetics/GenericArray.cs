namespace Genetics
{
    class GenericArray<T>
    {
        private T[] items;

        public GenericArray(int size = 100)
        {
            this.items = new T[size];
        }

        public void Set(T item, int i)
        {
            this.items[i] = item;
        }

        public T Get(int i)
        {
            return this.items[i];
        }

        public void Remove(int i)
        {
            for(int j = i; j < this.items.Length - 1; ++j)
            {
                this.items[j] = this.items[j + 1];
            }

            this.items[this.items.Length - 1] = default(T);
        }

        public bool IsMember(T item)
        {
            for(int i = 0; i < this.items.Length; ++i)
            {
                if (item.Equals(this.items[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public int Find(T item)
        {
            for(int i = 0; i < this.items.Length; ++i)
            {
                if (item.Equals(this.items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Clear()
        {
            for(int i = 0; i < this.items.Length; ++i)
            {
                this.items[i] = default(T);
            }
        }

        public int Size()
        {
            return this.items.Length;
        }
    }
}
