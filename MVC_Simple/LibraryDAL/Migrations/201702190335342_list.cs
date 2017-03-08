namespace LibraryDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class list : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Library_Book",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        BookLanguage = c.String(nullable: false),
                        bookName = c.String(nullable: false),
                        BookType = c.String(nullable: false),
                        create_time = c.DateTime(),
                        summary = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Library_BookImgae",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        Image_Date = c.DateTime(),
                        Image_Path = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Parameters",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        chinese = c.String(nullable: false),
                        English = c.String(nullable: false),
                        parametertype = c.String(),
                    })
                .PrimaryKey(t => t.id);
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Library_UserInfo",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        LastPassWord = c.String(),
                        Lib_password = c.String(nullable: false, maxLength: 10),
                        Lib_username = c.String(nullable: false),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
        }
    }
}
