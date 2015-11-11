using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Net;
using System.Threading;


namespace myProject
{
      //уведомление покупателя о доставке n баллонов

    [Serializable]                               //объекты классов будем сериализировать для сохранения информации при перезапуске приложения
    public class Manufacturer
    {
        const string FileName = @"..\..\SavedManufacturer.xml";
        private string name { get; set; }
        public List<Gastype> gases = new List <Gastype>();                                        // объекты Manufacturer хранят в себе списки номенклатуры газов и 
        public List<Customer> customers = new List <Customer>();                                  // покупателей
        public delegate void SellingNotificationDelegate(string customer, string gas, int qty); 

        public void sell(string customerName, string gasName, int qty)
        {
            if (customers.Exists(x => x.Name == customerName) && (gases.Exists(x => x.Name == gasName)))
            {
                int index = gases.FindIndex(x => x.Name == gasName);
                if (gases[index].Quantity >= qty)
                    gases[index].Quantity -= qty;
            }
        }

        public void addCustomer(Customer newCustomer)
        {
            if (customers.Count() == 0)
                customers.Add(newCustomer);
            else if (!customers.Exists(x => x.Name == newCustomer.Name))
                customers.Add(newCustomer);
        }

        public void addGastype(Gastype newGas)
        {
            if (gases.Count() == 0)
                gases.Add(newGas);
            else if (!gases.Exists(x => x.Name == newGas.Name))
                gases.Add(newGas);
            else
            {
                int index = gases.FindIndex(x => x.Name == newGas.Name);
                gases[index].Quantity += newGas.Quantity;
            }
        }



        public void save()
        {
            Stream stream = File.Open(FileName, FileMode.Create);
            SoapFormatter formatter = new SoapFormatter();
            formatter.Serialize(stream, this);
            stream.Close();


        }


    }
    [Serializable]
    public class Customer
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }

        public Customer(string custName)
        {
            Name = custName;
        }
        //private List<Gastype> gastype;
    }

    [Serializable]
    public class Gastype
    {
        private int quantity;
        private string name;
        public int Quantity { get { return quantity; } set { if (value < 0) throw new InvalidDataException(); else quantity = value; } }   //устанавливаем доступное баллонов
        public string Name { get { return name; } set { name = value; } }

        public Gastype(string gName, int qty)
        {
            Quantity = qty;
            Name = gName;
        }

    }
}
