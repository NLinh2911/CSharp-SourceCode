using System;

namespace Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            // ==== Encapsulation - Tính Đóng Gói ====
            // private - public - internal - protected
            Customer customer1 = new Customer();
            customer1.Purchase();
        }
    }
    class Customer
    {   
        private string id; // backing field
        public string ID // read-only property
        {
            get { return id;} 
        }          
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public Customer () {
            this.id = Guid.NewGuid().ToString();
        }
        public void Purchase () {
            System.Console.WriteLine("{0} buys an item", this.Name);
            ShowPayment();
        }
        private void ShowPayment () {
            System.Console.WriteLine("Payment");
        }
    }
}
