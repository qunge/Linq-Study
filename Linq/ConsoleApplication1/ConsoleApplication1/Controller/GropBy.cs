using ConsoleApplication1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Controller
{
    public class GropBy
    {
        /// <summary>
        /// 分组
        /// </summary>
        public static void GropBys()
        {
            List<arrCtg> list = new List<arrCtg>() { 
            new arrCtg{Age="18",Name="张三",Sex="男"},
            new arrCtg{Age="20",Name="李四",Sex="女"},
            new arrCtg{Age="26",Name="王五",Sex="男"},
            new arrCtg{Age="29",Name="赵六",Sex="男"},
            new arrCtg{Age="30",Name="田七",Sex="女"}
            };

            var arr = from n in list
                      // where n.Sex=="男"&&Convert.ToInt32(n.Age)>=26
                      orderby n.Age
                      group n by n.Sex;
            StringBuilder sb = new StringBuilder();
            foreach (var item in arr)
            {
                if (item.Key == "男")
                    sb.AppendFormat("男生为：{0}", item.Key);
                else
                    sb.AppendFormat("女生为：{0}", item.Key);
                sb.AppendLine();
                foreach (var itm in item)
                {
                    sb.AppendFormat("姓名：{0} 性别{1}   年龄{2}", itm.Name, itm.Sex, itm.Age);
                    sb.AppendLine();
                }
            }
            Console.Write(sb.ToString());
            Console.ReadKey();
        }
    }
}
