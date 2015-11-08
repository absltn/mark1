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
using Exception;


namespace myProject
{
    delegate void SellingNotification (string customer, string gas, int qty);   //уведомление покупателя о доставке n баллонов

    [Serializable]
    public class Manufacturer: ISerializable
    {
        private string name {get; set;}
        public List<Gastype> gases;
        public List<Customer> customers;
        public event SellingNotification notify;
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
        public void sell (string customerName, string gasName, int qty)
        {
            if (customers.Exists(x => x.Name == customerName)&&(gases.Exists(x => x.Name == gasName)))
            {
            int index = gases.FindIndex(x => x.Name == gasName);
            if (gases[index].Quantity >= qty)
                gases[index].Quantity -= qty;
            }
            
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
        public int Quantity { get {return quantity;} set { if (value < 0) throw new InvalidDataException(); else quantity = value; } }   //устанавливаем доступное баллонов
        public string Name { get {return name;} set;}

    }




}
