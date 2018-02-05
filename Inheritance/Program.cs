using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            // ==== Inheritance - Tính Kế Thừa ====
            // is-a relationship
            Samsung S8 = new Samsung();
            S8.Name = "Samsung Galaxy S8";
            // S8.OS = "Android";
            S8.Call();
            System.Console.WriteLine(S8.OS);
            IPhone iphone7 = new IPhone();
            iphone7.Siri();
            System.Console.WriteLine(iphone7.OS);
            // ==== Polymorphism - Tính Đa Hình ====
            S8.Text();
            iphone7.Text();
            // handle data
            Smartphone phone1 = new Samsung();
            phone1.Call();
            Smartphone phone2 = new IPhone();
            phone2.Call();
            Smartphone[] dataArray = new Smartphone[] {phone1, phone2};
            // ==== Abstract Class ====
            Cat kitty = new Cat();
            kitty.MakeSound();
           
        }
    }
    abstract class Smartphone // base class
    {
        public string Name { get; set; }
        public string OS { get; set; }
        public string SerialNumber { get; set; }

        public abstract void Call (); 
        public abstract void Text (); 
        public abstract void Camera ();
    }
    class Samsung : Smartphone, IBiometricSecurity // derived class
    {
        public Samsung () {
            this.OS = "Android";
        }
        public override void Call () {
            System.Console.WriteLine("Calling with Samsung....");
        }
        public override void Text () {
            System.Console.WriteLine("Texting with Samsung....");
        }
        public override void Camera () {
            System.Console.WriteLine("Taking photos with Samsung ....");
        }
        public void SamsungHealth () {
            System.Console.WriteLine("Using Samsung Health App...");
        }
        public void FingerScan (){
            System.Console.WriteLine("Samsung can check fingers");
        }
        public void EyeScan (){
            System.Console.WriteLine("Samsung can scan eyes...");
        }

    }
    class IPhone : Smartphone, IBiometricSecurity
    {
        public IPhone () {
            this.OS = "iOS";
        }
        public override void Call () {
            System.Console.WriteLine("Calling with Iphone....");
        }
        public override void Text () {
            System.Console.WriteLine("Texting with Iphone....");
        }
        public override void Camera () {
            System.Console.WriteLine("Taking photos with Iphone ....");
        }
        public void Siri () {
            System.Console.WriteLine("Using Siri....");
        }
        public void FingerScan (){
            System.Console.WriteLine("Iphone can check fingers");
        }
        public void EyeScan (){
            System.Console.WriteLine("Iphone can scan eyes...");
        }

    }
    class Laptop : IBiometricSecurity, ILogging
    {
        public void ConnectInternet (){
            System.Console.WriteLine("Laptop can connect internet");
        }
        public void FingerScan (){
            System.Console.WriteLine("Laptop can check fingers");
        }
        public void EyeScan (){
            System.Console.WriteLine("Laptop can scan eyes...");
        }
        public void Log (){
            System.Console.WriteLine("Laptop logs errors when errors happen");
        }
    }
    abstract class Animal {
        public string Name { get; set; }
        public int Age { get; set; }
        public abstract void Move ();
        public abstract void MakeSound();
        public void Breath () {
            System.Console.WriteLine("Breathing...");
        }
    }
    class Cat : Animal {
        public override void Move() {
            System.Console.WriteLine("Cat is moving ");
        }
        public override void MakeSound() {
            System.Console.WriteLine("Moew Moew");
        }
    }
    // ===== INTERFACES ======
    // khai báo 1 khuôn mẫu hay bản giao kèo mà các lớp thực thi nó cần đáp ứng
    // thể hiện mối quan hệ *has-a* - interface là về mặt tính năng
    interface IBiometricSecurity
    {
        void FingerScan(); // no method body
        void EyeScan();
        
    }
    interface ILogging
    {
        void Log(); 
    }

}
