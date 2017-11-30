using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ConsoleApplication1.Model;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // GropBy();
            // Select();
            // SelectMany();
            OrderBy();
        }

        #region select
        /// <summary>
        /// select
        /// </summary>
        private static void Select()
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
        #endregion

        #region GropBy
        /// <summary>
        /// 分组
        /// </summary>
        private static void GropBy()
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
        #endregion

        #region SelectMany
        /// <summary>
        /// SelectMany 可适用于嵌套循环
        /// </summary>
        private static void SelectMany()
        {
            //  这里有7个老师，每个人有3个学生，总共21一个学生里 查询哪3个倒霉蛋没考及格

            List<Teacher> teaches = new List<Teacher>() { 
                new Teacher("a",new List<Student>{ new Student(100),new Student(90),new Student(30) }),
                new Teacher("b",new List<Student>{ new Student(100),new Student(90),new Student(60) }),
                new Teacher("c",new List<Student>{ new Student(100),new Student(90),new Student(40) }),
                new Teacher("d",new List<Student>{ new Student(100),new Student(90),new Student(60) }),
                new Teacher("e",new List<Student>{ new Student(100),new Student(90),new Student(50) }),
                new Teacher("f",new List<Student>{ new Student(100),new Student(90),new Student(60) }),
                new Teacher("g",new List<Student>{ new Student(100),new Student(90),new Student(60) })
            };

            // 嵌套循环方法
            // 先遍历老师
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("嵌套循环方法");
            foreach (Teacher t in teaches)
            {
                // 再遍历老师名下的学生
                foreach (Student s in t.Students)
                {
                    // 判断学生成绩
                    if (s.Score < 60)
                    {
                        sb.AppendLine(string.Format("老师：{0} 学生成绩{1}",t.Name,s.Score));
                    }
                }
            }
            Console.Write(sb.ToString());
//==============================================================================================================================================================
            // LINQ方法
            var arr = from t in teaches
                      from s in t.Students
                      where s.Score < 60
                      select new { t.Name, s.Score };
            StringBuilder sb2 = new StringBuilder();
            foreach (var item in arr)
            {
                sb2.AppendLine(string.Format("老师：{0} 学生成绩：{1}", item.Name, item.Score));
            }
            Console.WriteLine("LINQ方法");
            Console.Write(sb2.ToString());

//==============================================================================================================================================================
            // 方法语句
            var arr2 = teaches
                .SelectMany(e => e.Students.Where(s => s.Score < 60));

            StringBuilder sb3 = new StringBuilder();
            foreach (var item in arr2)
            {
                sb3.AppendLine(string.Format("学生成绩：{0}", item.Score));
            }
            Console.WriteLine("方法语句");
            Console.Write(sb3.ToString());

            Console.ReadKey();
        }
        #endregion

        #region 排序
        /// <summary>
        /// 排序
        /// </summary>
        private static void OrderBy()
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
                sb.AppendLine(string.Format("姓名：{0} 年龄:{1}   性别：{2}", item.Name, item.Age,item.Sex));
            }
            Console.WriteLine("LINQ语句");            
            Console.Write(sb.ToString());

//============================================================================================================================================================================================================================================================
           
            // 方法语句
            var arr = list
                // 升序
                // .OrderBy(e => e.Age);
                // 降序
                .OrderByDescending(e=>e.Age);
            
            StringBuilder sb2 = new StringBuilder();
            foreach (var item in arr)
            {
                sb2.AppendLine(string.Format("姓名：{0} 年龄:{1}   性别：{2}", item.Name, item.Age, item.Sex));
            }
            Console.WriteLine("方法语句");
            Console.Write(sb2.ToString());

            Console.ReadKey();
        }
        #endregion
    }
}
