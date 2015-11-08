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
            if (customers.Exists(x => x.name == customerName)&&(gases.Exists(x => x.name == gasName)))
            {
            int index = gases.FindIndex(x => x.name == gasName);
            if (gases[index].quantity >= qty)
            }
            
        }
    }

    public class Customer
    { public string name {get;set;}
    private List<Gastype> gastype;
    }


    public class Gastype
    {
        public int quantity { get; private set { if (value < 0) throw new InvalidDataException(); else quantity = value; } }   //устанавливаем доступное баллонов
        public string name { get; private set; }

    }




}
