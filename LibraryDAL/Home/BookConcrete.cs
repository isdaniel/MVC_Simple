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
            : base("BookLibrary")
        {
        }

        public DbSet<Library_Book> Book { get; set; }
        public DbSet<Library_BookImgae> Library_BookImgae { get; set; }
        public DbSet<Parameter> Parameter { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}