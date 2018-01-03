using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateTest
{
    class Program
    {
        delegate void insertRecord(string name);
  
        static void Main(string[] args)
        {
            // 委托：通过lambda表达式直接实现
            insertRecord delegate1 = (name) => { Console.WriteLine("this is a " + name); };
            delegate1("delegate");
            Thread t1 = new Thread(delegate () { });  // 匿名委托
            Thread t2 = new Thread(() => { }); // 直接用lambda表达式



            //------------------------------------------------------------------------------
            // Action:有一个或多个（最多16个）形参但无返回值的委托，但不用提前申明该delegate类型
            Action<string> action = new Action<string>((name) =>
            {
                Console.WriteLine("this is a " + name);
            });
            action("action");
            /* 其他使用场景 
               this.txtContent.Invoke(new Action(){ 业务逻辑 });
             */


            //------------------------------------------------------------------------------
            //Func:有一个或多个（最多16个）形参和返回值的委托，但不用提前申明该delegate类型
            Func<string, string> func = new Func<string, string>((name) => "this is a " + name);
            Console.WriteLine(func("func"));
            Console.ReadLine();

            // 这里有一个问题，为什么ThreadStart委托可以直接使用lambda表达式，而Control.invoke无法直接使用？
            // 以下是解释：简而言之，因为Thread的ThreadStart委托类型固定，而Control.Invoke的委托类型不固定
            /*The problem the user is seeing is that the Thread ctor accepts a specific delegate -- 
              the ThreadStart delegate.  The C# compiler will check and make sure your anonymous method 
              matches the signature of the ThreadStart delegate and, if so, produces the proper code 
              under-the-covers to create the ThreadStart delegate for you.
              
              But Control.Invoke is typed as accepting a "Delegate".  This means it can accept any delegate-derived type.
              The example above shows an anonymous method that has a void return type and takes no parameters.  
              It's possible to have a number of delegate-derived types that match that signature
              (such as MethodInvoker and ThreadStart -- just as an example).  Which specific delegate
              should the C# compiler use?  There's no way for it to infer the exact delegate type so the
              compiler complains with an error.*/

         }
     }
 }
