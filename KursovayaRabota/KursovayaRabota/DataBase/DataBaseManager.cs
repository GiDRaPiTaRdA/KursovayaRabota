using KursovayaRabota.DataBase;
using KursovayaRabota.Models;
using KursovayaRabota.Models.PlanModel;
using KursovayaRabota.Models.TeamModel;
using Prism.Commands;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.Specialized;


namespace KursovayaRabota.DataBase
{
    class DataBaseManager
    {
        DataManager manager;

        public DataBaseManager()
        {
            manager = new DataManager();
        }

        public CanModifyDataObject DownloadData()
        {
            DataManager manager = new DataManager();

            CanModifyDataObject canDataObject = new CanModifyDataObject()
            {
                Tasks = LoadTasksFromDataBase(manager),
                Executors = LoadExecutorsFromDataBase(manager),
                Teams = LoadTeamsFromDataBase(manager)
            };
            return canDataObject;
        }
        public bool UploadData(CanModifyDataObject canDataObject)
        {
            bool success = true;
            try
            {
                DataManager dataManager = new DataManager();

                //dataManager.GetTeams().ForEach(item => dataManager.DelTeam(item));
                //dataManager.GetExecutors().ForEach(item => dataManager.DelExecutor(item));
                //dataManager.GetTasks().ForEach(item => dataManager.DelTask(item));

                //dataManager.ApplyChanges();

                //CanModifyWraperManager.UnPackCanModifyWrapper(canDataObject.Teams).ForEach(item => dataManager.AddTeam(item));
                //CanModifyWraperManager.UnPackCanModifyWrapper(canDataObject.Executors).ForEach(item => dataManager.AddExecutor(item));
                //CanModifyWraperManager.UnPackCanModifyWrapper(canDataObject.Tasks).ForEach(item => dataManager.AddTask(item));

                dataManager.SyncTasks(CanModifyWraperManager.UnPackCanModifyWrapper(canDataObject.Tasks));
                dataManager.SyncExecutors(CanModifyWraperManager.UnPackCanModifyWrapper(canDataObject.Executors));
                dataManager.SyncTeams(CanModifyWraperManager.UnPackCanModifyWrapper(canDataObject.Teams));

                dataManager.ApplyChanges();

            }
            catch (Exception) { success = false; }
            return success;
        }
        public bool UploadData(DataObject dataObject)
        {
            bool success = true;
            try
            {
                DataManager dataManager = new DataManager();

                dataManager.SyncTasks(dataObject.Tasks);
                dataManager.SyncExecutors(dataObject.Executors);
                dataManager.SyncTeams(dataObject.Teams);

                dataManager.ApplyChanges();

            }
            catch (Exception e) { success = false; }
            return success;
        }


        private ObservableCollection<CanModifyWrapper<TaskInstance>> LoadTasksFromDataBase(DataManager manager)
        {
            ObservableCollection<CanModifyWrapper<TaskInstance>> tasks = new ObservableCollection<CanModifyWrapper<TaskInstance>>();
            manager.GetTasks().ToList().ForEach(t => tasks.Add(new CanModifyWrapper<TaskInstance>
            {
                Value = t,
                CanDelete = true,
                CanEdit = true
            }));
            return tasks;
        }
        private ObservableCollection<CanModifyWrapper<Executor>> LoadExecutorsFromDataBase(DataManager manager)
        {
            ObservableCollection<CanModifyWrapper<Executor>> executors = new ObservableCollection<CanModifyWrapper<Executor>>();
            manager.GetExecutors().ToList().ForEach(t => executors.Add(new CanModifyWrapper<Executor>
            {
                Value = t,
                CanDelete = !t.Tasks.Any(),
                CanEdit = !t.Tasks.Any()
            }));
            return executors;
        }
        private ObservableCollection<CanModifyWrapper<Team>> LoadTeamsFromDataBase(DataManager manager)
        {
            ObservableCollection<CanModifyWrapper<Team>> teams = new ObservableCollection<CanModifyWrapper<Team>>();
            manager.GetTeams().ToList().ForEach(t => teams.Add(new CanModifyWrapper<Team>
            {
                Value = t,
                CanDelete = !t.Executors.Any(),
                CanEdit = !t.Executors.Any(),
            }));
            return teams;
        }
    }
}
