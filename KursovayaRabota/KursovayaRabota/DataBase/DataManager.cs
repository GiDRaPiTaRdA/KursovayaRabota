using KursovayaRabota.Models.PlanModel;
using KursovayaRabota.Models.TeamModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovayaRabota.DataBase
{
    class DataManager
    {
        public DataContext ContextInstance { get; set; }

        public DataManager()
        {
            this.ContextInstance = new DataContext();
        }
        public DataManager(DataContext context)
        {
            this.ContextInstance = context;
        }

        public void AddExecutor(Executor executor)
        {
            ContextInstance.Executors.Add(executor);
        }
        public void EditExecutor(Executor executor)
        {
            Executor ex = ContextInstance.Executors.First(e => e.Id == executor.Id);
            if (ex != null)
            {
                ex.Name = executor.Name;
                ex.Post = executor.Post;
                ex.Tasks = executor.Tasks;
                ex.Team = executor.Team;
                ex.Id = executor.Id;
            }
            
        }
        public void DelExecutor(Executor executor)
        {
            ContextInstance.Executors.Remove(executor);
        }
        public List<Executor> GetExecutors()
        {
            return new List<Executor>(ContextInstance.Executors);
        }
        public List<Executor> GetExecutorsOfTeam(Team team)
        {
            return ContextInstance.Executors.Where(t => t.Team == team).ToList();
        }
        public List<Executor> GetExecutorsOfTask(TaskInstance task)
        {
            return ContextInstance.Executors.Where(t => t.Tasks.Any(ts => ts == task)).ToList();
        }

        public void AddTask(TaskInstance task)
        {
            ContextInstance.Tasks.Add(task);
        }
        public void EditTask(TaskInstance task) {
            TaskInstance ti = ContextInstance.Tasks.First(t=>t.Id==task.Id);
            if (ti != null)
            {
                ti.Name = task.Name;
                ti.Purpose = task.Purpose;
                ti.State = task.State;
                ti.Importance = task.Importance;
                ti.Executor = task.Executor;
                ti.Id = task.Id;
            }
        }
        public void DelTask(TaskInstance task)
        {
            ContextInstance.Tasks.Remove(task);
        }
        public List<TaskInstance> GetTasks()
        {
            List<TaskInstance> list = new List<TaskInstance>();
            ContextInstance.Tasks.ToList().ForEach(task => list.Add(task));
            return list;

        }
        public List<TaskInstance> GetTasksOfExecutor(Executor executor)
        {
            return executor.Tasks;
        }
        public List<TaskInstance> GetTasksOfTeam(Team team)
        {
            List<TaskInstance> listOfTasks = new List<TaskInstance>();
            team.Executors.ForEach(t => t.Tasks.Union(listOfTasks));
            return listOfTasks;
        }

        public void AddTeam(Team team)
        {
            ContextInstance.Teams.Add(team);
        }
        public void EditTeam(Team team)
        {
            Team te = ContextInstance.Teams.First(t => t.Id == team.Id);
            if (te != null)
            {
                te.Name = team.Name;
                te.Id = team.Id;
            }
        }
        public void DelTeam(Team team)
        {
            ContextInstance.Teams.Remove(team);
        }
        public List<Team> GetTeams()
        {
            List<Team> list = new List<Team>();
            ContextInstance.Teams.ToList().ForEach(team => list.Add(team));
            return list;
        }

        public void SyncTeams(List<Team> teams)
        {
            GetTeams().ForEach(item => DelTeam(item));
            teams.ForEach(item => AddTeam(item));
        }
        public void SyncExecutors(List<Executor> executors)
        {
            GetExecutors().ForEach(item => DelExecutor(item));
            executors.ForEach(item => AddExecutor(item));
        }
        public void SyncTasks(List<TaskInstance> tasks)
        {
            GetTasks().ForEach(item => DelTask(item));
            tasks.ForEach(item => AddTask(item));
        }

        public void ApplyChanges()
        {
            ContextInstance.SaveChanges();
        }
    }
}
