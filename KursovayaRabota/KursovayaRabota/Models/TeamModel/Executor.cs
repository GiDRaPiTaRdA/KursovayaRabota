using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StaticResourse;
using StringHelper.Exceptions;
using KursovayaRabota.Models.PlanModel;
using PropertyChanged;

namespace KursovayaRabota.Models.TeamModel

{   [ImplementPropertyChanged]
    public class Executor: ICompanySegment
    {
        public string Name { get; set; }
        public EPost Post { get; set; }
        public Team Team { get; set; }

        public int Id { get; set; }
        public List<TaskInstance> Tasks { get; set; }

        public Executor()
        {
            Innitialize(StaticValues.defaultNameOfExecutor,(EPost)StaticValues.defaultPostValue);
        }
        public Executor(string name)
        {
            Innitialize(name, (EPost)StaticValues.defaultPostValue);
        }
        public Executor(Executor executor)
        {
            if (executor != null)
            {
                Name = executor.Name;
                Post = executor.Post;
                Team = executor.Team;
                Tasks = executor.Tasks;
                Id = executor.Id;
            }
            else
                Innitialize(StaticValues.defaultNameOfExecutor, (EPost)StaticValues.defaultPostValue);
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
            Tasks = new List<TaskInstance>();
        }
        public void InnitName(string name)
        {
            if (name != string.Empty && char.IsLetter(name[0])&& char.IsUpper(name[0]))
                this.Name = name;
            else
                throw new BadNameFormatException();
        }

        public void AddTask(TaskInstance task)
        {
            Tasks.Add(task);
        }
        public void DelTask(TaskInstance task)
        {
            Tasks.Remove(task);
        }

    }
}
