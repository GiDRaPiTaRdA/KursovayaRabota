using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StaticResourse;
using StringHelper.Exceptions;

namespace TeamModel
{
    public class Executor
    {
        public string Name { get; private set; }
        public EPost Post { get; set; }

        private Lazy<List<Task>> LazyTasks { get; set; }
        public List<Task> Tasks => LazyTasks.Value;

        public Executor()
        {
            Innitialize(StaticValues.defaultNameOfExecutor,(EPost)StaticValues.defaultPostValue);
        }
        public Executor(string name)
        {
            Innitialize(name, (EPost)StaticValues.defaultPostValue);
        }
        public Executor(EPost post)
        {
            Innitialize(StaticValues.defaultNameOfExecutor, post);
        }
        public Executor(string name,EPost post)
        {
            Innitialize(name, post);
        }

        private void Innitialize(string name, EPost post)
        {
            InnitName(name);
            this.Post = post;
            LazyTasks = new Lazy<List<Executor>>();
        }
        public void InnitName(string name)
        {
            if (name != string.Empty && char.IsLetter(name[0])&& char.IsUpper(name[0]))
                this.Name = name;
            else
                throw new BadNameFormatException();
        }

        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }
        public void DelTask(Task task)
        {
            Tasks.Remove(task);
        }
        public void DelTaskAt(int taskId)
        {
            Tasks.RemoveAt(taskId);
        }

    }
}
