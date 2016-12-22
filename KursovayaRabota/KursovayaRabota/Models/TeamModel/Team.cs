using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovayaRabota.Models.TeamModel
{   [ImplementPropertyChanged]
    public class Team: ICompanySegment
    {
        public string Name { get; set; }

        public List<Executor> Executors { get; set; }
        public int Id { get; set; }

        public Team()
        {
            Innitialize(StaticResourse.StaticValues.defaultNameOfTeam);
        }
        public Team(string name)
        {
            Innitialize(name);
        }
        public Team(Team team)
        {
            if (team != null) {
                Name = team.Name;
                Id = team.Id;
                Executors = team.Executors;
                    }
            else
                Innitialize(StaticResourse.StaticValues.defaultNameOfTeam);
        }

        private void Innitialize(string name)
        {
            this.Name = name;
            Executors = new List<Executor>();
        }

        public void AddExecutor(Executor executor)
        {
            Executors.Add(executor);
        }
        public void DelExecutor(Executor executor)
        {
            Executors.Remove(executor);
        }
        public void DelExecutorAt(int executorId)
        {
            Executors.RemoveAt(executorId);
        }

    }
}
