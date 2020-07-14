namespace TaskRobo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppUser",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryTitle = c.String(),
                        UserId = c.String(),
                        User_Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.AppUser", t => t.User_Email)
                .Index(t => t.User_Email);
            
            CreateTable(
                "dbo.UserTask",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        TaskTitle = c.String(),
                        TaskContent = c.String(),
                        TaskStatus = c.String(),
                        UserId = c.String(),
                        CategoryId = c.Int(nullable: false),
                        User_Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AppUser", t => t.User_Email)
                .Index(t => t.CategoryId)
                .Index(t => t.User_Email);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTask", "User_Email", "dbo.AppUser");
            DropForeignKey("dbo.UserTask", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Category", "User_Email", "dbo.AppUser");
            DropIndex("dbo.UserTask", new[] { "User_Email" });
            DropIndex("dbo.UserTask", new[] { "CategoryId" });
            DropIndex("dbo.Category", new[] { "User_Email" });
            DropTable("dbo.UserTask");
            DropTable("dbo.Category");
            DropTable("dbo.AppUser");
        }
    }
}
