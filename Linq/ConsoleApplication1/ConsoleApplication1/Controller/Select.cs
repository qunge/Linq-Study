using ConsoleApplication1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Controller
{
   public class Select
    {
        /// <summary>
        /// 查询取得所有的列
        /// </summary>
        public void SelectList()
        {
            List<arrCtg> list = new List<arrCtg>() { 
            new arrCtg{Age="18",Name="张三",Sex="男"},
            new arrCtg{Age="20",Name="李四",Sex="女"},
            new arrCtg{Age="26",Name="王五",Sex="男"},
            new arrCtg{Age="29",Name="赵六",Sex="男"},
            new arrCtg{Age="30",Name="田七",Sex="女"}
            };
            // 取得所有列
            //var arr = from n in list
            //          where Convert.ToInt32(n.Age) > 18
            //          select n;

            // 取得单列
            //var arr = from n in list
            //          where Convert.ToInt32(n.Age) > 18
            //          select n.Name;

            // 取得某几列
            var arr = from n in list
                      where Convert.ToInt32(n.Age) > 18
                      select new
                      {
                          n.Name,
                          n.Age
                      };

            StringBuilder sb = new StringBuilder();
            foreach (var item in arr)
            {
                sb.AppendLine(string.Format("姓名：{0} 年龄{1}", item.Name, item.Age));
            }
            Console.Write(sb.ToString());
            Console.ReadKey();
        }
    }
}
