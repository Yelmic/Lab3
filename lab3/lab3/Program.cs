using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Phone
    {
        static Phone()
        {
            Console.WriteLine("Создан новый пользователь");
        }
        public readonly int id;//только для чтения
        public string surname;
        public string name;
        public string fathername;
        public string adress;
        public int card_num;
        public int debet;
        public int credit;
        public int time;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Phone A = new Phone();//срабатывает статический конструктор
            Phone phone = new Phone();
            Console.ReadKey();
        }
    }
}
