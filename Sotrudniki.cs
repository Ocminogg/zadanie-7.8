using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_7._8
{
    struct Sotrudniki
    {
        public Sotrudniki(string ID, DateTime Date_add, string FIO, int Old, int Tall , string Date_of_Birth, string Place_of_Birth)
        {
            this.ID = ID;
            this.Date_add = Date_add;
            this.FIO = FIO;
            this.Old = Old;
            this.Tall = Tall;
            this.Date_of_Birth = Date_of_Birth;
            this.Place_of_Birth = Place_of_Birth;
        }

        public string ID;

        public void SetID(string NewID)
        { this.ID = NewID; }

        public string GetID()
        { 
            return this.ID;
        }

        public DateTime Date_add { get; set; }

        public string FIO { get; set; }

        public int Old { get; set; }

        public int Tall { get; set; }

        public string Date_of_Birth { get; set; }

        public string Place_of_Birth { get; set; }

        public static void Print (string ID, string Date_add, string FIO, int Old, int Tall, string Date_of_Birth, string Place_of_Birth)
        {
            Console.WriteLine("ID " + ID);
            Console.WriteLine("Время добваления записи " + Date_add);
            Console.WriteLine("Ф. И. О. " + FIO);
            Console.WriteLine("Возраст " + Old);
            Console.WriteLine("Рост " + Tall);
            Console.WriteLine("Дата рождения " + Date_of_Birth);
            Console.WriteLine("Место рождения " + Place_of_Birth);
            Console.WriteLine();
        }
        public string Print1()
        {
            return $"{this.ID} {this.Date_add} {this.FIO} {this.Old} {this.Tall} {this.Date_of_Birth} {this.Place_of_Birth}";
        }
        
    }
}
