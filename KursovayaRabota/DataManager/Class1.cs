using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KursovayaRabota.Models.TeamModel;

namespace DataManager
{
    class Class1
    {
        static void doThmthing()
        {
            using (DataContext dc = new DataContext())
            {
                dc.Executors.Add(new Executor("Pedro"));
                dc.Executors.Add(new Executor("Pushkin"));
                dc.Executors.Add(new Executor("Oleg"));
                dc.SaveChanges();
            }
        }
    }
}
