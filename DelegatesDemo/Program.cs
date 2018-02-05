using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesDemo {
    class Program {
        // kháo báo 1 delegate
        public delegate int Calculate (int a, int b);
        
        //
        static void Main (string[] args) {

            // delegate Calculate tham chiếu hay trỏ đến phương thức Add
            Calculate calculateDel1 = new Calculate(Add);
            Console.WriteLine (calculateDel1 (10, 4)); // 14
            
            // delegate Calculate tham chiếu hay trỏ đến phương thức Subtract
            calculateDel1 = Subtract;
            // Console.WriteLine (calculateDel1 (10, 4)); // 6
            Console.WriteLine(calculateDel1.Invoke(10, 4)); // có thể gọi delegate bằng Invoke()
            // gọi/ gán nhiều delegates - Multicast delegates
            Calculate calculateDel2 = Add;
            calculateDel2 += Subtract;
            // Multicast - viết đè lên kết quả của các delegates trước
            // Console.WriteLine(calculateDel2(9, 10)); // chỉ -1 là kết quả của delegate cuối cùng đc in ra
            // Để xem tất cả kết quả
            Console.WriteLine("Multicast del: ");
            foreach (Calculate del in calculateDel2.GetInvocationList())
            {
                Console.WriteLine(del(9, 10));
            }
            // truyền phương thức là tham số đầu vào - like a callback
            Console.WriteLine("Passing as function parameters");
            CalculateHelper (Add, 10, 4);
            // dùng lambda expression để khai báo delegate
            Calculate calculateDel3 = (a, b) => a * b;
            Console.WriteLine("Setting delegates with lambda expression");
            Console.WriteLine(calculateDel3(5, 5));

            // ===== Action<T> & Func<T, TResult> =====
            // Kiểu delegates đc xây dựng sẵn trong .NET
            var numbersList = new List<int>() {0, 1, 2, 3, 4, 5};
            System.Console.WriteLine("Action<T>: ");
            numbersList.ForEach(num => Console.WriteLine(num));
            Action<int, int> addAction = (a, b) => Console.WriteLine(a + b);
            addAction(0, 1);
            var list2 = numbersList.Where(num => num >= 2);
            System.Console.WriteLine("Func<T, TResult>: ");
            foreach (var item in list2)
            {
                System.Console.WriteLine(item);
            }
            Func<int, int, int> addFunc = (a, b) => a + b;
            Console.WriteLine(addFunc(0, 1));
        }
        // Tạo 1 phương thức nhận delegate là tham số đầu vào
        public static void CalculateHelper (Calculate del, int a, int b) {
            Console.WriteLine (del (a, b));
        }
        // khai báo 2 phương thức Add, Subtract 
        // có cùng kiểu (method signature) với delegate
        public static int Add (int a, int b) {
            return a + b;
        }

        public static int Subtract (int a, int b) {
            return a - b;
        }
    }
}