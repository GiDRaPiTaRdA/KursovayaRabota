using StaticResourse;
using StringHelper;
using StringHelper.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanModel;

namespace PlanModel
{
    public class TaskInstance
    {
        public string Name { get; set;}
        public string Purpose { get; set; }
        public ETaskState State { get; set; }
        public ETaskImportance Importance { get; set; }
        public int Id { get; set; }

        public TaskInstance()
        {
            Innitialize
                (
                    StaticValues.defaultNameOfTask,
                    StaticValues.defaultPurposeOfTask,
                    (ETaskState)StaticValues.defaultTaskState,
                    (ETaskImportance)StaticValues.defaultTaskImportance
                );
        }
        public TaskInstance(string name, string purpose)
        {
            Innitialize
                (
                    name,
                    purpose,
                    (ETaskState)StaticValues.defaultTaskState,
                    (ETaskImportance)StaticValues.defaultTaskImportance
                );
        }
        public TaskInstance(string name, string purpose,ETaskState state,ETaskImportance importance)
        {
            Innitialize(name, purpose, state,importance);
        }

        public void InnitName(string name)
        {
            if (Checker.MatchesNameFormat(name))
                this.Name = name;
            else
                throw new BadNameFormatException();
        }
        private void Innitialize(string name, string purpose,ETaskState state, ETaskImportance importance)
        {
            InnitName(name);

            this.Purpose = purpose;
            this.Importance = importance;
            this.State = state;
        }
    }
}
