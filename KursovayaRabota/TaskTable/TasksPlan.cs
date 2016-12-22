using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanModel
{
    class TasksPlan
    {
        public string Name { get; set; }

        private Lazy<List<TaskInstance>> LazyPlan { get; set; }
        public List<TaskInstance> Tasks => LazyPlan.Value;

        public TasksPlan()
        {
            Innitialize(StaticResourse.StaticValues.defaultNameOfPlan);
        }
        public TasksPlan(string name)
        {
            Innitialize(name);
        }

        private void Innitialize(string name)
        {
            this.Name = name;
            LazyPlan = new Lazy<List<TaskInstance>>();
        }

        public void AddTask(TaskInstance task)
        {
            Tasks.Add(task);
        }
        public void DelTask(TaskInstance task)
        {
            Tasks.Remove(task);
        }
        public void DelTaskAt(int taskId)
        {
            Tasks.RemoveAt(taskId);
        }
    }
}
