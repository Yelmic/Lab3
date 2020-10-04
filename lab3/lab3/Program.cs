using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Количество всех абонентов: " + Phone.people);
            Phone phone1 = new Phone("Дроздович", "Захар", "Сергеевич", "пр. Независимости, 20", 150000, 10000, 130, 90);
            phone1.Show1();
            phone1.Balance(out int balance, phone1.Credit, phone1.Debet);//вызов метода

            Phone phone2 = new Phone("Иванов", "Иван", "Иванович", "ул. Володарская, д.17", 20000, 500, 90, 0);
            phone2.Show1();
            phone2.Balance(out balance, phone2.Credit, phone2.Debet);

            Phone phone3 = new Phone("Сергеев", "Сергей", "Сергеевич", "ул. Октябрьская, д.23", 2000, 100, 120, 100);
            phone3.Show1();
            phone3.Balance(out balance, phone3.Credit, phone3.Debet);

            Phone phone4 = new Phone("Петров", "Петр", "Петрович", "ул. Свердлова, д.1", 1000, 200, 90, 30);
            phone4.Show1();
            phone4.Balance(out balance, phone4.Credit, phone4.Debet);

            Phone phone5 = new Phone();
            phone5.Show1();

            Phone phone6 = new Phone("Котов", "Юрий", 30000, 130, 0);
            phone6.Show2();

            Phone phone7 = new Phone("Андреев", "Андрей", 12000, 60, 0);
            phone7.Show2();
            Phone phone8 = new Phone("Сидоров", "Алексей", 4000, 110, 30);
            phone8.Show2();

            Console.WriteLine();
            Console.WriteLine("Количество присутствующих абонентов: " + Phone.size);
            int count = 0;
            object[] ListOfPhone = new object[8];
            ListOfPhone[0] = phone1;
            ListOfPhone[1] = phone2;
            ListOfPhone[2] = phone3;
            ListOfPhone[3] = phone4;
            ListOfPhone[4] = phone5;
            ListOfPhone[5] = phone6;
            ListOfPhone[6] = phone7;
            ListOfPhone[7] = phone8;
            Console.WriteLine("########");
            Console.WriteLine("Сортировка абонентов по выбору связи");
            Console.WriteLine();
            Console.WriteLine("Абоненты, превышающих внутригородское время ");
            foreach (Phone phones in ListOfPhone)
            {
                count++;
                if (phones.In_city_time>110) Console.WriteLine(phones.Surname+" "+ phones.Name+" "+phones.Fathername);
            }
            Console.WriteLine("#######");
            Console.WriteLine("Фамилии тех, кто пользовался межгородской связью ");
            foreach (Phone phones in ListOfPhone)
            {
                count++;
                if (phones.Out_city_time >0) Console.WriteLine(phones.Surname+" " + phones.Name+ " "+phones.Fathername+" Количество минут: " + phones.Out_city_time);
            }
            Console.WriteLine("Эквивалентность абонентов:");
            Console.WriteLine(phone1.Equals(phone2));
            Console.WriteLine(phone4.Out_city_time.Equals(phone8.Out_city_time));
            Console.WriteLine("Xеш коды:");
            Console.WriteLine(phone1.GetHashCode());
            Console.WriteLine(phone6.GetHashCode());
            Console.WriteLine(phone7.GetHashCode());
            Console.WriteLine("Приводим к строке (кредит и дебет):");
            Console.WriteLine(phone2.Credit.ToString());
            Console.WriteLine(phone5.Debet.ToString());
            Console.ReadKey();

        }
    }



    public partial class Phone
    {
        protected int id;
        public const int people = 100;
        private string surname;
        private string name;
        private string fathername;
        private int in_city_time;//время внутригородских разговоров
        private  int out_city_time;//время междугородник разговоров
        private string adress;
        private int credit;
        private int debet;
        internal readonly uint credit_card;//поле для чтения
        public static int size;
        

        public string Surname
        {
            get
            {
                return this.surname;
            }
            set
            {
                this.surname = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public string Fathername
        {
            get
            {
                return this.fathername;
            }
            set
            {
                this.fathername = value;
            }
        }
        public string Adress
        {
            get
            {
                return this.adress;
            }
            set
            {
                this.adress = value;
            }
        }
        public int Credit
        {
            get
            {
                return this.credit;
            }
            set
            {
                this.credit = value;
            }

        }
        public int Debet
        {
            get
            {
                return this.debet;
            }
            set
            {
                this.debet = value;
            }

        }
        public int In_city_time
        {
            get
            {
                return this.in_city_time;
            }
            set
            {
                this.in_city_time = value;
            }

        }
        public int Out_city_time
        {
            get
            {
                return this.out_city_time;
            }
            set
            {
                this.out_city_time = value;
            }

        }



        static Phone()
        {
            size = 0;
        }
        //конструктор
        public Phone(string surname, string name, string fathername, string adress, int credit, int debet, int in_city_time, int out_city_time) //передаем значения
        {
            size++;
            this.name = name;
            this.surname = surname;
            this.fathername = fathername;
            this.adress = adress;
            this.credit = credit;
            this.debet = debet;
            this.in_city_time = in_city_time;
            this.out_city_time = out_city_time;
            this.credit_card = Hash(out int id, name, credit);
        }
        public Phone(string surname, string name, int credit, int in_city_time, int out_city_time)
        {
            size++;
            this.surname = surname;
            this.name = name;
            this.credit = credit;
            this.out_city_time = out_city_time;
            this.in_city_time = in_city_time;
            this.credit_card = Hash(out int id, name, credit);
        }
        public Phone()//не передаем
        {
            size++;
            surname = "Mikhnovetz";
            name = "Elena";
            fathername = "Sergeevna";
            adress = "October street";
            credit = 20000;
            debet = 10000;
            in_city_time = 60;
            out_city_time = 30;
            this.credit_card = Hash(out int id, name, credit);
        }

        //метод расчета баланса
        public int Balance(out int balance, int credit, int debet)
        {
            balance = credit -debet;
            Console.WriteLine("Баланс: " + balance);
            return balance;
        }
        public void Show1()
        {
            Console.WriteLine("_________________________________________________________________");
            Console.WriteLine("Кредитная карта: " + credit_card);
            Console.WriteLine("Фамилия:" + surname + "\nИмя: " + name + "\nОтчество: " + fathername + "\tАдрес: " + adress + "\nКредит: " + credit+"\nДебет: " + debet+"\nВремя внутригородских разговоров: " + in_city_time + "\nВремя межгородских разговоров: " + out_city_time);

        }
        public void Show2()
        {
            Console.WriteLine("_________________________________________________________________");
            Console.WriteLine("Кредитная карта: " + credit_card);
            Console.WriteLine("Фамилия:" + surname + "\nИмя: " + name + "\nКредит: " + credit + "\nВремя внутригородских разговоров: " + in_city_time + "\nВремя межгородских разговоров: " + out_city_time);
        }
        //вычисление хэша
        public uint Hash(out int id, string name, int credit)
        {
            Random random = new Random();
            id = random.Next(1, 15);
            int key = ((int)credit * 13 + name.Length) / id * 6;
            uint hash = (uint)key;
            return hash;
        }

    }
}


