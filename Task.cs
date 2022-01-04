using System;
using System.Collections.Generic;
namespace Lab1
{
    abstract class Task
    {
        protected abstract void ChoosingVehicles(byte status);
        protected MyList<Vehicle> vehicleList;
        protected Task(ref MyList<Vehicle> newVehicleList)
        {
            vehicleList = newVehicleList;
        }
    }
    class TrainingTask : Task
    {
        Wheeled[] groundLightArmed;
        Tracked[] groundHeavyArmed;
        Plane[] airBombing;
        Helicopter[] airSupport;
        Wheeled[] groundLightNoArmed;
        Tracked[] groundHeavyNoArmed;
        Helicopter[] airTransport;

        MyList<Vehicle> finalTaskList = new MyList<Vehicle>();
        public uint iterCount = 0;

        public MyList<Vehicle> TryGetVehicleList()
        {
            return finalTaskList;
        }

        //public bool FullOrNot() // Все ли массивы заполнены техникой? Если заполнить невозможно, то возвращается false
        //{
        //    bool check = true;
        //    if (groundLightArmed.Length > 0)
        //    {
        //        foreach (Wheeled i in groundLightArmed)
        //        {
        //            if (i == null) { check = false; }
        //        }
        //    }
        //    if (groundLightNoArmed.Length > 0)
        //    {
        //        foreach (Wheeled i in groundLightArmed)
        //        {
        //            if (i == null) { check = false; }
        //        }
        //    }
        //    if (groundHeavyArmed.Length > 0)
        //    {
        //        foreach (Tracked i in groundHeavyArmed)
        //        {
        //            if (i == null) { check = false; }
        //        }
        //    }
        //    if (groundHeavyNoArmed.Length > 0)
        //    {
        //        foreach (Tracked i in groundHeavyNoArmed)
        //        {
        //            if (i == null) { check = false; }
        //        }
        //    }
        //    if (airBombing.Length > 0)
        //    {
        //        foreach (Plane i in airBombing)
        //        {
        //            if (i == null) { check = false; }
        //        }
        //    }
        //    if (airSupport.Length > 0)
        //    {
        //        foreach (Helicopter i in airSupport)
        //        {
        //            if (i == null) { check = false; }
        //        }
        //    }
        //    if (airTransport.Length > 0)
        //    {
        //        foreach (Helicopter i in airTransport)
        //        {
        //            if (i == null) { check = false; }
        //        }
        //    }
        //    return check;
        //}

        override protected void ChoosingVehicles(byte status) // Метод выбора нужной техники из списка
        {
            foreach(Vehicle iter in vehicleList)
            {
                if(status == iter.TryGetStatus())
                {
                    if (Convert.ToString(iter.TryGetType()) == "0")
                    {
                        if (iter.TryGetArmed())
                        {
                            int iter1 = 0;
                            bool check = true;
                            if (groundLightArmed.Length > 0)
                            {
                                while (groundLightArmed[iter1] != null)
                                {
                                    iter1++;
                                    if (iter1 >= groundLightArmed.Length) // Если мы заполнили необходимый список, то нам больше не нужно элементов, влаг на недобавление
                                    {
                                        check = false;
                                        break;
                                    }
                                }
                                if (check)
                                {
                                    Wheeled a = new Wheeled(iter.TryGetName(), iter.TryGetArmed(), iter.TryGetStatus(), iter.TryGetType(), iter.TryGetId());
                                    groundLightArmed[iter1] = a;
                                    finalTaskList.Add(a);
                                    iter.TrySetStatus(5);
                                    iterCount++;
                                }
                            }
                        }
                        else
                        {
                            int iter1 = 0;
                            bool check = true;
                            if (groundLightNoArmed.Length > 0)
                            {
                                while (groundLightNoArmed[iter1] != null)
                                {
                                    iter1++;
                                    if (iter1 >= groundLightNoArmed.Length)
                                    {
                                        check = false;
                                        break;
                                    }
                                }
                                if (check)
                                {
                                    Wheeled a = new Wheeled(iter.TryGetName(), iter.TryGetArmed(), iter.TryGetStatus(), iter.TryGetType(), iter.TryGetId());
                                    groundLightNoArmed[iter1] = a;
                                    finalTaskList.Add(a);
                                    iter.TrySetStatus(5);
                                    iterCount++;
                                }
                            }
                        }
                    }
                    if (Convert.ToString(iter.TryGetType()) == "1")
                    {
                        if (iter.TryGetArmed())
                        {
                            int iter1 = 0;
                            bool check = true;
                            if (groundHeavyArmed.Length > 0)
                            {
                                while (groundHeavyArmed[iter1] != null)
                                {
                                    iter1++;
                                    if (iter1 >= groundHeavyArmed.Length)
                                    {
                                        check = false;
                                        break;
                                    }
                                }
                                if (check)
                                {
                                    Tracked a = new Tracked(iter.TryGetName(), iter.TryGetArmed(), iter.TryGetStatus(), iter.TryGetType(), iter.TryGetId());
                                    groundHeavyArmed[iter1] = a;
                                    finalTaskList.Add(a);
                                    iter.TrySetStatus(5);
                                    iterCount++;
                                }
                            }
                        }
                        else
                        {
                            int iter1 = 0;
                            bool check = true;
                            if (groundHeavyNoArmed.Length > 0)
                            {
                                while (groundHeavyNoArmed[iter1] != null)
                                {
                                    iter1++;
                                    if (iter1 >= groundHeavyNoArmed.Length)
                                    {
                                        check = false;
                                        break;
                                    }
                                }
                                if (check)
                                {
                                    Tracked a = new Tracked(iter.TryGetName(), iter.TryGetArmed(), iter.TryGetStatus(), iter.TryGetType(), iter.TryGetId());
                                    groundHeavyNoArmed[iter1] = a;
                                    finalTaskList.Add(a);
                                    iter.TrySetStatus(5);
                                    iterCount++;
                                }
                            }
                        }
                    }
                    if (Convert.ToString(iter.TryGetType()) == "2")
                    {
                        if (iter.TryGetArmed())
                        {
                            int iter1 = 0;
                            bool check = true;
                            if (airSupport.Length > 0)
                            {
                                while (airSupport[iter1] != null)
                                {
                                    iter1++;
                                    if (iter1 >= airSupport.Length)
                                    {
                                        check = false;
                                        break;
                                    }
                                }
                                if (check)
                                {
                                    Helicopter a = new Helicopter(iter.TryGetName(), iter.TryGetArmed(), iter.TryGetStatus(), iter.TryGetType(), iter.TryGetId());
                                    airSupport[iter1] = a;
                                    finalTaskList.Add(a);
                                    iter.TrySetStatus(5);
                                    iterCount++;
                                }
                            }
                        }
                        else
                        {
                            int iter1 = 0;
                            bool check = true;
                            if (airTransport.Length > 0)
                            {
                                while (airTransport[iter1] != null)
                                {
                                    iter1++;
                                    if (iter1 >= airTransport.Length)
                                    {
                                        check = false;
                                        break;
                                    }
                                }
                                if (check)
                                {
                                    Helicopter a = new Helicopter(iter.TryGetName(), iter.TryGetArmed(), iter.TryGetStatus(), iter.TryGetType(), iter.TryGetId());
                                    airTransport[iter1] = a;
                                    finalTaskList.Add(a);
                                    iter.TrySetStatus(5);
                                    iterCount++;
                                }
                            }
                        }
                    }
                    if (Convert.ToString(iter.TryGetType()) == "3")
                    {
                        int iter1 = 0;
                        bool check = true;
                        if (airBombing.Length > 0)
                        {
                            while (airBombing[iter1] != null)
                            {
                                iter1++;
                                if (iter1 >= airBombing.Length)
                                {
                                    check = false;
                                    break;
                                }
                            }
                            if (check)
                            {
                                Plane a = new Plane(iter.TryGetName(), iter.TryGetArmed(), iter.TryGetStatus(), iter.TryGetType(), iter.TryGetId());
                                airBombing[iter1] = a;
                                finalTaskList.Add(a);
                                iter.TrySetStatus(5);
                                iterCount++;
                            }
                        }
                    }
                }
            }
        }

        public TrainingTask(MyList<Vehicle> newVehicleList, uint groundLightArmedCount, uint groundHeavyArmedCount, uint airBombingCount, 
            uint airSupportCount, uint groundLightNoArmedCount, uint groundHeavyNoArmedCount, uint airTransportCount) : base(ref newVehicleList)
        {
            groundLightArmed = new Wheeled[groundLightArmedCount];
            groundHeavyArmed = new Tracked[groundHeavyArmedCount];
            airBombing = new Plane[airBombingCount];
            airSupport = new Helicopter[airSupportCount];
            groundLightNoArmed = new Wheeled[groundLightNoArmedCount];
            groundHeavyNoArmed = new Tracked[groundHeavyNoArmedCount];
            airTransport = new Helicopter[airTransportCount];

            ChoosingVehicles(4);
        }

    }
    class RepairTask : Task
    {
        MyList<Vehicle> finalTaskList = new MyList<Vehicle>();
        uint count = 0;
        public uint iterCount = 0;

        public MyList<Vehicle> TryGetVehicleList()
        {
            return finalTaskList;
        }

        override protected void ChoosingVehicles(byte status)
        {
            foreach (Vehicle iter in vehicleList)
            {
                if (status == iter.TryGetStatus())
                {
                    switch(iter.TryGetType())
                    {
                        case 0:
                            {
                                Wheeled a = new Wheeled(iter.TryGetName(), iter.TryGetArmed(), iter.TryGetStatus(), iter.TryGetType(), iter.TryGetId());
                                finalTaskList.Add(a);
                                break;
                            }
                        case 1:
                            {
                                Tracked a = new Tracked(iter.TryGetName(), iter.TryGetArmed(), iter.TryGetStatus(), iter.TryGetType(), iter.TryGetId());
                                finalTaskList.Add(a);
                                break;
                            }
                        case 2:
                            {
                                Helicopter a = new Helicopter(iter.TryGetName(), iter.TryGetArmed(), iter.TryGetStatus(), iter.TryGetType(), iter.TryGetId());
                                finalTaskList.Add(a);
                                break;
                            }
                        case 3:
                            {
                                Plane a = new Plane(iter.TryGetName(), iter.TryGetArmed(), iter.TryGetStatus(), iter.TryGetType(), iter.TryGetId());
                                finalTaskList.Add(a);
                                break;
                            }
                    }
                    iter.TrySetStatus(2);
                    iterCount++;
                }
            }
        }

        public RepairTask(MyList<Vehicle> newVehicleList, uint entireCount) : base(ref newVehicleList)
        {
            count = entireCount;
            ChoosingVehicles(1);
        }

    }
    class TechObservTask : Task
    {
        MyList<Vehicle> finalTaskList = new MyList<Vehicle>();
        uint count = 0;
        public uint iterCount = 0;

        public MyList<Vehicle> TryGetVehicleList()
        {
            return finalTaskList;
        }

        override protected void ChoosingVehicles(byte status)
        {
            foreach (Vehicle iter in vehicleList)
            {
                if ((status == iter.TryGetStatus()) && (iterCount < count))
                {
                    iterCount++;
                    switch (iter.TryGetType())
                    {
                        case 0:
                            {
                                Wheeled a = new Wheeled(iter.TryGetName(), iter.TryGetArmed(), iter.TryGetStatus(), iter.TryGetType(), iter.TryGetId());
                                finalTaskList.Add(a);
                                break;
                            }
                        case 1:
                            {
                                Tracked a = new Tracked(iter.TryGetName(), iter.TryGetArmed(), iter.TryGetStatus(), iter.TryGetType(), iter.TryGetId());
                                finalTaskList.Add(a);
                                break;
                            }
                        case 2:
                            {
                                Helicopter a = new Helicopter(iter.TryGetName(), iter.TryGetArmed(), iter.TryGetStatus(), iter.TryGetType(), iter.TryGetId());
                                finalTaskList.Add(a);
                                break;
                            }
                        case 3:
                            {
                                Plane a = new Plane(iter.TryGetName(), iter.TryGetArmed(), iter.TryGetStatus(), iter.TryGetType(), iter.TryGetId());
                                finalTaskList.Add(a);
                                break;
                            }
                    }
                    iter.TrySetStatus(3);
                }
            }
        }

        public TechObservTask(uint entireCount, MyList<Vehicle> newVehicleList) : base(ref newVehicleList)
        {
            count = entireCount;
            ChoosingVehicles(4);
        }
    }
    class BattleTask : Task
    {
        Wheeled[] groundLightArmed;
        Tracked[] groundHeavyArmed;
        Plane[] airBombing;
        Helicopter[] airSupport;
        Wheeled[] groundLightNoArmed;
        Tracked[] groundHeavyNoArmed;
        Helicopter[] airTransport;

        MyList<Vehicle> finalTaskList = new MyList<Vehicle>();
        public uint iterCount = 0;

        public MyList<Vehicle> TryGetVehicleList()
        {
            return finalTaskList;
        }

        override protected void ChoosingVehicles(byte status) // Метод выбора нужной техники из списка
        {
            foreach (Vehicle iter in vehicleList)
            {
                if (status == iter.TryGetStatus())
                {
                    if (Convert.ToString(iter.TryGetType()) == "0")
                    {
                        if (iter.TryGetArmed())
                        {
                            int iter1 = 0;
                            bool check = true;
                            if (groundLightArmed.Length > 0)
                            {
                                while (groundLightArmed[iter1] != null)
                                {
                                    iter1++;
                                    if (iter1 >= groundLightArmed.Length) // Если мы заполнили необходимый список, то нам больше не нужно элементов, влаг на недобавление
                                    {
                                        check = false;
                                        break;
                                    }
                                }
                                if (check)
                                {
                                    Wheeled a = new Wheeled(iter.TryGetName(), iter.TryGetArmed(), iter.TryGetStatus(), iter.TryGetType(), iter.TryGetId());
                                    groundLightArmed[iter1] = a;
                                    finalTaskList.Add(a);
                                    iter.TrySetStatus(6);
                                    iterCount++;
                                }
                            }
                        }
                        else
                        {
                            int iter1 = 0;
                            bool check = true;
                            if (groundLightNoArmed.Length > 0)
                            {
                                while (groundLightNoArmed[iter1] != null)
                                {
                                    iter1++;
                                    if (iter1 >= groundLightNoArmed.Length)
                                    {
                                        check = false;
                                        break;
                                    }
                                }
                                if (check)
                                {
                                    Wheeled a = new Wheeled(iter.TryGetName(), iter.TryGetArmed(), iter.TryGetStatus(), iter.TryGetType(), iter.TryGetId());
                                    groundLightNoArmed[iter1] = a;
                                    finalTaskList.Add(a);
                                    iter.TrySetStatus(6);
                                    iterCount++;
                                }
                            }
                        }
                    }
                    if (Convert.ToString(iter.TryGetType()) == "1")
                    {
                        if (iter.TryGetArmed())
                        {
                            int iter1 = 0;
                            bool check = true;
                            if (groundHeavyArmed.Length > 0)
                            {
                                while (groundHeavyArmed[iter1] != null)
                                {
                                    iter1++;
                                    if (iter1 >= groundHeavyArmed.Length)
                                    {
                                        check = false;
                                        break;
                                    }
                                }
                                if (check)
                                {
                                    Tracked a = new Tracked(iter.TryGetName(), iter.TryGetArmed(), iter.TryGetStatus(), iter.TryGetType(), iter.TryGetId());
                                    groundHeavyArmed[iter1] = a;
                                    finalTaskList.Add(a);
                                    iter.TrySetStatus(6);
                                    iterCount++;
                                }
                            }
                        }
                        else
                        {
                            int iter1 = 0;
                            bool check = true;
                            if (groundHeavyNoArmed.Length > 0)
                            {
                                while (groundHeavyNoArmed[iter1] != null)
                                {
                                    iter1++;
                                    if (iter1 >= groundHeavyNoArmed.Length)
                                    {
                                        check = false;
                                        break;
                                    }
                                }
                                if (check)
                                {
                                    Tracked a = new Tracked(iter.TryGetName(), iter.TryGetArmed(), iter.TryGetStatus(), iter.TryGetType(), iter.TryGetId());
                                    groundHeavyNoArmed[iter1] = a;
                                    finalTaskList.Add(a);
                                    iter.TrySetStatus(6);
                                    iterCount++;
                                }
                            }
                        }
                    }
                    if (Convert.ToString(iter.TryGetType()) == "2")
                    {
                        if (iter.TryGetArmed())
                        {
                            int iter1 = 0;
                            bool check = true;
                            if (airSupport.Length > 0)
                            {
                                while (airSupport[iter1] != null)
                                {
                                    iter1++;
                                    if (iter1 >= airSupport.Length)
                                    {
                                        check = false;
                                        break;
                                    }
                                }
                                if (check)
                                {
                                    Helicopter a = new Helicopter(iter.TryGetName(), iter.TryGetArmed(), iter.TryGetStatus(), iter.TryGetType(), iter.TryGetId());
                                    airSupport[iter1] = a;
                                    finalTaskList.Add(a);
                                    iter.TrySetStatus(6);
                                    iterCount++;
                                }
                            }
                        }
                        else
                        {
                            int iter1 = 0;
                            bool check = true;
                            if (airTransport.Length > 0)
                            {
                                while (airTransport[iter1] != null)
                                {
                                    iter1++;
                                    if (iter1 >= airTransport.Length)
                                    {
                                        check = false;
                                        break;
                                    }
                                }
                                if (check)
                                {
                                    Helicopter a = new Helicopter(iter.TryGetName(), iter.TryGetArmed(), iter.TryGetStatus(), iter.TryGetType(), iter.TryGetId());
                                    airTransport[iter1] = a;
                                    finalTaskList.Add(a);
                                    iter.TrySetStatus(6);
                                    iterCount++;
                                }
                            }
                        }
                    }
                    if (Convert.ToString(iter.TryGetType()) == "3")
                    {
                        int iter1 = 0;
                        bool check = true;
                        if (airBombing.Length > 0)
                        {
                            while (airBombing[iter1] != null)
                            {
                                iter1++;
                                if (iter1 >= airBombing.Length)
                                {
                                    check = false;
                                    break;
                                }
                            }
                            if (check)
                            {
                                Plane a = new Plane(iter.TryGetName(), iter.TryGetArmed(), iter.TryGetStatus(), iter.TryGetType(), iter.TryGetId());
                                airBombing[iter1] = a;
                                finalTaskList.Add(a);
                                iter.TrySetStatus(6);
                                iterCount++;
                            }
                        }
                    }
                }
            }
        }

        public BattleTask(MyList<Vehicle> newVehicleList, uint groundLightArmedCount, uint groundHeavyArmedCount, uint airBombingCount,
            uint airSupportCount, uint groundLightNoArmedCount, uint groundHeavyNoArmedCount, uint airTransportCount) : base(ref newVehicleList)
        {
            groundLightArmed = new Wheeled[groundLightArmedCount];
            groundHeavyArmed = new Tracked[groundHeavyArmedCount];
            airBombing = new Plane[airBombingCount];
            airSupport = new Helicopter[airSupportCount];
            groundLightNoArmed = new Wheeled[groundLightNoArmedCount];
            groundHeavyNoArmed = new Tracked[groundHeavyNoArmedCount];
            airTransport = new Helicopter[airTransportCount];

            ChoosingVehicles(4);
        }
    }
}
