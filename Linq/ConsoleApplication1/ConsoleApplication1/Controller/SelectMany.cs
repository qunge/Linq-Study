using ConsoleApplication1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Controller
{
    public class SelectMany
    {
        /// <summary>
        /// SelectMany 可适用于嵌套循环
        /// </summary>
        public static void SelectManys()
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
                        sb.AppendLine(string.Format("老师：{0} 学生成绩{1}", t.Name, s.Score));
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
    }
}
