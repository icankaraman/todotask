namespace todolist.EntityModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ToDoDbContext : DbContext
    {
        public ToDoDbContext()
            : base("name=ToDoDbContext")
        {
        }

        public virtual DbSet<ToDoList> ToDoLists { get; set; }
        public virtual DbSet<ToDoTask> ToDoTasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoList>()
                .HasMany(e => e.ToDoTasks)
                .WithRequired(e => e.ToDoList)
                .HasForeignKey(e => e.ListId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ToDoTasks)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
