using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Net;
using System.Threading;
using System.Runtime.Serialization.Formatters.Soap;
using Exception;


namespace myProject
{
    delegate void SellingNotification(string customer, string gas, int qty);   //уведомление покупателя о доставке n баллонов

    [Serializable]
    public class Manufacturer: ISerializable
    {
<<<<<<< HEAD
        const string FileName = @"..\..\SavedManufacturer.xml";
        private string name { get; set; }
        public List<Gastype> gases;                                        // объекты Manufacturer хранят в себе списки номенклатуры газов и 
        public List<Customer> customers;                                   // покупателей
        public event SellingNotification notify;

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
            if (!customers.Exists(x => x.Name == newCustomer.Name))
                customers.append(newCustomer);
        }

        public void addGastype(Gastype newGas)
=======
        private string name {get; set;}
        public List<Gastype> gases;
        public List<Customer> customers;
        public event SellingNotification notify;
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
        public void sell (string customerName, string gasName, int qty)
>>>>>>> parent of 91f4f61... myProj repo3
        {
            if (!gases.Exists(x => x.Name == newGas.Name))
                gases.append(newGas);
            else
            {
<<<<<<< HEAD
                int index = gases.FindIndex(x => x.Name == gasName);
                gases[index].Quantity += newGas.quantity;
            }
        }



        public void save()
        {
            FileInfo file = Create();

            Stream stream = File.Open(Filename, FileMode.Create);
            SoapFormatter formatter = new SoapFormatter();

=======
            int index = gases.FindIndex(x => x.Name == gasName);
            if (gases[index].Quantity >= qty)
                gases[index].Quantity -= qty;
            }
            
>>>>>>> parent of 91f4f61... myProj repo3
        }
    }

    public class Customer
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }
        //private List<Gastype> gastype;
    }


    public class Gastype
    {
        private int quantity;
        private string name;
        public int Quantity { get { return quantity; } set { if (value < 0) throw new InvalidDataException(); else quantity = value; } }   //устанавливаем доступное баллонов
        public string Name { get { return name; } set; }

    }
}
