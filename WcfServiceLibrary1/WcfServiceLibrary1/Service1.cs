using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public UInt64 GetFibonacciResult(int n)
        {
            UInt64 a = 1, b = 1, c = 0;

            Console.Write("{0} {1}", a, b);

            if (n < 0)
                throw new IndexOutOfRangeException("input must be great than 0");//bad input
            if (n > 100000)
                throw new IndexOutOfRangeException("unreasonable input");//take will take much longer time, will take over all CPU resources and stuck the threadpool

            if (n == 0 || n == 1)
                return 1;

            for (int i = 1; i < n; i++)
            {
                c = a + b;
                Console.Write(" {0}", c);//log and debug usage          
                a = b;
                b = c;
            }

            return c;
        }
    }
}
