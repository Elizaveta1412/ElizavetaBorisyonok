using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Person
    {
        protected string name;
        protected string surname;
        protected string patronymic;
        protected int age;
        public Person (string name, string surname, string patronymic, int age)
        {
           if (age >=17 && age <=38)
           {
                this.age = age;
           }
           else
           {
                Console.WriteLine("People of this age cannot study at the university.");
                Console.ReadLine();
                Console.Clear();
                return;
           }
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Patronymic
        {
            get { return patronymic; }
            set { patronymic = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
    class Student : Person
    {
        protected int physics;
        protected int math;
        protected int rysk;

        public Student(string name, string surname, string patronymic, int age,
            int physics, int math, int rysk) : base(name, surname, patronymic, age)
        {

            if (physics >= 0 && physics <= 10)
            {
                this.physics = physics;
            }
            else
            {
                Console.WriteLine("This point must be in [0,10].");
                Console.ReadLine();
                Console.Clear();
                return;

            }
            if (math >= 0 && math <= 10)
            {
                this.math = math;
            }
            else
            {
                Console.WriteLine("This point must be in [0,10].");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            if (rysk >= 0 && rysk <= 10)
            {
                this.rysk = rysk;
            }
            else
            {
                Console.WriteLine("This point must be in [0,10].");
                Console.ReadLine();
                Console.Clear();
                return;
            }
        }
        public int Physics
        {
            get { return physics; }
            set { physics = value; }
        }
        public int Math
        {
            get { return math; }
            set { math = value; }
        }
        public int Rysk
        {
            get { return rysk; }
            set { rysk = value; }
        }
      
        public int[] student = new int[1];
    
        public int this[int index]
        {
            get { return student[index]; }
            set { student[index] = value; }
        }

        public void StudInf()
        {
            Console.WriteLine($"F.I.O - {name} {surname} {patronymic} \nAge - {age}.");
        }

        public void AreyouEnter (float srbal)
        {
            Console.WriteLine("Enter your results of CT:");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());

            if (a < 0 || b < 0 || c < 0)
            {
                Console.WriteLine("Incorrect enter");
                Console.Clear();
                return;
            }
            else if (a>100||b>100||c>100)
            {
                Console.WriteLine("Each score can be only <=100");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            
            float itog = a + b + c + srbal * 10;
            Console.WriteLine($"My score - {itog}");

            Console.WriteLine("Are you applying for free or paid?\n 3 - paid \n 4 - free");
            int z = Convert.ToInt32(Console.ReadLine());
            switch (z)
            {
                case 3:
                    if (itog < 150)
                    {
                        Console.WriteLine("You are not enter to any specialization");
                    }
                    else if (250 > itog && itog >= 150)
                    {
                        Console.WriteLine("Choose the specialization:\n 1 - VMSIS \n 2 - IVS");
                        int N = Convert.ToInt32(Console.ReadLine());
                        switch (N)
                        {
                            case 1: Console.WriteLine("You are enter to VMSIS"); break;
                            case 2: Console.WriteLine("You are enter to IVS"); break;
                            default: Console.WriteLine("Incorrect enter"); break;
                        }
                    }
                    else if (400 >= itog && itog >= 250)
                    {
                        Console.WriteLine("Choose the specialization:\n 1 - IITP \n 2 - POIT \n 3 - VMSIS \n 4 - IVS");
                        int N = Convert.ToInt32(Console.ReadLine());
                        switch (N)
                        {
                            case 1: Console.WriteLine("You are enter to IITP"); break;
                            case 2: Console.WriteLine("You are enter to POIT"); break;
                            case 3: Console.WriteLine("You are enter to VMSIS"); break;
                            case 4: Console.WriteLine("You are enter to IVS"); break;
                            default: Console.WriteLine("Incorrect enter"); break;
                        }
                    }
                    break;
                case 4:
                    if (itog < 250)
                    {
                        Console.WriteLine("You are not enter to any specialization");
                    }
                    if (itog >= 250 && itog < 300)
                    {
                        Console.WriteLine("Choose the specialization:\n 1 - VMSIS \n 2 - IVS ");
                        int N = Convert.ToInt32(Console.ReadLine());
                        switch (N)
                        {
                            case 1: Console.WriteLine("You are enter to VMSIS"); break;
                            case 2: Console.WriteLine("You are enter to IVS"); break;
                            default: Console.WriteLine("Incorrect enter"); break;
                        }
                    }
                    if (itog >= 300 && itog <= 400)
                    {
                        Console.WriteLine("Choose the specialization:\n 1 - VMSIS \n 2 - IVS \n 3 - IITP \n 4 - POIT");
                        int N = Convert.ToInt32(Console.ReadLine());
                        switch (N)
                        {
                            case 1: Console.WriteLine("You are enter to VMSIS"); break;
                            case 2: Console.WriteLine("You are enter to IVS"); break;
                            case 3: Console.WriteLine("You are enter to IITP"); break;
                            case 4: Console.WriteLine("You are enter to POIT"); break;
                            default: Console.WriteLine("Incorrect enter"); break;
                        }
                    }
                    break;
                default: Console.WriteLine("Incorrect enter"); break;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student student;
            int age = 0, math = 0, physics = 0, rysk = 0;
            string name = "Name", surname = "Surname", patronymic = "Patronymic";


            try
            {
                Console.WriteLine("Enter surname");
                surname = Console.ReadLine();
                Console.WriteLine("Enter name");
                name = Console.ReadLine();
                Console.WriteLine("Enter patronymic");
                patronymic = Console.ReadLine();
                Console.WriteLine("Enter age");
                age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter physics grade");
                physics = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter math grade");
                math = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter rysk grade");
                rysk = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Incorrect enter");
                return;
            }
            float srbal = (physics + math + rysk) / 3;

            student = new Student(name, surname, patronymic, age, physics, math, rysk);
            student[0] = 5;

            int i = 0;
            for (; ; )
            {
                Console.WriteLine("\n1 - Information\n2 - Are you enter?\n3 - Exit (if you get one of the errors, click this button)");
                int operat = Convert.ToInt32(Console.ReadLine());

                switch (operat)
                {
                    case 1: student.StudInf(); break;
                    case 2: student.AreyouEnter(srbal); break;
                    default: Console.Clear(); break;
                }
                i++;
                if (i == 3)
                    break;
            }
        }
    }
}
