using KursovayaRabota.DataBase;
using KursovayaRabota.Models.PlanModel;
using KursovayaRabota.Models.TeamModel;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovayaRabota.Models
{
    [ImplementPropertyChanged]
    public class MainModel
    {
        #region Delegates
        public delegate void MethodContainer();
        public delegate bool BoolMethodContainer();
        public delegate void PropertyChanged(object sender, PropertyChangedEventArgs e);
        #endregion

        #region Events
        public event MethodContainer OnLastSelectedItemChanged= delegate { };

        public event MethodContainer OnEditingTeam=delegate{};
        public event MethodContainer OnEditingExecutor = delegate { };
        public event MethodContainer OnEditingTask = delegate { };

        public event MethodContainer OnEditingTeamFinished = delegate { };
        public event MethodContainer OnEditingExecutorFinished = delegate { };
        public event MethodContainer OnEditingTaskFinished = delegate { };

        public event BoolMethodContainer PreviewDeletingItem = delegate { return false; };
        public event PropertyChanged OnEditingItemEdited = delegate { };
        #endregion

        #region Bakground Fields
        private CanModifyWrapper<ICompanySegment> lastSelectedItem;
        private CanModifyWrapper<TaskInstance> selectedTask;
        private CanModifyWrapper<Executor> selectedExecutor;
        private CanModifyWrapper<Team> selectedTeam;
        #endregion

        #region Properties
        public CanModifyWrapper<TaskInstance> SelectedTask
        {
            get
            {
                return selectedTask ?? (selectedTask = new CanModifyWrapper<TaskInstance>());
            }
            set
            {
                selectedTask = value;
                CanModifyWrapper<ICompanySegment> segment = new CanModifyWrapper<ICompanySegment>();
                segment.Value = value.Value;
                segment.CanEdit = value.CanEdit;
                segment.CanDelete = value.CanDelete;
                LastSelectedItem = segment;
            }
        }
        public CanModifyWrapper<Executor> SelectedExecutor
        {
            get
            {
                return selectedExecutor ?? (selectedExecutor = new CanModifyWrapper<Executor>());
            }
            set
            {
                selectedExecutor = value;
                CanModifyWrapper<ICompanySegment> segment = new CanModifyWrapper<ICompanySegment>();
                segment.Value = value.Value;
                segment.CanEdit = value.CanEdit;
                segment.CanDelete = value.CanDelete;
                LastSelectedItem = segment;
            }
        }
        public CanModifyWrapper<Team> SelectedTeam
        {
            get
            {
                return selectedTeam ?? (selectedTeam = new CanModifyWrapper<Team>());
            }
            set
            {
                selectedTeam = value;
                CanModifyWrapper<ICompanySegment> segment = new CanModifyWrapper<ICompanySegment>();
                segment.Value = value.Value;
                segment.CanEdit = value.CanEdit;
                segment.CanDelete = value.CanDelete;
                LastSelectedItem = segment;
            }
        }
        public CanModifyWrapper<ICompanySegment> LastSelectedItem
        {
            get
            {
                return lastSelectedItem ?? (lastSelectedItem = new CanModifyWrapper<ICompanySegment>());
            }
            set
            {
                if (lastSelectedItem != value)
                {
                    lastSelectedItem = value;
                    OnLastSelectedItemChanged();
                }

            }
        }


        public Team EditingTeam { get; set; } = new Team();
        public Executor EditingExecutor { get; set; } = new Executor();
        public TaskInstance EditingTask { get; set; } = new TaskInstance();

        public ObservableCollection<CanModifyWrapper<TaskInstance>> Tasks { get; set; }
        public ObservableCollection<CanModifyWrapper<Executor>> Executors { get; set; }
        public ObservableCollection<CanModifyWrapper<Team>> Teams { get; set; }
        #endregion

        #region Methods
        public void AddTeam()
        {
            EditingTeam = new Team();
            OnEditingTeam();
        }
        public void AddExecutor()
        {
            EditingExecutor = new Executor() { Team = Teams.FirstOrDefault()?.Value };
            OnEditingExecutor();
        }
        public void AddTask()
        {
            EditingTask = new TaskInstance() { Executor = Executors.FirstOrDefault()?.Value };
            OnEditingTask();
        }

        public void EditItem()
        {
            if (lastSelectedItem != null)
            {
                if (lastSelectedItem.Value as Team != null)
                {
                    EditingTeam = new Team(CanModifyWraperManager.UnPackCanModifyWrapper(SelectedTeam));
                    OnEditingTeam();
                }
                else if (lastSelectedItem.Value as Executor != null)
                {
                    EditingExecutor = new Executor(CanModifyWraperManager.UnPackCanModifyWrapper(SelectedExecutor));
                    OnEditingExecutor();
                }
                else if (lastSelectedItem.Value as TaskInstance != null)
                {
                    EditingTask = new TaskInstance(CanModifyWraperManager.UnPackCanModifyWrapper(SelectedTask));
                    OnEditingTask();
                }
            }
        }
        public void DelItem()
        {
            if (lastSelectedItem != null && PreviewDeletingItem())
            {
                if (lastSelectedItem.Value as Team != null)
                    Teams.Remove(SelectedTeam);
                else if (lastSelectedItem.Value as Executor != null)
                    Executors.Remove(SelectedExecutor);
                else if (lastSelectedItem.Value as TaskInstance != null)
                    Tasks.Remove(SelectedTask);
                ReloadLinksLocal();
            }
        }

        public void SaveTeam()
        {
            if (Teams.Any(t => t.Value.Id == EditingTeam.Id))
            {
                Teams.First(t => t.Value.Id == EditingTeam.Id).Value = EditingTeam;
                Teams = new ObservableCollection<CanModifyWrapper<Team>>(Teams);
            }
            else
            {
                Teams.Add(new CanModifyWrapper<Team>() { Value = EditingTeam, CanDelete = true, CanEdit = true });

            }
            (EditingTeam as INotifyPropertyChanged).PropertyChanged -= EditingItemEdited;
            EditingTeam = new Team();
            ReloadLinksLocal();
        }
        public void SaveExecutor()
        {
            if (Executors.Any(t => t.Value.Id == EditingExecutor.Id))
            {
                Executors.First(t => t.Value.Id == EditingExecutor.Id).Value = EditingExecutor;
                Executors = new ObservableCollection<CanModifyWrapper<Executor>>(Executors);
            }
            else
            {
                Executors.Add(new CanModifyWrapper<Executor>() { Value = EditingExecutor, CanDelete = true, CanEdit = true });
            }
    (EditingExecutor as INotifyPropertyChanged).PropertyChanged -= EditingItemEdited;
            EditingExecutor = new Executor();
            ReloadLinksLocal();
        }
        public void SaveTask()
        {
            if (Tasks.Any(t => t.Value.Id == EditingTask.Id))
            {
                Tasks.First(t => t.Value.Id == EditingTask.Id).Value = EditingTask;
                Tasks = new ObservableCollection<CanModifyWrapper<TaskInstance>>(Tasks);
            }
            else
            {
                Tasks.Add(new CanModifyWrapper<TaskInstance>() { Value = EditingTask, CanDelete = true, CanEdit = true });
            }

            (EditingTask as INotifyPropertyChanged).PropertyChanged -= EditingItemEdited;
            EditingTask = new TaskInstance();
            ReloadLinksLocal();
        }
        #endregion

        #region HelpMethods
        private void EditingItemEdited(object sender, PropertyChangedEventArgs e)
        {
            OnEditingItemEdited(sender,e);
        }
        private void ReloadLinksLocal()
        {
            Executors.ToList().ForEach(executor => { executor.CanDelete = !Tasks.Any(task => task.Value.Executor == executor.Value); executor.CanEdit = executor.CanDelete; });
            Teams.ToList().ForEach(team => { team.CanDelete = !Executors.Any(executor => executor.Value.Team == team.Value); team.CanEdit = team.CanDelete; });
        }
        public void InnitByCanModifyDataObject(CanModifyDataObject canDataObject)
        {
            Teams = new ObservableCollection<CanModifyWrapper<Team>>( canDataObject.Teams);
            Executors = new ObservableCollection<CanModifyWrapper<Executor>>(canDataObject.Executors);
            Tasks = new ObservableCollection<CanModifyWrapper<TaskInstance>>(canDataObject.Tasks);
        }
        #endregion
    }
}
