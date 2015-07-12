using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            List newList=new List();
            int index=0;
            while (index<6)
            {
                string t=Console.ReadLine();
                newList.Add(int.Parse(t));
                index++;
            }
            Console.WriteLine();
            Console.WriteLine("Printing you List:");
            newList.show(); 

        }
    }
    class Node
    {
        public Node nextNode { get; set;}
        public Node prevNode { get; set;}
        public int value { get; set; }
    }
    class List
    {
        private Node root;
        private Node current;
        private bool empty;
        private int numnodes=0;
        public List()
        {
            root = new Node();
            root.prevNode=root;
            root.nextNode=root;
            current = root;
            empty = true;
            numnodes++;
        }
        public void Add(int value)
        {
            Node Temp = current;
            current.value = value;
            current = new Node();
            current.prevNode = Temp;
            Temp.nextNode = current;
            numnodes++;
            if (empty)
                {
                    empty = false;
                }
        }
        public void show()
        {
           int i=numnodes;
            Node Temp = root;
            while (i>1)
            {
                Console.WriteLine(Temp.value);
                Temp = Temp.nextNode;
                i--;
            }
        }
    }
}
