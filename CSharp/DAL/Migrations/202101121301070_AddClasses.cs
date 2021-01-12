namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Educator_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.Educator_Id, cascadeDelete: true)
                .Index(t => t.Educator_Id);
            
            AddColumn("dbo.Students", "Class_Id", c => c.Int());
            CreateIndex("dbo.Students", "Class_Id");
            AddForeignKey("dbo.Students", "Class_Id", "dbo.Classes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.Classes", "Educator_Id", "dbo.Teachers");
            DropIndex("dbo.Classes", new[] { "Educator_Id" });
            DropIndex("dbo.Students", new[] { "Class_Id" });
            DropColumn("dbo.Students", "Class_Id");
            DropTable("dbo.Classes");
        }
    }
}
