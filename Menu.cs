using System.Collections.Generic;

namespace Lab1
{
    public interface ICovarTest<out T>
    {
        T GetFirstObject();
    }

    public interface IContravarTest<in T>
    {
        void SetLastObject(T obj);
    }

    class SimplestMenuElement
    {
        static int menuVariantsCount = 1;
        protected string name;
        private int id;

        public SimplestMenuElement(string newFirstName)
        {
            name = newFirstName;
            id = menuVariantsCount;
            menuVariantsCount++;
        }
        public virtual int GetId()
        {
            return id;
        }

        public string GetName()
        {
            return name;
        }

    }

    class AdvancedMenuElement : SimplestMenuElement
    {
        static int AdvancedMenuElementCount = 1;
        private string alternativeName;
        private int id;

        public AdvancedMenuElement(string newFirstName, string newSecondName) : base(newFirstName)
        {
            name = newFirstName;
            alternativeName = newSecondName;
            id = AdvancedMenuElementCount;
            AdvancedMenuElementCount++;
        }
        public override int GetId()
        {
            return id;
        }

        public string GetAlternativeName()
        {
            return alternativeName;
        }
    }

    class Menu<T> : ICovarTest<T>, IContravarTest<T>
    {
        private List<T> menuElements = new List<T>();

        public T GetFirstObject()
        {
            if (menuElements.Count > 0)
            {
                return menuElements[0];
            }
            else
            {
                return default;
            }
        }
        public void SetLastObject(T newElement)
        {
            menuElements.Add(newElement);
        }
        public List<T> GetElementsList()
        {
            return menuElements;
        }
    }
}
