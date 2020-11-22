using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asynchron
{
    class Program
    {
        static string locker = "";
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(new ThreadStart(Work1));
            Thread thread2 = new Thread(new ThreadStart(Work2));
            thread1.Start();
            thread2.Start();
            SaveWorkAsync();
            while (true) {
                Console.WriteLine("Write your name:");
                string name = Console.ReadLine();
                Console.WriteLine("Write your surname");
                string surname = Console.ReadLine();
                Console.WriteLine("Write your age");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Write your profession");
                string profession = Console.ReadLine();
                Person person = new Person(name, surname, age, profession);
                Passport passport = new Passport(person);
                SaveFileAsync(passport);
                Console.WriteLine("Do you want to end work?");
                var end = Console.ReadLine();
                if (end == "y" || end == "Y")
                {
                    break;
                }
            }
        }
        static async Task SaveFileAsync(Passport passport)
        {
            Console.WriteLine("Begin Save File");
            await Task.Run(() => SaveFile(passport));
            Console.WriteLine("End Save File");
        }
        static async Task SaveWorkAsync()
        {
            Console.WriteLine("Begin Save Work File");
            await Task.Run(() => SaveWork());
            Console.WriteLine("End Save Work File");
        }
        static void SaveFile(Passport passport)
        {
            Console.WriteLine("Begin Save data passport");
            using (var sw = new StreamWriter("file.txt",true,Encoding.UTF8))
            {
                sw.WriteLine($"Passport {passport.Name}, {passport.Surname}, {passport.Age} years, {passport.Profession}");
            }
            Console.WriteLine("End Save data passport");
        }
        static void SaveWork()
        {
            var rnd = new Random();
            var text = "";
            for (int i = 0; i < 100000; i++)
            {
                text += rnd.Next();
            }
            Console.WriteLine("Begin Save data work");
            using (var sw = new StreamWriter("work.txt", false, Encoding.UTF8))
            {

                sw.Write(text);

            }
            Console.WriteLine("End Save data work");
        }
        static void Work1()
        {
            Random rnd = new Random();
            Console.WriteLine("Begin Work1");
            for (int i = 0; i < 100000; i++)
            {
                lock (locker)
                {
                    locker += rnd.Next();
                }
            }
     
            Console.WriteLine("End Work1");
        }
        static void Work2()
        {
            Random rnd = new Random();
            Console.WriteLine("Begin Work2");
            for (int i = 0; i < 100000; i++)
            {
                lock (locker)
                {
                    locker += rnd.Next();
                }

            }

            Console.WriteLine("End Work2");
        }
    }
}
