using System;
using System.Linq;

namespace Test_PreInterview_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            OddEvenList<string> listStr = new OddEvenList<string>();

            bool isMainMenu = true;
            while (isMainMenu)
            {
                isMainMenu = listStr.MainMenu();
            }
        }
    }
    public class Node<T>
    {
        public T data;
        public int index;
    }

    public class OddEvenList<T>
    {
        public int count = 0;
        public List<Node<T>> nodes = new List<Node<T>>();
        public List<Node<T>> randomNodes = new List<Node<T>>();
        public int Add(T input)
        {
            if(input != null)
                nodes.Add(new Node<T> { data = input, index = count});
            return count++;
        }
        public bool Remove(int index)
        {
            nodes.RemoveAt(index);
            foreach(Node<T> node in nodes)
            {
                if(node.index == index)
                    return false;
            }
            return true;
        }
        public T[] GetOdd()
        {
            List<T> oddItems = new List<T>();
            foreach (Node<T> item in nodes)
            {
                if (item.index % 2 != 0)
                    oddItems.Add(item.data);
            }
            return oddItems.ToArray();
        }
        public T[] GetEven() 
        {
            List<T> evenItems = new List<T>();
            foreach (Node<T> item in nodes)
            {
                if (item.index % 2 == 0)
                    evenItems.Add(item.data);
            }
            return evenItems.ToArray();
        }
        public T[] GetRandom() 
        {
            randomNodes = new List<Node<T>>();
            List<T> randomItems = new List<T>();
            foreach (Node<T> item in nodes)
            {
                Random random = new Random();
                int number = random.Next(0, nodes.Count);
                randomNodes.Add(new Node<T> { data = item.data, index = number });
            }
            foreach (Node<T> item in randomNodes.OrderBy(x => x.index))
            {
                randomItems.Add(item.data);
            }
            return randomItems.ToArray();
        }
        public bool MainMenu()
        {
            Console.Write("\r\n");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add");
            Console.WriteLine("2) Remove");
            Console.WriteLine("3) GetOdd");
            Console.WriteLine("4) GetEven");
            Console.WriteLine("5) GetRandom");
            Console.WriteLine("6) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Input: ");
                    T input = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                    int index = Add(input);
                    Console.WriteLine("Index: " + index);
                    return true;
                case "2":
                    Console.Write("Enter Index: ");
                    int indexDel = (int)Convert.ChangeType(Console.ReadLine(), typeof(int));
                    bool result = Remove(indexDel);
                    if (result)
                        Console.WriteLine("Deleted successfully!!");
                    else
                        Console.WriteLine("Delete failed!!");
                    return true;
                case "3":
                    T[] oddItems = GetOdd();
                    foreach (var item in oddItems)
                    {
                        Console.Write(item + " ");
                    }
                    return true;
                case "4":
                    T[] evenItems = GetEven();
                    foreach (var item in evenItems)
                    {
                        Console.Write(item + " ");
                    }
                    return true;
                case "5":
                    T[] randomItems = GetRandom();
                    foreach (var item in randomItems)
                    {
                        Console.Write(item + " ");
                    }
                    return true;
                case "6":
                    return false;
                default:
                    return true;
            }
        }
    }

    
}
