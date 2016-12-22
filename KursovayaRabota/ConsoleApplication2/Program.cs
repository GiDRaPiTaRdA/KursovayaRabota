using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyContext context = new MyContext())
            {
                context.Posts.Add(new Post());
                context.Posts.Add(new Post());
                context.SaveChanges();
            }
        }
    }
}
