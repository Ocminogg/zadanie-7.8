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
        static void print()//Выводим текст документа
        {
            

            if (File.Exists(@"input.txt") == false)
            {
                Console.WriteLine("Пока пусто");
            }

            else
            {
                string text = File.ReadAllText(Path.GetFullPath(@"input.txt"));
                string[] lines = text.Split('#');
                int n = lines.Length / 7;

                Sotrudniki[] sotrudnik = new Sotrudniki[n];


                for (int i = 0; i < n; i++)
                {
                    sotrudnik[i] = new Sotrudniki()
                    {
                        ID = lines[0 + i * 7],
                        Date_add = lines[1 + i * 7],
                        FIO = lines[2 + i * 7],
                        Old = Convert.ToInt32(lines[3 + i * 7]),
                        Tall = Convert.ToInt32(lines[4 + i * 7]),
                        Date_of_Birth = lines[5 + i * 7],
                        Place_of_Birth = lines[6 + i * 7]
                    };
                    Sotrudniki.Print(sotrudnik[i].ID, sotrudnik[i].Date_add, sotrudnik[i].FIO, sotrudnik[i].Old, sotrudnik[i].Tall, sotrudnik[i].Date_of_Birth, sotrudnik[i].Place_of_Birth);

                }

            }


        }

        static void printID()//Выводим текст документа по ID
        {


            if (File.Exists(@"input.txt") == false)
            {
                Console.WriteLine("Пока пусто");
            }

            else
            {
                Console.WriteLine("Введите ID сотрудника");
                string search_id = Console.ReadLine();

                string text = File.ReadAllText(Path.GetFullPath(@"input.txt"));
                string[] lines = text.Split('#');
                int n = lines.Length / 7;

                Sotrudniki[] sotrudnik = new Sotrudniki[n];



                for (int i = 0; i < n; i++)
                {
                    sotrudnik[i] = new Sotrudniki()
                    {
                        ID = lines[0 + i * 7],
                        Date_add = lines[1 + i * 7],
                        FIO = lines[2 + i * 7],
                        Old = Convert.ToInt32(lines[3 + i * 7]),
                        Tall = Convert.ToInt32(lines[4 + i * 7]),
                        Date_of_Birth = lines[5 + i * 7],
                        Place_of_Birth = lines[6 + i * 7]
                    };
                    if (search_id == sotrudnik[i].ID)
                    {
                        Sotrudniki.Print(sotrudnik[i].ID, sotrudnik[i].Date_add, sotrudnik[i].FIO, sotrudnik[i].Old, sotrudnik[i].Tall, sotrudnik[i].Date_of_Birth, sotrudnik[i].Place_of_Birth);
                        break;
                    }
                }

            }


        }

        static void add()//Добавляем нового сотрудника
        {


            int F = 0;
            if (File.Exists(@"D:\Skilbox C#\zadanie 7.8\input.txt") == false)
            {
                File.WriteAllText(@"D:\Skilbox C#\zadanie 7.8\input.txt", "");
                F = 1;
            }


            string sotrudnik;


            string[] text = File.ReadAllLines(@"D:\Skilbox C#\zadanie 7.8\input.txt");

            Console.WriteLine("Введите ID");
            string sotrudnik0 = Console.ReadLine();
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

            if (F == 1)
            {
                sotrudnik = sotrudnik0 + "#" + sotrudnik1 + "#" + sotrudnik2 + "#" + sotrudnik3 + "#" + sotrudnik4 + "#" + sotrudnik5 + "#" + sotrudnik6;
            }
            else
            {
                sotrudnik = "#" + sotrudnik0 + "#" + sotrudnik1 + "#" + sotrudnik2 + "#" + sotrudnik3 + "#" + sotrudnik4 + "#" + sotrudnik5 + "#" + sotrudnik6;
            }


            string[] strArr = new string[text.Length + 1];//Создаем копию данных из документа и добавляем новые в конец
            for (int i = 0; i < text.Length; i++)
            {
                strArr[i] = text[i];
            }
            strArr[strArr.Length - 1] = sotrudnik;



            File.WriteAllLines(@"D:\Skilbox C#\zadanie 7.8\input.txt", strArr);

        }
        static void DEL()
        {
            
            if (File.Exists(@"input.txt") == false)
            {
                File.WriteAllText(@"input.txt", "");
                
            }

            if (File.Exists(@"input.txt") == false)
            {
                Console.WriteLine("Пока пусто");
            }

            else
            {
                Console.WriteLine("Введите ID сотрудника для УДАЛЕНИЯ!");
                string search_id = Console.ReadLine();

                string text = File.ReadAllText(Path.GetFullPath(@"input.txt"));
                string[] lines = text.Split('#');
                int n = lines.Length / 7;

                string path = @"input.txt";

                Repository1 repo1 = new Repository1(path);
                repo1.Load("1");
                Sotrudniki[] sotrudnik = new Sotrudniki[n];

                Console.WriteLine(sotrudnik[0].ID);
                Console.WriteLine(repo1[1]);
                Console.WriteLine(repo1[2]);

                string[] strArr = new string[n - 1];
                for (int i = 0; i < n - 1; i++)
                {
                    
                    if (search_id == Convert.ToString(repo1[i][0]))
                    {
                        continue;
                    }
                    else
                    {
                        strArr[i] = repo1[i][0] + "#" + repo1[i][1] + "#" + repo1[i][2] + "#" + repo1[i][3] + "#" + repo1[i][4] + "#" + repo1[i][5] + "#" + repo1[i][6];
                        Console.WriteLine(repo1[i][0]);
                        Console.WriteLine(repo1[i][1]);
                        Console.WriteLine(repo1[i][2]);
                        Console.WriteLine(repo1[i][3]);
                        Console.WriteLine(repo1[i][4]);
                        Console.WriteLine(repo1[i][5]);
                        Console.WriteLine(repo1[i][6]);
                        Console.WriteLine(strArr[i]);
                    }
                }
                
                //File.WriteAllLines(@"input.txt", strArr);

            }
        }

        
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
