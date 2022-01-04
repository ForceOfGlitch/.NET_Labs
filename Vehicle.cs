using System;

namespace Lab1
{
    abstract class Vehicle
    {
        protected string name;
        protected bool armed;
        protected byte status; // 0 - уничтожена, 1 - сломана, 2 - на ремонте, 3 - на техосмотре, 4 - свободна, 5 - на учениях, 6 - в бою
        protected byte type; // 0 - колёсная, 1 - гусеничная, 2 - вертолёт, 3 - самолёт
        protected int id;

        public void TrySetStatus(byte a)
        {
            if (a < 7) status = a;
            else Console.WriteLine("Попытка задать некорректный статус транспорта");
        }
        public byte TryGetType()
        {
            return type;
        }
        public int TryGetId()
        {
            return id;
        }
        public bool TryGetArmed()
        {
            return armed;
        }
        public string TryGetName()
        {
            return name;
        }
        public byte TryGetStatus()
        {
            return status;
        }
    }
    class Helicopter : Vehicle
    {
        public Helicopter(string newName, bool newArmed, byte newStatus, byte newType, int newId)
        {
            name = newName;
            armed = newArmed;
            status = newStatus;
            type = newType;
            id = newId;
        }
    }
    class Plane : Vehicle
    {
        public Plane(string newName, bool newArmed, byte newStatus, byte newType, int newId)
        {
            name = newName;
            armed = newArmed;
            status = newStatus;
            type = newType;
            id = newId;
        }
    }
    class Wheeled : Vehicle
    {
        public Wheeled(string newName, bool newArmed, byte newStatus, byte newType, int newId)
        {
            name = newName;
            armed = newArmed;
            status = newStatus;
            type = newType;
            id = newId;
        }
    }
    class Tracked : Vehicle
    {
        public Tracked(string newName, bool newArmed, byte newStatus, byte newType, int newId)
        {
            name = newName;
            armed = newArmed;
            status = newStatus;
            type = newType;
            id = newId;
        }
    }
}
