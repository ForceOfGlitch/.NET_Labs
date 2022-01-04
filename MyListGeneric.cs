using System;
using System.Collections;

namespace Lab1
{
    class MyList<T> : IEnumerable, IEnumerator where T : Vehicle
    {
        int enumPosition = -1; // номер элемента, использующийся при переборе
        int addPosition = -1; // номер добавляемого элемента

        int count = 0; // кол-во элементов массива
        
        T[] arr = new T[1]; // обобщенный массив

        delegate void MyAction(ref T a, ref T b);

        public int Count
        {
            get { return count; }
        }

        public void Clear() // метод очистки массива и обнуления всех счетчиков
        {
            arr = new T[1];
            count = 0;
            addPosition = -1;
        }

        public void SortByName()
        {
            string text;

            Logger logger = new Logger();

            DelegatesFunctions<T> obj = new DelegatesFunctions<T>(); // экземпляр класса, предоставляющего методы сравнения и замены значений эл-в

            Func<T, T, bool> compare = obj.Compare; // делегат, содержащий ф-цию сравнения

            MyAction swap = obj.Swap; // делегат, содержащий ф-цию замены значений элементов

            try
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (compare(arr[i], arr[j]))
                        {
                            swap(ref arr[i], ref arr[j]);
                        }
                    }
                }
                text = "Сортировка выполнена успешно";
                logger.Info(text);
            }
            catch (IndexOutOfRangeException ex)
            {
                text = "Непредвиденная ошибка при сортировке: ";
                string exInfo = text + $"{ex.Message}";
                logger.Error(exInfo);
            }

        }

        public void Add(T mass) // метод добавления в массив элемента
        {
            count++;  // увеличиваем размер массива
            Array.Resize(ref arr, count);
            addPosition++;
            this.arr[addPosition] = mass; // добавляем значение
        }

        public bool MoveNext() // перемещает ссылку на следующий элемент списка
        {
            enumPosition++;
            return (enumPosition < arr.Length);
        }

        public void Reset() // cброс счетчика перебора элементов
        {
            enumPosition = -1;
        }
        public T Current // получение текущего элемента
        {
            get
            { 
                try 
                { 
                    return arr[enumPosition]; 
                } 
                catch (IndexOutOfRangeException) 
                { 
                    throw new InvalidOperationException(); 
                }
            } 
        }

        object IEnumerator.Current // метод должен возвращать текущий элемент списка
        {
            get { return Current; }
        }

        public IEnumerator GetEnumerator()// обязательный метод интерфейса IEnumerable
        {
            return arr.GetEnumerator();
        }

        public T this[int index]  // Индексатор для корректной работы с индексами
        {
            get { return arr[index]; }
            set { arr[index] = value; }
        }
    }
}
