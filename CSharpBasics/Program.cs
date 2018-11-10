using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    class Program
    {
        public delegate int CalDelegate(int num1, int num2);
        static void Main(string[] args)
        {
            Console.WriteLine("Helo World...");
            //Console.ReadLine();

            //Environment.Exit(0);

            #region ClassMember
            UtilityHelper objHelper = new UtilityHelper();

            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(-1);

            objHelper.numbers = numbers;
            objHelper.PrintNumbers();

            //Console.WriteLine(objHelper.numbers);
            //objHelper.status = "Setter";

            Console.WriteLine("Status :-" + objHelper.status);

            UtilityHelper objHelper1 = new UtilityHelper("Initilaizer");
            //Console.ReadLine();
            #endregion ClassMember


            #region OOPS
            Console.WriteLine("-----OOPS-----");
            Console.WriteLine("--Word Press--");

            BlogPage objBlogPage = new GoogleBlog("Google");

            objBlogPage.isActive = "YES";
            objBlogPage.blogPageAuthor = "DJ";
            objBlogPage.blogPageName = "C# .Net Articles";

            objBlogPage.AddArticles("Basics of C#");
            objBlogPage.AddArticles("Basics of C# OOPS");

            objBlogPage.DisplayArticle();
            Console.WriteLine("------------");
            objBlogPage.BlogInfo();
            Console.ReadLine();

            #endregion
            
            #region DesignPattern
            Console.WriteLine("-----OOPS-----");
            Console.WriteLine("--Word Press--");

            int blogType = 2;
            BlogPage dynamicobjBlogPage;
            if (blogType==1)
            {
                dynamicobjBlogPage = new WordPressBlog("WordPress");
            }
            else
            {
                dynamicobjBlogPage = new GoogleBlog("WordPress");
            }


               

            dynamicobjBlogPage.isActive = "YES";
            dynamicobjBlogPage.blogPageAuthor = "DJ";
            dynamicobjBlogPage.blogPageName = "C# .Net Articles";

            dynamicobjBlogPage.AddArticles("Basics of C# DesignPattern");
           
            dynamicobjBlogPage.DisplayArticle();
            Console.WriteLine("------------");
            dynamicobjBlogPage.BlogInfo();
            Console.ReadLine();

            #endregion


            #region DelegateDemo

            CalOperations objCal = new CalOperations();
            CalDelegate objDelegate = new CalDelegate(objCal.Add);
            objDelegate += new CalDelegate(objCal.Sub);

            int result = objDelegate(1, 2);
            Console.WriteLine("Result Set :- "+ result.ToString());

            #endregion

            #region DAL
            DALHelper objDAL = new DALHelper();

            ClientProductModel product = new ClientProductModel();
            product.Name = "IPhone";
            product.Qty = "25";
            product.Rate = "25.00";
           // objDAL.Insert(product);
            product.Name = "Nokia";
            product.Qty = "100";
            product.Rate = "12.00";
          //  objDAL.Insert(product);
            product = null;

            product = objDAL.SelectQuery(1);

            product = objDAL.SPExecute(1);
            #endregion


            #region LINQ

            LinqTuto.LinqHelloWorld();

            LinqTuto.LinqHelloWorldOnStudent();

            LinqTuto.LinqHelloWorldOnStudentTeacher();

            #endregion
        }


        public static void Add(int num1, int num2)
        {
            Console.WriteLine("Add Num:- ", num1+num2);
        }

        public static int Add(params int[] num)
        {
            int sum = 0;
            for (int i = 0; i < num.Length; i++)
            {
                sum+= num[0];
            }
            return sum;
        }

    }
}
