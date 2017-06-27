using LibraryModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL
{
    public class EFConcrete : DbContext
    {
        public EFConcrete()
            : base("LibraryConn")
        {
        }

        public DbSet<Library_Book> Book { get; set; }
        public DbSet<Library_BookImgae> Library_BookImgae { get; set; }
        public DbSet<Parameter> Parameter { get; set; }
        public DbSet<UserModel> User { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("Library_UserInfo");
            modelBuilder.Entity<Parameter>().ToTable("parameter");
            
        }
    }
}