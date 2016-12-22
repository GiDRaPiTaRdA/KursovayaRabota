using KursovayaRabota.Models;
using KursovayaRabota.Models.PlanModel;
using KursovayaRabota.Models.TeamModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovayaRabota.DataBase
{
    public class CanModifyDataObject
    {
        public CanModifyDataObject()
        {
            Initialize(new ObservableCollection<CanModifyWrapper<Team>>(), 
                new ObservableCollection<CanModifyWrapper<Executor>>(),
                new ObservableCollection<CanModifyWrapper<TaskInstance>>());
        }
        public CanModifyDataObject(
            ObservableCollection<CanModifyWrapper<Team>> teams,
            ObservableCollection<CanModifyWrapper<Executor>> executors,
            ObservableCollection<CanModifyWrapper<TaskInstance>> tasks)
        {
            Initialize(teams, executors, tasks);
        }

        public ObservableCollection<CanModifyWrapper<Team>> Teams { get; set; }
        public ObservableCollection<CanModifyWrapper<Executor>> Executors { get; set; }
        public ObservableCollection<CanModifyWrapper<TaskInstance>> Tasks { get; set; }

        private void Initialize(
            ObservableCollection<CanModifyWrapper<Team>> teams,
            ObservableCollection<CanModifyWrapper<Executor>> executors,
            ObservableCollection<CanModifyWrapper<TaskInstance>> tasks)
        {
            this.Teams = teams;
            this.Executors = executors;
            this.Tasks = tasks;
        }
    }
}
