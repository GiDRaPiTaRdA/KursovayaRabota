using KursovayaRabota.Models.PlanModel;
using KursovayaRabota.Models.TeamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovayaRabota.DataBase
{
    class DataObject
    {
        public DataObject(){
            Initialize(new List<Team>(), new List<Executor>(), new List<TaskInstance>());
        }
        public DataObject(List<Team>  teams, List<Executor> executors, List<TaskInstance> tasks)
        {
            Initialize(teams, executors, tasks);
        }

        public List<Team> Teams { get; set; }
        public List<Executor> Executors { get; set; }
        public List<TaskInstance> Tasks { get; set; }

        private void Initialize(List<Team> teams, List<Executor> executors, List<TaskInstance> tasks)
        {
            this.Teams = teams;
            this.Executors = executors;
            this.Tasks = tasks;
        }
    }
}
