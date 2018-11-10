using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    public class LinqTuto
    {
        public static void LinqHelloWorld()
        {
            int[] nums = { 2, 5, 25, 6, 9, 2, 4, 1, 0, -1 };
            var biggerNums = from n in nums where n > 7 select n;
            Console.WriteLine("Numbers > 7 :- ");
            foreach (var item in biggerNums)
            {
                Console.WriteLine(item);
            }
        }

        public static void LinqHelloWorldOnStudent()
        {
            Console.WriteLine("====LINQ On ENTITIES=====");

            List<Student> students = LoadStudentEntity();
            var getstudent = from stud in students
                             where stud.Grade.Equals("A+")
                             //  where stud.TotalMarks >= 450 && stud.Grade.Equals("A+")
                             select stud;

            foreach (var item in getstudent)
            {
                Console.WriteLine("Name : {0}", item.Name);
                Console.WriteLine("TotalMarks : {0}", item.TotalMarks);
            }


            var getstudent1 = from stud in students
                              where stud.TotalMarks > 300
                              orderby stud.RollNum descending                            
                             select stud;

            foreach (var item in getstudent1)
            {
                Console.WriteLine("RollNum : {0}", item.RollNum);
                Console.WriteLine("Name : {0}", item.Name);
                Console.WriteLine("TotalMarks : {0}", item.TotalMarks);
            }


            var getstudent2 = (from stud in students
                             select stud.Grade).Distinct();

            foreach (var item in getstudent2)
            {
                Console.WriteLine("Grade : {0}", item);
            }


            var getstudent3 = from stud in students
                               select new { stud.Grade, stud.RollNum };

            foreach (var item in getstudent3)
            {
                Console.Write("RollNum : {0} ,", item.RollNum);
                Console.Write("Grade : {0}", item.Grade);
                Console.WriteLine("------------------");
            }


            var getstudent4 = from stud in students
                              group stud by stud.Grade into groupbyGrade
                              select new { Grade = groupbyGrade.Key, Count = groupbyGrade.Count() };

            foreach (var item in getstudent4)
            {
                Console.Write("RollNum : {0} ,", item.Grade);
                Console.Write("Grade : {0}", item.Count);
                Console.WriteLine("------------------");
            }
        }


        public static void LinqHelloWorldOnStudentTeacher()
        {
            List<Student> students = LoadStudentEntity();
            List<Teacher> teachers = LoadTeacherEntity();

            var getCommon = from stud in students join teach in teachers
                            on stud.Section equals teach.Section
                  select new { StudentName = stud.Name, TeacherName = teach.Name, Section = stud.Section };

            foreach (var item in getCommon)
            {
                Console.Write("StudentName : {0} ,", item.StudentName);
                Console.Write("TeacherName : {0} ,", item.TeacherName);
                Console.Write("Section : {0}", item.Section);
                Console.WriteLine("------------------");
            }

        }

        public static List<Student> LoadStudentEntity()
        {
            List<Student> students = new List<Student>
            {
                new Student { RollNum=1101, Grade ="A" , Name="Daniel J", TotalMarks=400 , Section ="A"},
                 new Student { RollNum=1102, Grade ="A+" , Name="Freedy", TotalMarks=450 , Section ="A"},
                  new Student { RollNum=1103, Grade ="B" , Name="Easter", TotalMarks=350,  Section="B"}
            };

            return students;
        }


        public static List<Teacher> LoadTeacherEntity()
        {
            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher {  Name="James J", Section ="A"},
                 new Teacher { Name="Luke", Section ="C"},
                  new Teacher { Name="Mark",   Section="B"}
            };

            return teachers;
        }


    }

    public class Student
    {
        public string Name { get; set;}
        public string Grade { get; set;}
        public int TotalMarks { get; set;}
        public int RollNum { get; set;}
        public string Section { get; set; }
    }


    public class Teacher
    {
        public string Name { get; set; }
        public string Section { get; set; }
    }
}
