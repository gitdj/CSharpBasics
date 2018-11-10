using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
   public class WordPressBlog : BlogPage
    {
        public WordPressBlog(string dN) : base(dN)
        {
        }
        public override void BlogLayout()
        {
            Console.WriteLine("WordPress Blog Layout:- Customized to Support Mobile and Desktop");
        }

        public override void  DisplayArticle()
        {
            Console.WriteLine("Articles related to {0}" + blogPageName);
            for (int i = 1; i <= ht.Count; i++)
            {
                Console.WriteLine("Article :- " + ht[i].ToString());
            }
        }
    }

   public class GoogleBlog : BlogPage
    {
        public GoogleBlog(string dN) : base(dN)
        {
        }

        //public override void BlogLayout()
        //{
        //    //base.BlogLayout();
        //    Console.WriteLine("GoogleBlog Layout:- Customized to Support Mobile and Desktop");
        //}

        public  override  void DisplayArticle()
        {
            Console.WriteLine("Articles related to {0}" + blogPageName);
            for (int i = 1; i <= ht.Count; i++)
            {
                Console.WriteLine("Article :- " + ht[i].ToString());
            }
        }
    }
}
