extern alias EF;
using MeetingSign.Model.Entity;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using EF::System.Data.Entity;

namespace MeetingSign.Model
{
    public class MeetingSignModel : DbContext
    {
        public DbSet<Entity.Meeting> Meetings { get { return Set<Meeting>(); } }
        public DbSet<Entity.Department> Departments { get { return Set<Department>(); } }
        public DbSet<Entity.MeetingRoom> MeetingRooms { get { return Set<MeetingRoom>(); } }
        public DbSet<Entity.Person> People { get { return Set<Person>(); } }
        public DbSet<Entity.Sign> Signs { get { return Set<Sign>(); } }
        public DbSet<Entity.User> Users { get { return Set<User>(); } }

        public void AddPerson(int id)
        {
            People.Add(new Person() { id = id });
        }

        public MeetingSignModel() : base("dbConnect")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ModelConfiguration.Configure(modelBuilder);
            var init = new SqliteCreateDatabaseIfNotExists<MeetingSignModel>(modelBuilder);
            Database.SetInitializer(init);
        }



    }

    public class ModelConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            ConfigureStudentEntity(modelBuilder);
        }
        private static void ConfigureStudentEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meeting>();
            modelBuilder.Entity<MeetingRoom>();
            modelBuilder.Entity<Department>();
            modelBuilder.Entity<Person>();
            modelBuilder.Entity<Sign>();
            modelBuilder.Entity<User>();
        }
    }
}
