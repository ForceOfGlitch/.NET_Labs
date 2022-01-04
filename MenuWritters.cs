using System;
using System.Collections.Generic;

namespace Lab1
{
    class SimplestMenuElementWritter
    {
        List<SimplestMenuElement> list = new List<SimplestMenuElement>();
        public SimplestMenuElementWritter(Menu<SimplestMenuElement> menu)
        {
            list = menu.GetElementsList();
        }

        public void Print()
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{list[i].GetId() - 1} {list[i].GetName()}");
            }
        }
    }

    class AdvancedMenuElementWritter
    {
        List<AdvancedMenuElement> list = new List<AdvancedMenuElement>();
        public AdvancedMenuElementWritter(Menu<AdvancedMenuElement> menu)
        {
            list = menu.GetElementsList();
        }
        public void Print()
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{list[i].GetId() - 1} {list[i].GetName()} {list[i].GetAlternativeName()}");
            }
        }
    }
}
