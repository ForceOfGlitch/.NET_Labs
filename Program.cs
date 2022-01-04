using System;
using System.IO;
using System.Collections.Generic;

namespace Lab1
{
    class Program
    {
        static uint VerifyUInt(string infoMessage, string exMessage) // Проверка входного значения на соответствие беззнакового типа
        {
            Logger logger = new Logger();
            uint total = 0;
            try
            {
                total = Convert.ToUInt32(Console.ReadLine());
                logger.Info(infoMessage);
            }
            catch (Exception e)
            {
                logger.Error(exMessage);
                throw e;
            }
            return total;
        }

        static void Main(string[] args)
        {
            Logger logger = new Logger();
            bool start = true;

            List<string> configText = new List<string>();
            try
            {
                StreamReader reader = new StreamReader("Config.txt");

                while (!reader.EndOfStream)
                {
                    configText.Add(reader.ReadLine());
                }
                reader.Close();
                Console.WriteLine(configText[0]);
            }
            catch (InvalidConfigFileException ex)
            {
                logger.Error(ex.GetExMessage());
                start = false;
            }

            MyList<Vehicle> totalList = new MyList<Vehicle>();
            try
            {
                StreamReader reader = new StreamReader("Vehicles.txt");
                
                string line;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    string[] vehicleInfo = line.Split(' ');
                    if (vehicleInfo[3] == "0")
                    {
                        Wheeled one = new Wheeled(vehicleInfo[0], Convert.ToBoolean(vehicleInfo[1]), Convert.ToByte(vehicleInfo[2]), Convert.ToByte(vehicleInfo[3]), Convert.ToInt32(vehicleInfo[4]));
                        totalList.Add(one);
                    }
                    if (vehicleInfo[3] == "1")
                    {
                        Tracked one = new Tracked(vehicleInfo[0], Convert.ToBoolean(vehicleInfo[1]), Convert.ToByte(vehicleInfo[2]), Convert.ToByte(vehicleInfo[3]), Convert.ToInt32(vehicleInfo[4]));
                        totalList.Add(one);
                    }
                    if (vehicleInfo[3] == "2")
                    {
                        Helicopter one = new Helicopter(vehicleInfo[0], Convert.ToBoolean(vehicleInfo[1]), Convert.ToByte(vehicleInfo[2]), Convert.ToByte(vehicleInfo[3]), Convert.ToInt32(vehicleInfo[4]));
                        totalList.Add(one);
                    }
                    if (vehicleInfo[3] == "3")
                    {
                        Plane one = new Plane(vehicleInfo[0], Convert.ToBoolean(vehicleInfo[1]), Convert.ToByte(vehicleInfo[2]), Convert.ToByte(vehicleInfo[3]), Convert.ToInt32(vehicleInfo[4]));
                        totalList.Add(one);
                    }
                }
                reader.Close();
                Console.WriteLine(configText[0]);
            }
            catch(Exception)
            {
                Console.WriteLine(configText[1]);
                start = false;
            }

            Menu<SimplestMenuElement> menu = new Menu<SimplestMenuElement>();

            string[] MenuElements = new string[6] { "Провести учения", "Провести техосмотр", "Отправить технику на ремонт", "Отправить свободную технику на фронт", "Отсортировать технику по длине имени", "Посмотреть весь перечень техники" };

            for (int i = 0; i < 6; i++)
            {
                SimplestMenuElement test = new SimplestMenuElement(MenuElements[i]);
                menu.SetLastObject(test);
            }

            SimplestMenuElementWritter writter = new SimplestMenuElementWritter(menu);

            while (start)
            {
                Console.WriteLine("Введите номер команды:");
                writter.Print();
                uint typeOfCommand;
                try
                {
                    typeOfCommand = VerifyUInt(configText[2], configText[3]);
                }
                catch(Exception)
                {
                    typeOfCommand = 1000;
                    Console.WriteLine("Введено некорректное значение!");
                }
                if(typeOfCommand == 0)
                {
                    Console.WriteLine("Введите необходимое количество наземного лёгкого вооружённого транспорта");
                    uint groundLightArmedCount = VerifyUInt(configText[2], configText[3]);
                    Console.WriteLine("Введите необходимое количество наземного бронированного вооружённого транспорта");
                    uint groundHeavyArmedCount = VerifyUInt(configText[2], configText[3]);
                    Console.WriteLine("Введите необходимое количество самолётов-бомбардировщиков");
                    uint airBombingCount = VerifyUInt(configText[2], configText[3]);
                    Console.WriteLine("Введите необходимое количество вертолётов огневой поддержки");
                    uint airSupportCount = VerifyUInt(configText[2], configText[3]);
                    Console.WriteLine("Введите необходимое количество наземного лёгкого невооружённого транспорта");
                    uint groundLightNoArmedCount = VerifyUInt(configText[2], configText[3]);
                    Console.WriteLine("Введите необходимое количество наземного бронированного невооружённого транспорта");
                    uint groundHeavyNoArmedCount = VerifyUInt(configText[2], configText[3]);
                    Console.WriteLine("Введите необходимое количество транспортных вертолётов без вооружения");
                    uint airTransportCount = VerifyUInt(configText[2], configText[3]);

                    TrainingTask training = new TrainingTask(totalList, groundLightArmedCount, groundHeavyArmedCount, airBombingCount, airSupportCount, groundLightNoArmedCount, groundHeavyNoArmedCount, airTransportCount);

                    uint vehicleCount = groundLightArmedCount + groundHeavyArmedCount + airBombingCount + airSupportCount + groundLightNoArmedCount + groundHeavyNoArmedCount + airTransportCount;
                    
                    logger.Info(configText[4]);

                    if (training.iterCount < vehicleCount)
                    {
                        logger.Warning(configText[5]);
                        Console.WriteLine($"Нет столько машин, добавлено только {training.iterCount} единиц");
                    }

                    Console.WriteLine("Перечень добавленной к учениям техники:");
                    MyList<Vehicle> result = training.TryGetVehicleList();
                    foreach (Vehicle iter in result)
                    {
                        string armed = "", status = "", type = "";
                        if (iter != null)
                        {
                            switch (iter.TryGetArmed())
                            {
                                case true:
                                    {
                                        armed = "Присутствует_вооружение";
                                        break;
                                    }
                                case false:
                                    {
                                        armed = "Отсутствует_вооружение";
                                        break;
                                    }
                            }
                            switch (iter.TryGetStatus())
                            {
                                case 0:
                                    {
                                        status = "Уничтожена";
                                        break;
                                    }
                                case 1:
                                    {
                                        status = "Сломана";
                                        break;
                                    }
                                case 2:
                                    {
                                        status = "На ремонте";
                                        break;
                                    }
                                case 3:
                                    {
                                        status = "На техосмотре";
                                        break;
                                    }
                                case 4:
                                    {
                                        status = "Свободна";
                                        break;
                                    }
                                case 5:
                                    {
                                        status = "На учениях";
                                        break;
                                    }
                                case 6:
                                    {
                                        status = "В бою";
                                        break;
                                    }
                            }
                            switch (iter.TryGetType())
                            {
                                case 0:
                                    {
                                        type = "Колёсная";
                                        break;
                                    }
                                case 1:
                                    {
                                        type = "Гусеничная";
                                        break;
                                    }
                                case 2:
                                    {
                                        type = "Вертолёт";
                                        break;
                                    }
                                case 3:
                                    {
                                        type = "Самолёт";
                                        break;
                                    }
                            }
                            Console.WriteLine($"{iter.TryGetName()} {armed} {status} {type}");
                        }
                    }

                    continue;
                }
                if (typeOfCommand == 1)
                {
                    Console.WriteLine("Введите количество единиц техники, отправляемых на техосмотр");
                    uint vehicleCount = VerifyUInt(configText[2], configText[3]);
                    TechObservTask techObserv = new TechObservTask(vehicleCount, totalList);
                    logger.Info(configText[4]);
                    if (techObserv.iterCount < vehicleCount)
                    {
                        logger.Warning(configText[5]);
                        Console.WriteLine($"Нет столько  машин, добавлено только {techObserv.iterCount} единиц");
                    }
                    Console.WriteLine("Перечень отправленной на техосмотр техники:");
                    MyList<Vehicle> result = techObserv.TryGetVehicleList();
                    foreach (Vehicle iter in result)
                    {
                        if (iter == null) break;
                        string armed = "", status = "", type = "";
                        switch (iter.TryGetArmed())
                        {
                            case true:
                                {
                                    armed = "Присутствует_вооружение";
                                    break;
                                }
                            case false:
                                {
                                    armed = "Отсутствует_вооружение";
                                    break;
                                }
                        }
                        switch (iter.TryGetStatus())
                        {
                            case 0:
                                {
                                    status = "Уничтожена";
                                    break;
                                }
                            case 1:
                                {
                                    status = "Сломана";
                                    break;
                                }
                            case 2:
                                {
                                    status = "На ремонте";
                                    break;
                                }
                            case 3:
                                {
                                    status = "На техосмотре";
                                    break;
                                }
                            case 4:
                                {
                                    status = "Свободна";
                                    break;
                                }
                            case 5:
                                {
                                    status = "На учениях";
                                    break;
                                }
                            case 6:
                                {
                                    status = "В бою";
                                    break;
                                }
                        }
                        switch (iter.TryGetType())
                        {
                            case 0:
                                {
                                    type = "Колёсная";
                                    break;
                                }
                            case 1:
                                {
                                    type = "Гусеничная";
                                    break;
                                }
                            case 2:
                                {
                                    type = "Вертолёт";
                                    break;
                                }
                            case 3:
                                {
                                    type = "Самолёт";
                                    break;
                                }
                        }
                        Console.WriteLine($"{iter.TryGetName()} {armed} {status} {type}");
                    }
                    continue;
                }
                if (typeOfCommand == 2)
                {
                    Console.WriteLine("Введите количество единиц техники, отправляемых на ремонт из числа сломанных");
                    uint vehicleCount = VerifyUInt(configText[2], configText[3]);
                    RepairTask repairing = new RepairTask(totalList, vehicleCount);
                    logger.Info(configText[4]);
                    if (repairing.iterCount < vehicleCount)
                    {
                        logger.Warning(configText[5]);
                        Console.WriteLine($"Нет столько сломанных машин, добавлено только {repairing.iterCount} единиц");
                    }
                    Console.WriteLine("Перечень добавленной к ремонтным работам техники:");
                    MyList<Vehicle> result = repairing.TryGetVehicleList();
                    foreach (Vehicle iter in result)
                    {
                        if (iter == null) break;
                        string armed = "", status = "", type = "";
                        switch (iter.TryGetArmed())
                        {
                            case true:
                                {
                                    armed = "Присутствует_вооружение";
                                    break;
                                }
                            case false:
                                {
                                    armed = "Отсутствует_вооружение";
                                    break;
                                }
                        }
                        switch (iter.TryGetStatus())
                        {
                            case 0:
                                {
                                    status = "Уничтожена";
                                    break;
                                }
                            case 1:
                                {
                                    status = "Сломана";
                                    break;
                                }
                            case 2:
                                {
                                    status = "На ремонте";
                                    break;
                                }
                            case 3:
                                {
                                    status = "На техосмотре";
                                    break;
                                }
                            case 4:
                                {
                                    status = "Свободна";
                                    break;
                                }
                            case 5:
                                {
                                    status = "На учениях";
                                    break;
                                }
                            case 6:
                                {
                                    status = "В бою";
                                    break;
                                }
                        }
                        switch (iter.TryGetType())
                        {
                            case 0:
                                {
                                    type = "Колёсная";
                                    break;
                                }
                            case 1:
                                {
                                    type = "Гусеничная";
                                    break;
                                }
                            case 2:
                                {
                                    type = "Вертолёт";
                                    break;
                                }
                            case 3:
                                {
                                    type = "Самолёт";
                                    break;
                                }
                        }
                        Console.WriteLine($"{iter.TryGetName()} {armed} {status} {type}");
                    }
                    continue;
                }
                if (typeOfCommand == 3)
                {
                    Console.WriteLine("Введите необходимое количество наземного лёгкого вооружённого транспорта");
                    uint groundLightArmedCount = VerifyUInt(configText[2], configText[3]);
                    Console.WriteLine("Введите необходимое количество наземного бронированного вооружённого транспорта");
                    uint groundHeavyArmedCount = VerifyUInt(configText[2], configText[3]);
                    Console.WriteLine("Введите необходимое количество самолётов-бомбардировщиков");
                    uint airBombingCount = VerifyUInt(configText[2], configText[3]);
                    Console.WriteLine("Введите необходимое количество вертолётов огневой поддержки");
                    uint airSupportCount = VerifyUInt(configText[2], configText[3]);
                    Console.WriteLine("Введите необходимое количество наземного лёгкого невооружённого транспорта");
                    uint groundLightNoArmedCount = VerifyUInt(configText[2], configText[3]);
                    Console.WriteLine("Введите необходимое количество наземного бронированного невооружённого транспорта");
                    uint groundHeavyNoArmedCount = VerifyUInt(configText[2], configText[3]);
                    Console.WriteLine("Введите необходимое количество транспортных вертолётов без вооружения");
                    uint airTransportCount = VerifyUInt(configText[2], configText[3]);

                    uint vehicleCount = groundLightArmedCount + groundHeavyArmedCount + airBombingCount + airSupportCount + groundLightNoArmedCount + groundHeavyNoArmedCount + airTransportCount;

                    BattleTask battle = new BattleTask(totalList, groundLightArmedCount, groundHeavyArmedCount, airBombingCount, airSupportCount, groundLightNoArmedCount, groundHeavyNoArmedCount, airTransportCount);
                    logger.Info(configText[4]);

                    if (battle.iterCount < vehicleCount)
                    {
                        logger.Warning(configText[5]);
                        Console.WriteLine($"Нет столько сломанных машин, добавлено только {battle.iterCount} единиц");
                    }
                    Console.WriteLine("Перечень отправленной на фронт техники:");
                    MyList<Vehicle> result = battle.TryGetVehicleList();
                    foreach (Vehicle iter in result)
                    {
                        if (iter == null) break;
                        string armed = "", status = "", type = "";
                        switch (iter.TryGetArmed())
                        {
                            case true:
                                {
                                    armed = "Присутствует_вооружение";
                                    break;
                                }
                            case false:
                                {
                                    armed = "Отсутствует_вооружение";
                                    break;
                                }
                        }
                        switch (iter.TryGetStatus())
                        {
                            case 0:
                                {
                                    status = "Уничтожена";
                                    break;
                                }
                            case 1:
                                {
                                    status = "Сломана";
                                    break;
                                }
                            case 2:
                                {
                                    status = "На ремонте";
                                    break;
                                }
                            case 3:
                                {
                                    status = "На техосмотре";
                                    break;
                                }
                            case 4:
                                {
                                    status = "Свободна";
                                    break;
                                }
                            case 5:
                                {
                                    status = "На учениях";
                                    break;
                                }
                            case 6:
                                {
                                    status = "В бою";
                                    break;
                                }
                        }
                        switch (iter.TryGetType())
                        {
                            case 0:
                                {
                                    type = "Колёсная";
                                    break;
                                }
                            case 1:
                                {
                                    type = "Гусеничная";
                                    break;
                                }
                            case 2:
                                {
                                    type = "Вертолёт";
                                    break;
                                }
                            case 3:
                                {
                                    type = "Самолёт";
                                    break;
                                }
                        }
                        Console.WriteLine($"{iter.TryGetName()} {armed} {status} {type}");
                    }

                    continue;
                }
                if (typeOfCommand == 4)
                {
                    totalList.SortByName();
                }
                if (typeOfCommand == 5)
                {
                    Console.WriteLine("Перечень техники в базе:");
                    foreach (Vehicle iter in totalList)
                    {
                        if (iter == null) break;
                        string armed = "", status = "", type = "";
                        switch (iter.TryGetArmed())
                        {
                            case true:
                                {
                                    armed = "Присутствует_вооружение";
                                    break;
                                }
                            case false:
                                {
                                    armed = "Отсутствует_вооружение";
                                    break;
                                }
                        }
                        switch (iter.TryGetStatus())
                        {
                            case 0:
                                {
                                    status = "Уничтожена";
                                    break;
                                }
                            case 1:
                                {
                                    status = "Сломана";
                                    break;
                                }
                            case 2:
                                {
                                    status = "На ремонте";
                                    break;
                                }
                            case 3:
                                {
                                    status = "На техосмотре";
                                    break;
                                }
                            case 4:
                                {
                                    status = "Свободна";
                                    break;
                                }
                            case 5:
                                {
                                    status = "На учениях";
                                    break;
                                }
                            case 6:
                                {
                                    status = "В бою";
                                    break;
                                }
                        }
                        switch (iter.TryGetType())
                        {
                            case 0:
                                {
                                    type = "Колёсная";
                                    break;
                                }
                            case 1:
                                {
                                    type = "Гусеничная";
                                    break;
                                }
                            case 2:
                                {
                                    type = "Вертолёт";
                                    break;
                                }
                            case 3:
                                {
                                    type = "Самолёт";
                                    break;
                                }
                        }
                        Console.WriteLine($"{iter.TryGetName()} {armed} {status} {type}");
                    }
                    logger.Info(configText[4]);
                    continue;
                }
            }
        }

        ICovarTest<SimplestMenuElement> a = new Menu<AdvancedMenuElement>(); // Пример ковариант

        IContravarTest<AdvancedMenuElement> b = new Menu<SimplestMenuElement>(); //Пример контравариант
    }
}
