using ConsoleApplication1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Controller
{
    public class OrderBy
    {
        /// <summary>
        /// 排序
        /// </summary>
        public static void OrderBys()
        {
            List<arrCtg> list = new List<arrCtg>() { 
            new arrCtg{Age="18",Name="张三",Sex="男"},
            new arrCtg{Age="20",Name="李四",Sex="女"},
            new arrCtg{Age="26",Name="王五",Sex="男"},
            new arrCtg{Age="29",Name="赵六",Sex="男"},
            new arrCtg{Age="30",Name="田七",Sex="女"}
            };

            // LINQ语句
            var q = from n in list
                    // 升序
                    // orderby n.Age
                    // 降序
                    orderby n.Age descending
                    select n;

            StringBuilder sb = new StringBuilder();
            foreach (var item in q)
            {
                sb.AppendLine(string.Format("姓名：{0} 年龄:{1}   性别：{2}", item.Name, item.Age, item.Sex));
            }
            Console.WriteLine("LINQ语句");
            Console.Write(sb.ToString());

            //============================================================================================================================================================================================================================================================

            // 方法语句
            var arr = list
                // 升序
                // .OrderBy(e => e.Age);
                // 降序
                .OrderByDescending(e => e.Age);

            StringBuilder sb2 = new StringBuilder();
            foreach (var item in arr)
            {
                sb2.AppendLine(string.Format("姓名：{0} 年龄:{1}   性别：{2}", item.Name, item.Age, item.Sex));
            }
            Console.WriteLine("方法语句");
            Console.Write(sb2.ToString());

            Console.ReadKey();
        }
    }
}
