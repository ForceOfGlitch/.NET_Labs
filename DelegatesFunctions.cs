namespace Lab1
{
    class DelegatesFunctions<T> where T: Vehicle
    {
        public void Swap(ref T a, ref T b)
        {
            T val = a;
            a = b;
            b = val;
        }
        public bool Compare(T a, T b)
        {
            if (b.TryGetName().Length > a.TryGetName().Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
