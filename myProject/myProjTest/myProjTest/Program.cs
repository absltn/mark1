using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myProject;                                      //пространство имет пользовательской библиотеки

namespace myProjTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Manufacturer man1 = new Manufacturer();
            Report report1 = new Report();
            ShortReport report2 = new ShortReport();
            Manufacturer.SellingNotificationDelegate newdelegate = report1.AddRecord;
            newdelegate += report2.AddRecord;
            Menu myMenu = new Menu();
            myMenu.menuText();
            myMenu.mValue = Convert.ToInt32(Console.ReadLine());
           while (myMenu.mValue > 0)                            // сохранение и выход
           {
               switch (myMenu.mValue)
                {
                    case 1:
                        string cName1;
                        Console.WriteLine("Enter unique customer name");
                        cName1 = Console.ReadLine();
                        Customer newCust = new Customer(cName1);
                        man1.addCustomer(newCust);
                        break;
                    case 2:
                        string gName1;
                        int qty = 0;
                        Console.WriteLine("Enter gas name");
                        gName1 = Console.ReadLine();
                        Console.WriteLine("Enter gas quantity >=0");
                        string sQuant = Console.ReadLine();
                        qty = Convert.ToInt16(sQuant);
                        Gastype custGas = new Gastype(gName1, qty);
                        man1.addGastype(custGas);
                        break;
                    case 3:
                        Console.WriteLine("Enter valid customer name, gas name and quantity to be sold.");
                        string cName2, gName2;
                        int qty2;
                        cName2 = Console.ReadLine();
                        gName2 = Console.ReadLine();
                        string sQuant2 = Console.ReadLine();
                        qty2 = Convert.ToInt16(sQuant2);
                        man1.sell(cName2, gName2, qty2);
                        newdelegate(cName2, gName2, qty2);      // проверка работы делегата
                        break;
                    case 4:
                        Console.WriteLine("List of customers:");
                        foreach (Customer cust in man1.customers)
                            Console.WriteLine(cust.Name);
                        break;
                    case 5:
                        Console.WriteLine("List of gases:");
                        foreach (Gastype gas in man1.gases)
                            Console.WriteLine(gas.Name + " " + gas.Quantity);
                        break;
                    case 6:
                        man1.save();
                        break;
                }
                myMenu.menuText();
                myMenu.mValue = Convert.ToInt32(Console.ReadLine());
            }
        } 
    }
    public class Menu
    {
        
        SystemException myException = new SystemException();
        public int mValue;
        public void menuText()
        {
            Console.WriteLine("Manufacturer field created.");
            Console.WriteLine("1 - add customer");
            Console.WriteLine("2 - add gas type");
            Console.WriteLine("3 - to sell gas");
            Console.WriteLine("4 - to view all customers");
            Console.WriteLine("5 - to view all gas types and qty");
            Console.WriteLine("6 - save and exit");
        }
    }

    public class Report
    {
        public List<string> records = new List<string>();
        public void AddRecord(string customer, string gas, int qty)
        {
            records.Add(DateTime.Now + " Customer: " + customer + " Gas: " + gas + " Qty= " + qty);
        }
    }

    public class ShortReport: Report
    {
        public List<string> records = new List<string>();
        new public void AddRecord(string customer, string gas, int qty)
        { 
            records.Add(" Customer: " + customer + " Gas: " + gas + " Qty= " + qty);
        }
    }



}
