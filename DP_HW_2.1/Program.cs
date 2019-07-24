using System;
//Singleton
//•	Написать программный код по приведенному примеру в изображении


namespace DP_HW_2._1
{
    //Singleton
    class OS
    {
        private static OS instance;

        public string Name { get; private set; }

        protected OS(string name)
        {
            this.Name = name;
        }

        public static OS GetInstance(string name)
        {
            if (instance == null)
                instance = new OS(name);
            return instance;
        }
    }
    class Computer
    {
        public OS OS { get; set; }
        public void Launch(string osName)
        {
            OS = OS.GetInstance(osName);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OS os1 = OS.GetInstance("Windows 10");
            OS os2 = OS.GetInstance("Windows 8");
            if(os1 == os2)
            {
                Console.WriteLine("Singleton работает");
            }
            else
            {
                Console.WriteLine("Singleton не работает");
            }

            Computer comp = new Computer();
            comp.Launch("Windows 8");
            Console.WriteLine(comp.OS.Name);

            // у нас не получится изменить ОС, так как объект уже создан    
            comp.OS = OS.GetInstance("Windows 10");
            Console.WriteLine(comp.OS.Name);

            Console.ReadLine();
        }
    }
}
