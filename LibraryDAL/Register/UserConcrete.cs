using LibraryModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Register
{
    public class UserConcrete : DbContext
    {
        public UserConcrete()
            : base("BookLibrary")
        {
        }

        public DbSet<UserModel> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Changing Database table name to EmployeeData
            modelBuilder.Entity<UserModel>()
                .ToTable("Library_UserInfo");
        }
    }
}