using ConsoleApplication1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Controller
{
    public class Revers
    {
        /// <summary>
        /// Reverse 将会把序列中的元素按照从后到前的循序反转。需要注意的是，Reverse 方法的返回值是 void
        /// </summary>
        public void revers()
        {
            List<arrCtg> list = new List<arrCtg>() { 
            new arrCtg{Age="18",Name="张三",Sex="男"},
            new arrCtg{Age="20",Name="李四",Sex="女"},
            new arrCtg{Age="26",Name="王五",Sex="男"},
            new arrCtg{Age="29",Name="赵六",Sex="男"},
            new arrCtg{Age="30",Name="田七",Sex="女"}
            };

            var q = from n in list
                    select n;
            Console.WriteLine("反转前数据：");
            StringBuilder sb = new StringBuilder();
            foreach (var item in q)
            {
                sb.AppendLine(string.Format("姓名：{0} 年龄{1}", item.Name, item.Age));
            }
            Console.WriteLine(sb.ToString());
            // 反转
            var arr = q.Reverse();
            Console.WriteLine("反转后数据：");
            StringBuilder sb2 = new StringBuilder();
            foreach (var item in arr)
            {
                sb2.AppendLine(string.Format("姓名：{0} 年龄{1}", item.Name, item.Age));
            }
            Console.WriteLine(sb2.ToString());
            Console.ReadKey();
        }
    }
}
