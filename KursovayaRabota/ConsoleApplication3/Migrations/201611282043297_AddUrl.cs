namespace ConsoleApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyEntity2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MyEntities", "Entity_Id", c => c.Int());
            CreateIndex("dbo.MyEntities", "Entity_Id");
            AddForeignKey("dbo.MyEntities", "Entity_Id", "dbo.MyEntity2", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyEntities", "Entity_Id", "dbo.MyEntity2");
            DropIndex("dbo.MyEntities", new[] { "Entity_Id" });
            DropColumn("dbo.MyEntities", "Entity_Id");
            DropTable("dbo.MyEntity2");
        }
    }
}
