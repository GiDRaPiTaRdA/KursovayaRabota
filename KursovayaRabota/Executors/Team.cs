using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamModel;

namespace TeamModel
{
    class Team
    {
        public string Name { get; set; }

        private Lazy<List<Executor>> LazyTeam { get; set; }
        public List<Executor> Executors => LazyTeam.Value;

        public Team()
        {
            Innitialize(StaticResourse.StaticValues.defaultNameOfTeam);
        }
        public Team(string name)
        {
            Innitialize(name);
        }

        private void Innitialize(string name)
        {
            this.Name = name;
            LazyTeam = new Lazy<List<Executor>>();
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
