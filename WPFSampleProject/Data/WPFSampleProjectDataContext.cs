namespace WPFSampleProject.Data
{
    using System.Data.Entity;
    using WPFSampleProject.Model;

    public class WPFSampleProjectDataContext : DbContext
    {
        /// <summary>
        /// check if the data base is already created or not yet to create a new database or skip, 
        /// WPFSampleProjectConnectionString is the name of connection string stored on web.config file
        /// </summary>
        public WPFSampleProjectDataContext() : base("name = WPFSampleProjectConnectionString")
        {
            if (!Database.Exists())
                Database.SetInitializer<WPFSampleProjectDataContext>(new WPFSampleProjectInitializer());
        }

        /// <summary>
        /// this method used for automatically deletes dependent records or sets null 
        /// to ForeignKey columns when the parent record is deleted in the database.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
           .HasMany(a => a.Addresses)
           .WithOptional()
           .WillCascadeOnDelete(true);
        }

        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
    }
}