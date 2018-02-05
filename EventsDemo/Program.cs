using System;

namespace EventsDemo {
    class Program {
        static void Main (string[] args) {
            // Metronome m = new Metronome ();
            // Listener l = new Listener ();
            // l.Subscribe (m);
            // m.Start ();
            // ======
            var customer1 = new Customer();
            var service1 = new EmailService();
            // service1 subscribes OnEmailSubscription event
            customer1.OnEmailSubscription += service1.SendMarketingEmail;
            // fires event
            customer1.SubscribeEmail();
            // add anonymous delegate to OnBuying event
            customer1.OnBuying += delegate(object sender, BuyEventArgs e) {
                Console.WriteLine($"Customer buys {e.ProductName}");
            };
            // lambda expressions
            // no need to write out params data types -> .NET will figure it out
            customer1.OnBuying += (sender, e) => Console.WriteLine("Delegate with lambda expressions");
            // fires event
            customer1.BuyProduct(new BuyEventArgs() { ProductName = "Choco Cake"});
            customer1.BuyFruits();

        }
    }
    public class TickEventArgs : EventArgs {
        private DateTime TimeNow;
        public DateTime Time {
            set {
                TimeNow = value;
            }
            get {
                return this.TimeNow;
            }
        }
    }
    public class Metronome {
        public event TickHandler Tick;

        public delegate void TickHandler (Metronome m, TickEventArgs e);
        public void Start () {
            int count = 5;
            while (count > 0) {
                System.Threading.Thread.Sleep (1000);
                if (Tick != null) {
                    TickEventArgs e = new TickEventArgs ();
                    e.Time = DateTime.Now;
                    Tick (this, e);
                }
                count--;
            }
        }
    }
    public class Listener {
        public void Subscribe (Metronome m) {
            m.Tick += new Metronome.TickHandler (HeardIt);
        }
        private void HeardIt (Metronome m, TickEventArgs e) {
            System.Console.WriteLine ($"HEARD IT AT {e.Time}");
        }

    }
    public class BuyEventArgs : EventArgs {
        public string ProductName { get; set; }

    }
    class Customer {
        // 
        public delegate void CustomerHandler (Customer c, TickEventArgs e);
        //
        public event CustomerHandler OnEmailSubscription;
        public void SubscribeEmail () {
            // phải kiểm tra xem có ai lắng nghe sự kiện không
            if (OnEmailSubscription != null) {
                // phát sự kiện
                var e = new TickEventArgs() { Time = DateTime.Now };
                OnEmailSubscription.Invoke (this, e);
            }
            // một cách khác để gọi
            // var del = OnEmailSubscription as CustomerRegistrationHandler;
            // if (del != null){
            //     del();
            // }
        }
        //
        public event EventHandler<BuyEventArgs> OnBuying;
        public void BuyProduct (BuyEventArgs e){
            if (OnBuying != null) {
                OnBuying(this, e);
            }
        }
        public void BuyFruits () {
            string[] productName = new string[] {"Apple", "Banana", "Orange"};
            for (int i = 0; i < 3; i++)
            {
                BuyProduct(new BuyEventArgs() {ProductName = productName[i]});
            }
        }
    }
    class EmailService {

        public void SendMarketingEmail (Customer c, TickEventArgs e) {
            Console.WriteLine ("Sending a marketing email to a new customer at {0}", e.Time);
        }
    }
}