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

namespace KursovayaRabota.ViewModel
{
    [ImplementPropertyChanged]
    public class MainWindowViewModel
    {
        public MainModel MainModelInstance { get; set; }

        public MainWindowViewModel()
        {
            Initialize();
        }

        #region Properties
        public bool IsEditingTeam { get; set; }
        public bool IsEditingExecutor { get; set; }
        public bool IsEditingTask { get; set; }

        public bool ShowInfo { get; set; }

        public bool Link { get; set; }

        public EPost[] Posts { get; set; } = StringHelper.EnumParser.GetEnums<EPost>();
        public ETaskImportance[] TaskImportances { get; set; } = StringHelper.EnumParser.GetEnums<ETaskImportance>();
        public ETaskState[] TaskStates { get; set; } = StringHelper.EnumParser.GetEnums<ETaskState>();
        #endregion

        #region DelegateCommand

        #region DelegateCommand backing fields

        private DelegateCommand addTeamCommand;
        private DelegateCommand addExecutorCommand;
        private DelegateCommand addTaskCommand;

        private DelegateCommand editItemCommand;
        private DelegateCommand deleteItemCommand;

        private DelegateCommand closeTeamEditMenuCommand;
        private DelegateCommand closeExecutorEditMenuCommand;
        private DelegateCommand closeTaskEditMenuCommand;

        private DelegateCommand saveTeamCommand;
        private DelegateCommand saveExecutorCommand;
        private DelegateCommand saveTaskCommand;

        private DelegateCommand<Window> exitCommand;
        private DelegateCommand uploadDataCommand;
        private DelegateCommand downloadDataCommand;
        #endregion

        #region DelegateCommand Properties
        public DelegateCommand EditItemCommand =>
            this.editItemCommand ?? (this.editItemCommand = new DelegateCommand(MainModelInstance.EditItem, CanEdit));
        public DelegateCommand DeleteItemCommand =>
            this.deleteItemCommand ?? (this.deleteItemCommand = new DelegateCommand(MainModelInstance.DelItem, CanDelete));

        public DelegateCommand AddTeamCommand =>
            this.addTeamCommand ?? (this.addTeamCommand = new DelegateCommand(MainModelInstance.AddTeam, CanAddTeam));
        public DelegateCommand AddExecutorCommand =>
            this.addExecutorCommand ?? (this.addExecutorCommand = new DelegateCommand(MainModelInstance.AddExecutor, CanAddExecutor));
        public DelegateCommand AddTaskCommand =>
            this.addTaskCommand ?? (this.addTaskCommand = new DelegateCommand(MainModelInstance.AddTask, CanAddTask));

        #region EditMenu
        public DelegateCommand SaveTeamCommand =>
           this.saveTeamCommand ?? (this.saveTeamCommand = new DelegateCommand(() => { MainModelInstance.SaveTeam(); CloseTeamEditingMenu(); },this.CanSaveTeam));
        public DelegateCommand SaveExecutorCommand =>
          this.saveExecutorCommand ?? (this.saveExecutorCommand = new DelegateCommand(() => { MainModelInstance.SaveExecutor(); CloseExecutorEditingMenu(); }, this.CanSaveExecutor));
        public DelegateCommand SaveTaskCommand =>
          this.saveTaskCommand ?? (this.saveTaskCommand = new DelegateCommand(() => { MainModelInstance.SaveTask(); CloseTaskEditingMenu(); }, this.CanSaveTask));

        public DelegateCommand CloseTeamEditMenuCommand =>
            this.closeTeamEditMenuCommand ?? (this.closeTeamEditMenuCommand = new DelegateCommand(CloseTeamEditingMenu));
        public DelegateCommand CloseExecutorEditMenuCommand =>
            this.closeExecutorEditMenuCommand ?? (this.closeExecutorEditMenuCommand = new DelegateCommand(CloseExecutorEditingMenu));
        public DelegateCommand CloseTaskEditMenuCommand =>
            this.closeTaskEditMenuCommand ?? (this.closeTaskEditMenuCommand = new DelegateCommand(CloseTaskEditingMenu));
        #endregion

        public DelegateCommand UploadDataCommand =>
            this.uploadDataCommand ?? (this.uploadDataCommand = new DelegateCommand(UploadDataToDataBase));
        public DelegateCommand DownloadDataCommand =>
            this.downloadDataCommand ?? (this.downloadDataCommand = new DelegateCommand(DownloadDataFromDataBase));

        public DelegateCommand<Window> ExitCommand =>
            this.exitCommand ?? (this.exitCommand = new DelegateCommand<Window>(Exit));

        #endregion

        #endregion

        #region complete GOVNOCOD
        private DelegateCommand<dynamic> selectedlistCommand;

        public DelegateCommand<dynamic> SelectedListCommand
             => this.selectedlistCommand ?? (this.selectedlistCommand = new DelegateCommand<dynamic>(OnSelectedList));

        private void OnSelectedList(dynamic task)
        {
            if (task!=null)
            MainModelInstance.LastSelectedItem = new CanModifyWrapper<ICompanySegment>
            {
                Value = task.Value,
                CanEdit = task.CanEdit,
                CanDelete = task.CanDelete
            };
        }
        #endregion

        #region CanExecutes
        private bool CanAddTeam() => true;
        private bool CanAddExecutor() => true;
        private bool CanAddTask() => true;

        private bool CanEdit() => MainModelInstance.LastSelectedItem.CanEdit;
        private bool CanDelete() => MainModelInstance.LastSelectedItem.CanDelete;

        private bool CanSaveTeam() => !string.IsNullOrWhiteSpace(MainModelInstance.EditingTeam.Name);
        private bool CanSaveExecutor() => !(string.IsNullOrWhiteSpace(MainModelInstance.EditingExecutor.Name) || MainModelInstance.EditingExecutor.Team == null);
        private bool CanSaveTask() => !(string.IsNullOrWhiteSpace(MainModelInstance.EditingTask.Name) || string.IsNullOrWhiteSpace(MainModelInstance.EditingTask.Purpose)|| MainModelInstance.EditingTask.Executor==null);

        #endregion

        #region HelpMethods
        private void OpenTeamEditingMenu()
        {
            IsEditingTeam = true;
            IsEditingExecutor = false;
            IsEditingTask = false;

            (MainModelInstance.EditingTeam as INotifyPropertyChanged).PropertyChanged -= EditingItemEdited;
            (MainModelInstance.EditingTeam as INotifyPropertyChanged).PropertyChanged += EditingItemEdited;

            SaveTeamCommand.RaiseCanExecuteChanged();
        }
        private void OpenExecutorEditingMenu()
        {
            IsEditingTeam = false;
            IsEditingExecutor = true;
            IsEditingTask = false;

            (MainModelInstance.EditingExecutor as INotifyPropertyChanged).PropertyChanged -= EditingItemEdited;
            (MainModelInstance.EditingExecutor as INotifyPropertyChanged).PropertyChanged += EditingItemEdited;

            SaveExecutorCommand.RaiseCanExecuteChanged();
        }
        private void OpenTaskEditingMenu()
        {
            IsEditingTeam = false;
            IsEditingExecutor = false;
            IsEditingTask = true;

            (MainModelInstance.EditingTask as INotifyPropertyChanged).PropertyChanged -= EditingItemEdited;
            (MainModelInstance.EditingTask as INotifyPropertyChanged).PropertyChanged += EditingItemEdited;

            SaveTaskCommand.RaiseCanExecuteChanged();
        }

        private void CloseTeamEditingMenu()
        {
            IsEditingTeam = false;
            (MainModelInstance.EditingTeam as INotifyPropertyChanged).PropertyChanged -= EditingItemEdited;
        }
        private void CloseExecutorEditingMenu()
        {
            IsEditingExecutor = false;
            (MainModelInstance.EditingExecutor as INotifyPropertyChanged).PropertyChanged -= EditingItemEdited;
        }
        private void CloseTaskEditingMenu()
        {
            IsEditingTask = false;
            (MainModelInstance.EditingTask as INotifyPropertyChanged).PropertyChanged -= EditingItemEdited;
        }

        private void Exit(Window window)
        {
            MessageBoxResult result = MessageBox.Show("Do you realy want to leave the app?",
                "Leaving the application", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                window.Close();
        }
        private bool AskDelete()
        {
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to remove selected item?",
                "Removal",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }

        private void LastSelectedItemChanged()
        { 
            AddTeamCommand.RaiseCanExecuteChanged();
            AddExecutorCommand.RaiseCanExecuteChanged();
            AddTaskCommand.RaiseCanExecuteChanged();

            EditItemCommand.RaiseCanExecuteChanged();
            DeleteItemCommand.RaiseCanExecuteChanged();
        }
        private void EditingItemEdited(object sender, PropertyChangedEventArgs e)
        {
            SaveTeamCommand.RaiseCanExecuteChanged();
            SaveExecutorCommand.RaiseCanExecuteChanged();
            SaveTaskCommand.RaiseCanExecuteChanged();
        }
        #endregion

        #region Loading
        private void UploadDataToDataBase()
        {
            new DataBaseManager().UploadData(new CanModifyDataObject(MainModelInstance.Teams, MainModelInstance.Executors, MainModelInstance.Tasks));
            MessageBox.Show("Data has been uploaded successfuly to the database", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DownloadDataFromDataBase()
        {
            MainModelInstance.InnitByCanModifyDataObject(new DataBaseManager().LoadFromDataBase());
            MessageBox.Show("Data has been downloaded successfuly from the database","Success",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void Subscribe()
        {
            MainModelInstance.OnEditingTeam += OpenTeamEditingMenu;
            MainModelInstance.OnEditingExecutor +=OpenExecutorEditingMenu;
            MainModelInstance.OnEditingTask += OpenTaskEditingMenu;

            MainModelInstance.OnEditingTeamFinished += CloseTeamEditingMenu;
            MainModelInstance.OnEditingExecutorFinished += CloseExecutorEditingMenu;
            MainModelInstance.OnEditingTaskFinished += CloseTaskEditingMenu;

            MainModelInstance.OnEditingItemEdited+=EditingItemEdited;
            MainModelInstance.OnLastSelectedItemChanged+= LastSelectedItemChanged;

            MainModelInstance.PreviewDeletingItem += AskDelete;
        }

        private void Initialize()
        {
            MainModelInstance = new MainModel();

            Subscribe();

            DownloadDataFromDataBase();

            MainModelInstance.LastSelectedItem = new CanModifyWrapper<ICompanySegment>();
        }

        #endregion
    }
}
