using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace linq
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Student> stus = new List<Student>();
            stus.Add(new Student()
            {
                Id = 1,
                Name = "zhansan",
                Age = 22,
                Sex = "男"
            });
            stus.Add(new Student()
            {
                Id = 2,
                Name = "lisi",
                Age = 38,
                Sex = "男"
            });
            stus.Add(new Student()
            {
                Id = 3,
                Name = "wanwu",
                Age = 18,
                Sex = "女"
            });
            stus.Add(new Student()
            {
                Id = 4,
                Name = "zhaoliu",
                Age = 41,
                Sex = "女"
            });
            stus.Add(new Student()
            {
                Id = 5,
                Name = "tianqi",
                Age = 19,
                Sex = "男"
            });
            IEnumerable<string> names = stus.Select(s => s.Name);
            IEnumerable<object> namesAndages = stus.Select(s => new { Name = s.Name, Age = s.Age });
            IEnumerable<int> ages = stus.Select(s => s.Age * 2);
            IEnumerable<Student> ages1 = stus.Where(s => s.Age > 30);
            IEnumerable<Student> names1 = stus.Where(s => s.Name.Substring(0, 1) == "z");
            Student stu1 = stus.FirstOrDefault();
            int Maxage = stus.Max(s => s.Age);
            int maxage = stus.Select(s => s.Age).Max();

            IEnumerable<IGrouping<string, Student>> groups = stus.GroupBy(s => s.Sex);
            foreach (IGrouping<string, Student> students in groups)
            {
                Console.WriteLine($"{students.Key}");
                foreach (Student tmp in students)
                {
                    Console.WriteLine($"{tmp.Id}---{tmp.Name}---{tmp.Age}");
                }
                var names2 = students.Select(s => s.Name);
                Console.WriteLine(names2);
            }
            int groupcount = stus.GroupBy(s => s.Sex).Count();
            IEnumerable<IGrouping<string, Student>> count = stus.GroupBy(s => s.Sex);
            foreach (IGrouping<string, Student> tmp in count)
            {
                Console.WriteLine($"{tmp.Key}---{tmp.Count()}");
            }

            string email = "zhansan@qq.com";

            Console.ReadLine();
        }
    }
}