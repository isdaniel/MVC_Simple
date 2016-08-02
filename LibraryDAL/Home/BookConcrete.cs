using LibraryModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Home
{
    public class BookConcrete : DbContext
    {
        public BookConcrete()
            : base("LibraryConn")
        {
        }

        public DbSet<Library_Book> Book { get; set; }
        public DbSet<Library_BookImgae> Library_BookImgae { get; set; }
        public DbSet<Parameter> Parameter { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Library_Book>().HasKey(k => k.id) //設置主鍵
              .Property(q => q.summary).IsRequired();//不能為空

            modelBuilder.Entity<Library_BookImgae>().HasKey(k => k.Id)
                .Property(q => q.BookId).IsRequired();//設置主鍵
            modelBuilder.Entity<Parameter>().HasKey(k => k.id)//設置主鍵
                .Property(q => q.English).IsRequired();//不能為空
            modelBuilder.Entity<Parameter>()
                .Property(q => q.chinese).IsRequired();//不能為空
        }
    }
}