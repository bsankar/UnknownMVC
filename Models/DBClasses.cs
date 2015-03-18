using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.SqlServerCe;
using System.Data.Entity;


namespace UnknownMVC.Models
{
    public class Task
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskID { get; set; }
        public String TaskDescription { get; set; }
        public DateTime TaskCreated { get; set; }
        public User TaskUser { get; set; }
    }

    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public String UserName { get; set; }
    }

    public class TasksDB:DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}