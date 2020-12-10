using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8OOP
{
    class OutOfListException : NullReferenceException
    {
        public string NewMessage { get; set; }
        public OutOfListException(string message)
        {
            NewMessage = message;
        }
    }
    interface IAction <T> //обобщенный интерфейс
    {
        void Add(T elem);
        void Delete(T elem);
        void Show();
    }
    public class CollectionType <T> : IAction <T> //обобщенный класс, реализация методов интерфейса //where T : Amount
    {
        List<T> Surprise = new List<T>(); //обобщенная коллекция
        public void Add(T elem)
        {
            Surprise.Add(elem);
        }
        public void Delete(T elem)
        {
            if (Surprise.Contains(elem))
                Surprise.Remove(elem);
            else
                throw new OutOfListException("Соответствующего элемента не найдено в списке");

        }
        public void Show()
        {
            foreach (T i in Surprise)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }

    }
    public class Amount { }
    public class Transaction <T> where T : Amount { } //пример ограничения на обобщение. Универсальный параметр типа Salary
    public class UserInfo //пользовательский класс, который будет использоваться в качестве параметра обобщения
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public UserInfo()
        {
            Name = "Angelina";
            Surname = "Draguts";
            City = "Minsk";
            Age = 21;
        }
        public UserInfo(string name, string surname, string city, int age)
        {
            Name = name;
            Surname = surname;
            City = city;
            Age = age;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            CollectionType<string> Surprise = new CollectionType<string>();

            Surprise.Add("Ballons");
            Surprise.Add("Flowers");
            Surprise.Add("Cake");
            Surprise.Add("Postcards");
            Surprise.Add("Jewerly");

            Console.WriteLine("Surprises can be different: ");
            Surprise.Show();

            Console.WriteLine("Удаляем цветы из списка... ");
            Surprise.Delete("Flowers");

            Console.WriteLine("Проверим, всё ли получилось:");
            Surprise.Show();

            CollectionType<UserInfo> UserInformationCollection = new CollectionType<UserInfo>();
            UserInfo user1 = new UserInfo("Valentina", "Ivantsova", "Minsk", 19);
            UserInfo user2 = new UserInfo("Nadezda", "Kireenko", "Minsk", 19);
            UserInfo user3 = new UserInfo("Diana", "Nikolauk", "Minsk", 19);
            UserInformationCollection.Add(user1);
            UserInformationCollection.Add(user2);
            UserInformationCollection.Add(user3);

            try
            {
                UserInformationCollection.Delete(user2);
            }
            catch (OutOfListException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Проверка на исключения выполнена!");
            }



            Console.ReadKey();
        }
    }
}
