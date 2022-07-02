using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Globalization;

namespace zadanie_7._8
{
    internal class Program
    {       
        static void Main(string[] args)
        {

            Console.WriteLine("Здравсвуй, дорогой друг");
            Console.WriteLine("Если хочешь посмотреть записи напиши 1, для добавления 2, для просмотра по ID 3");
            Console.WriteLine("Если хочешь удалить запись напиши 4, для редактирования 5");
            Console.WriteLine("Если хочешь сортирвоать по диапозону ВРЕМЕНИ напиши 6,а для сортирвки по убыванию или возарстанию 7");
            Console.WriteLine("Если закончил работу нажми 8 и сохрани изменения");
            bool V = true;

            //////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            
            string path = @"input.txt";

            Repository1 repo1 = new Repository1(path);
            repo1.Load("1");
            

            //Console.WriteLine(repo1[1][0]);

            ////////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            do
            {
                string t = Console.ReadLine();

                switch (t)
                {
                    case "1":
                        repo1.PrintDbToConsole();
                        break;
                    case "2":
                        //add();
                        
                        
                        string sotrudnik0 = Convert.ToString( repo1.Len()+1);
                        Console.WriteLine("Введите время добваления записи");
                        string sotrudnik1 = Console.ReadLine();
                        Console.WriteLine("Введите Ф. И. О.");
                        string sotrudnik2 = Console.ReadLine();
                        Console.WriteLine("Введите возраст");
                        string sotrudnik3 = Console.ReadLine();
                        Console.WriteLine("Введите рост");
                        string sotrudnik4 = Console.ReadLine();
                        Console.WriteLine("Введите дату рождения");
                        string sotrudnik5 = Console.ReadLine();
                        Console.WriteLine("Введите место рождения");
                        string sotrudnik6 = Console.ReadLine();
                        
                        repo1.Add(new Sotrudniki(sotrudnik0, sotrudnik1, sotrudnik2, Convert.ToInt32(sotrudnik3), Convert.ToInt32(sotrudnik4), sotrudnik5, sotrudnik6));
                        string TEXT = sotrudnik0 + "#" + sotrudnik1 + "#" + sotrudnik2 + "#" + sotrudnik3 + "#" + sotrudnik4 + "#" + sotrudnik5 + "#" + sotrudnik6;
                        File.AppendAllText(@"input.txt", TEXT);
                        break;
                    case"3":
                        Console.WriteLine("Введите ID сотрудника");
                        string ID = Console.ReadLine();
                        repo1.PrintDbIDToConsole(ID);
                        break;
                    case"4":
                        
                        Console.WriteLine("Введите ID сотрудника для удаления!");
                        
                        repo1.Load("2");                        
                        //repo1.Load("1");//Внесение изменений
                        break;
                    case "5":

                        repo1.Load("3");
                        //repo1.Load("1");//Внесение изменений
                        break;

                    case"6":
                        repo1.PrintDbToConsoleMonth();
                        break;

                    case"7":
                        repo1.PrintDbToConsoleMonthSort();
                        break;

                    case "8":
                        repo1.Load("1");
                        V = false;
                        break;
                }

            } while (V);

        }
    }
}
