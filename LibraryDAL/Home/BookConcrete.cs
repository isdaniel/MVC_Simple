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
            : base("LibraryDAL")
        {
        }

        public DbSet<Library_Book> Book { get; set; }
        public DbSet<Library_BookImgae> Library_BookImgae { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Library_Book>().HasKey(k => k.id) //设置主键
              .Property(q => q.summary).IsRequired();//设置不能为空
            modelBuilder.Entity<Library_BookImgae>().HasKey(k => k.Id)
                .Property(q => q.BookId).IsRequired();//設置主鍵
        }
    }
}