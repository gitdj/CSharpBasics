using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    public abstract class BlogPage
    {
        public string blogPageName { get; set; }
        public string blogPageAuthor { get; set; }
        public string isActive { get; set; }
        
        //private Hashtable ht = new Hashtable();

        protected Hashtable ht = new Hashtable();
        private string domainName =string.Empty;
        public BlogPage(string domainName)
        {
            this.domainName = domainName;
        }

        public virtual void BlogLayout()
        {
            Console.WriteLine("Blog Layout:- Default Layout");
        }

        public abstract void DisplayArticle();
        //public void DisplayArticle()
        //{
        //    Console.WriteLine("Articles related to {0}"+ blogPageName);
        //    for (int i = 1; i <= ht.Count; i++)
        //    {
        //        Console.WriteLine("Article :- "+ ht[i].ToString());
        //    }
        //}

        public void AddArticles(string content)
        {
            ht.Add((ht.Count) + 1, content);
        }

        internal void BlogInfo()
        {
            BlogLayout();
            Console.WriteLine("{1} has {0} Articles,", ht.Count, blogPageName);
            Console.WriteLine("Blog is registered in {0} Domain,", domainName);

        }
    }
}
