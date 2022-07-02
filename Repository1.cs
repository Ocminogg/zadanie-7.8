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
    struct Repository1
    {
        private Sotrudniki[] sotrudnik;
        private string path;
        int index;
        

        public Repository1(string Path)
        {
            this.path = Path;
            this.index = 0;
            this.sotrudnik = new Sotrudniki[6];
        }

        public void Resize(bool Flag)
        {
            Array.Resize(ref this.sotrudnik, this.sotrudnik.Length*2);
        }

        public void Add(Sotrudniki ConcreteSotrudnik)
        {
            this.Resize(index >= this.sotrudnik.Length);
            this.sotrudnik[index] = ConcreteSotrudnik;
            this.index++;
            
        }
        public int Len()
        {
            return this.sotrudnik.Length;
        }
        public string this [int index]
        {
            get { return this.sotrudnik[index].Print1(); }
        }

        public void Load(string Flag)
        {
            string TEXT = "";
            
            using (StreamReader sr = new StreamReader(this.path))
            {
                if (Flag == "1")
                {
                    while (!sr.EndOfStream)
                    {
                        string[] args = sr.ReadLine().Split('#');

                        if (args[0] == null)
                        {
                            break;
                        }
                        Add(new Sotrudniki(args[0], Convert.ToDateTime(args[1]), args[2], Convert.ToInt32(args[3]), Convert.ToInt32(args[4]), args[5], args[6]));
                        
                    }
                }
                
                
                if (Flag == "2")
                {
                    int T = 0;
                    Console.WriteLine("Введите ID для удаления");
                    string IDDel = Console.ReadLine();
                    for (int i = 0; i < this.sotrudnik.Length; i++)
                    {
                        object ID = this.sotrudnik[i].ID;

                        if (Convert.ToString(ID) == "")
                        {
                            break;
                        }
                        if (IDDel == Convert.ToString(ID))
                        {
                            T = 1;
                            continue;
                        }
                        if (T != 1)
                        {                         
                            object Date_add = this.sotrudnik[i].Date_add;
                            object FIO = this.sotrudnik[i].FIO;
                            object Old = this.sotrudnik[i].Old;
                            object Tall = this.sotrudnik[i].Tall;
                            object Date_of_Birth = this.sotrudnik[i].Date_of_Birth;
                            object Place_of_Birth = this.sotrudnik[i].Place_of_Birth;
                            TEXT += Convert.ToString(ID) + "#" + Convert.ToString(Date_add) + "#" + Convert.ToString(FIO) + "#" + Convert.ToString(Old) + "#" + Convert.ToString(Tall) + "#" + Convert.ToString(Date_of_Birth) + "#" + Convert.ToString(Place_of_Birth) + "\r\n";
                            
                        }
                        if (T == 1)
                        {
                            object Date_add = this.sotrudnik[i].Date_add;
                            object FIO = this.sotrudnik[i].FIO;
                            object Old = this.sotrudnik[i].Old;
                            object Tall = this.sotrudnik[i].Tall;
                            object Date_of_Birth = this.sotrudnik[i].Date_of_Birth;
                            object Place_of_Birth = this.sotrudnik[i].Place_of_Birth;
                            TEXT += Convert.ToString(Convert.ToInt32(ID)-1) + "#" + Convert.ToString(Date_add) + "#" + Convert.ToString(FIO) + "#" + Convert.ToString(Old) + "#" + Convert.ToString(Tall) + "#" + Convert.ToString(Date_of_Birth) + "#" + Convert.ToString(Place_of_Birth) + "\r\n";

                        }
                    }
                    
                    
                }
                if (Flag == "3")
                {
                    Console.WriteLine("Введите ID для редактирования");
                    string IDRed = Console.ReadLine();
                    for (int i = 0; i < this.sotrudnik.Length; i++)
                    {
                        object ID = this.sotrudnik[i].ID;
                        object Date_add = this.sotrudnik[i].Date_add;
                        object FIO = this.sotrudnik[i].FIO;
                        object Old = this.sotrudnik[i].Old;
                        object Tall = this.sotrudnik[i].Tall;
                        object Date_of_Birth = this.sotrudnik[i].Date_of_Birth;
                        object Place_of_Birth = this.sotrudnik[i].Place_of_Birth;
                        if (Convert.ToString(ID) == "")
                        {
                            break;
                        }
                        if (IDRed == Convert.ToString(ID))
                        {
                            Console.WriteLine("Было:");
                            Console.WriteLine(ID);
                            Console.WriteLine(Date_add);
                            Console.WriteLine(FIO);
                            Console.WriteLine(Old);
                            Console.WriteLine(Tall);
                            Console.WriteLine(Date_of_Birth);
                            Console.WriteLine(Place_of_Birth);
                            Console.WriteLine("Ваши изменения по порядку:");
                            
                            Date_add = Console.ReadLine();
                            FIO = Console.ReadLine();
                            Old = Console.ReadLine();
                            Tall = Console.ReadLine();
                            Date_of_Birth = Console.ReadLine();
                            Place_of_Birth = Console.ReadLine();
                            TEXT += Convert.ToString(ID) + "#" + Convert.ToString(Date_add) + "#" + Convert.ToString(FIO) + "#" + Convert.ToString(Old) + "#" + Convert.ToString(Tall) + "#" + Convert.ToString(Date_of_Birth) + "#" + Convert.ToString(Place_of_Birth) + "\r\n";

                            continue;
                        }
                        else
                        {
                            TEXT += Convert.ToString(ID) + "#" + Convert.ToString(Date_add) + "#" + Convert.ToString(FIO) + "#" + Convert.ToString(Old) + "#" + Convert.ToString(Tall) + "#" + Convert.ToString(Date_of_Birth) + "#" + Convert.ToString(Place_of_Birth) + "\r\n";

                        }
                    }

                    
                }
            }
            
            if ((Flag == "2") ^ (Flag == "3"))
            {

                File.WriteAllText(@"input.txt", TEXT);

                this.path = @"input.txt";
                this.index = 0;
                this.sotrudnik = new Sotrudniki[6];
                using (StreamReader sr = new StreamReader(this.path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] args = sr.ReadLine().Split('#');

                        if (args[0] == null)
                        {
                            break;
                        }
                        Add(new Sotrudniki(args[0],Convert.ToDateTime( args[1]), args[2], Convert.ToInt32(args[3]), Convert.ToInt32(args[4]), args[5], args[6]));
                    }
                }
                    
            }
               

        }

        public void Save()
        {
            using (StreamReader sr = new StreamReader(this.path))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');
                    //Add(new Sotrudniki(args[0], args[1], args[2], Convert.ToInt32(args[3]), Convert.ToInt32(args[4]), args[5], args[6]));
                    object ID = this.sotrudnik[0];
                    object Date_add = this.sotrudnik[1];
                    object FIO = this.sotrudnik[2];
                    object Old = this.sotrudnik[3];
                    object Tall = this.sotrudnik[4];
                    object Date_of_Birth = this.sotrudnik[5];
                    object Place_of_Birth = this.sotrudnik[6];
                    string TEXT = Convert.ToString(ID) + "#" + Convert.ToString(Date_add) + "#" + Convert.ToString(FIO) + "#" + Convert.ToString(Old) + "#" + Convert.ToString(Tall) + "#" + Convert.ToString(Date_of_Birth) + "#" + Convert.ToString(Place_of_Birth);

                    File.WriteAllText(@"input.txt", TEXT);
                }
            }
        }

        public void PrintDbToConsoleMonth()
        {
            var cultureInfo = new CultureInfo("ru-RU");
            Console.WriteLine("Введите диапозон дат от и до");
            Console.WriteLine("От");
            string start = Console.ReadLine();
            var parsedDateStart = DateTime.Parse(start, cultureInfo);
            Console.WriteLine("До");
            string end = Console.ReadLine();
            var parsedDateEnd = DateTime.Parse(end, cultureInfo);
            for (int i = 0; i < index; i++)
            {
                var parsedDate = DateTime.Parse(Convert.ToString(this.sotrudnik[i].Date_add), cultureInfo);
                if ((parsedDateStart <= parsedDate)&(parsedDate <= parsedDateEnd))
                {
                    Console.WriteLine(this.sotrudnik[i].Print1());
                }
                
            }
        }
        public void PrintDbToConsoleMonthSort()
        {
            
            var cultureInfo = new CultureInfo("ru-RU");

            DateTime[] sotrudnikiData = new DateTime[index];
            Console.WriteLine("Если хотите сортировку по возрастанию, то введите 1, если по убыванию 2");
            string Flag = Console.ReadLine();
            
            for (int i = 0; i < index; i++)
            {
                var parsedDate = DateTime.Parse(Convert.ToString(this.sotrudnik[i].Date_add), cultureInfo);
                sotrudnikiData[i] = parsedDate;

            }
            

            if (Flag == "1")
            {
                IEnumerable<DateTime> query = from date in sotrudnikiData
                                              orderby date
                                              select date;
                foreach (DateTime str in query)
                {
                    for (int i = 0; i < index; i++)
                    {
                        var parsedDateSotrudnik = DateTime.Parse(Convert.ToString(this.sotrudnik[i].Date_add), cultureInfo);
                        if (str == parsedDateSotrudnik)
                        {
                            Console.WriteLine(this.sotrudnik[i].Print1());
                            break;
                        }
                        else
                            continue;

                    }
                }
            }
            else
            {
                IEnumerable<DateTime> query = from date in sotrudnikiData
                                              orderby date descending
                                              select date;
                foreach (DateTime str in query)
                {
                    for (int i = 0; i < index; i++)
                    {
                        var parsedDateSotrudnik = DateTime.Parse(Convert.ToString(this.sotrudnik[i].Date_add), cultureInfo);
                        if (str == parsedDateSotrudnik)
                        {
                            Console.WriteLine(this.sotrudnik[i].Print1());
                            break;
                        }
                        else
                            continue;

                    }
                }
            }

            
                
        }
        public void PrintDbToConsole()
        {
            for(int i = 0; i < index; i++)
            {
                Console.WriteLine(this.sotrudnik[i].Print1());
            }
        }

        public void PrintDbIDToConsole(string ID)
        {
            for (int i = 0; i < index; i++)
            {
                if (this.sotrudnik[i].ID == ID)
                {
                    Console.WriteLine(this.sotrudnik[i].Print1());
                }
            }
        }

        public void DeletetDbID(string ID)
        {
            string[] TEXT = new string[sotrudnik.Length];
            for (int i = 0; i < index; i++)
            {
                if (this.sotrudnik[i].ID == ID)
                {
                    continue;
                }
                else
                {
                    TEXT[i] = this.sotrudnik[i].ID + "#" + this.sotrudnik[i].Date_add + "#" + this.sotrudnik[i].FIO + "#" + this.sotrudnik[i].Old + "#" + this.sotrudnik[i].Tall + "#" + this.sotrudnik[i].Date_of_Birth + "#" + this.sotrudnik[i].Place_of_Birth;
                    
                }
            }
            File.WriteAllLines(@"input.txt", TEXT);
        }
        //public Repository1(params Sotrudniki[] Args)
        //{
        //    sotrudnik = Args;
        //}


    }
}
