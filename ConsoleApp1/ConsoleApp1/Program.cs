using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Patten matching
            object[] numbers = { "a", 1, 2, "b", new object[] { 3, "d", 4, "e", 5 } };
            Console.WriteLine(sum(numbers));

            //call local func
            func1();

            //call Ref returns and locals 
            int[] num = { 1, 3, 5 };
            //回傳的是ref,不是value
            var fristRef = FirtRef(ref num);
            Console.WriteLine("call First ref func =>data[0]= {0} ", fristRef);
            Console.ReadKey();
        }

        static void func1()
        {
            //local function C#7.0 only
            int func2()
            {
                return 2;
            }
            var result = func2();
            Console.WriteLine("Call func2() = {0}", result);
        }

        //new Patten matching method C#7.0 only
        static int sum(IEnumerable<object> list)
        {
            var result = 0;
            foreach (var val in list)
            {
                //檢查型別是否為int,Patten matching method 1(只能檢查int,不能檢查arry內的)
                //if (val is int num)
                //{
                //    result += num;
                //}

                //檢查型別是否為int,Patten matching method 2,(除了可以檢查int,還可以檢查ary內的int)
                switch (val)
                {
                    case int num:
                        result += num;
                        break;
                    case IEnumerable<object> l when l.Any():  // 使用when做額外的條件限定
                        result += sum(l);
                        break;
                }
            }
            return result;
        }

        //Ref returns and locals
        static ref int FirtRef(ref int[] data)
        {
            //回傳第一筆資料的參考
            data[0] = data[0] + 8;
            return ref data[0];
        }
    }
}
