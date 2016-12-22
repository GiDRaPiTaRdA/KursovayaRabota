using StaticResourse;
using StringHelper;
using StringHelper.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KursovayaRabota.Models.TeamModel;
using System.ComponentModel;
using PropertyChanged;

namespace KursovayaRabota.Models.PlanModel
{
    [ImplementPropertyChanged]
    public class TaskInstance: ICompanySegment
    {
        
        public string Name { get; set;}
        public string Purpose { get; set; }
        public ETaskState State { get; set; }
        public ETaskImportance Importance { get; set; }

        public int Id { get; set; }
        public Executor Executor { get; set; }

        public TaskInstance()
        {
            Initialize
                (
                    StaticValues.defaultNameOfTask,
                    StaticValues.defaultPurposeOfTask,
                    (ETaskState)StaticValues.defaultTaskState,
                    (ETaskImportance)StaticValues.defaultTaskImportance
                );
        }
        public TaskInstance(TaskInstance task)
        {
            if (task != null)
            {
                Name = task.Name;
                Purpose = task.Purpose;
                State = task.State;
                Importance = task.Importance;
                Executor = task.Executor;
                Id = task.Id;
            }
            else
                Initialize
                    (
                        StaticValues.defaultNameOfTask,
                        StaticValues.defaultPurposeOfTask,
                        (ETaskState)StaticValues.defaultTaskState,
                        (ETaskImportance)StaticValues.defaultTaskImportance
                    );
        }
        public TaskInstance(string name, string purpose)
        {
            Initialize
                (
                    name,
                    purpose,
                    (ETaskState)StaticValues.defaultTaskState,
                    (ETaskImportance)StaticValues.defaultTaskImportance
                );
        }
        public TaskInstance(string name, string purpose,ETaskState state,ETaskImportance importance)
        {
            Initialize(name, purpose, state,importance);
        }

        public void InnitName(string name)
        {
            if (Checker.MatchesNameFormat(name))
                this.Name = name;
            else
                throw new BadNameFormatException();
        }


        private void Initialize(string name, string purpose,ETaskState state, ETaskImportance importance)
        {
            InnitName(name);

            this.Purpose = purpose;
            this.Importance = importance;
            this.State = state;
        }
    }
}
