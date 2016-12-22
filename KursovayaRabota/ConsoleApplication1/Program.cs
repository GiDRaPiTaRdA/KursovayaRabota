using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DataBaseContext db =  new DataBaseContext())
            {
                //db.MyEntities.Add(new MyEntity() {Name = "Hello" });
                //db.SaveChanges();

                var a = db.MyEntities;

                Console.WriteLine(a.ElementAt(0).Name);
                Console.WriteLine(a.ElementAt(1).Name);
            }
        }
    }
}
