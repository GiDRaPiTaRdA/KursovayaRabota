namespace KursovayaRabota.DataBase
{
    using Models.PlanModel;
    using Models.TeamModel;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataContext : DbContext
    {
        public DbSet<TaskInstance> Tasks { get; set; }
        public DbSet<Executor> Executors { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}