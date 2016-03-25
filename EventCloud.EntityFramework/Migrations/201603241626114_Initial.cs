namespace EventCloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Creatives", "User_Id", "dbo.AbpUsers");
            DropIndex("dbo.Creatives", new[] { "User_Id" });
            DropColumn("dbo.Creatives", "UserId");
            RenameColumn(table: "dbo.Creatives", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Creatives", "UserId", c => c.Long(nullable: false));
            AlterColumn("dbo.Creatives", "UserId", c => c.Long(nullable: false));
            CreateIndex("dbo.Creatives", "UserId");
            AddForeignKey("dbo.Creatives", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Creatives", "UserId", "dbo.AbpUsers");
            DropIndex("dbo.Creatives", new[] { "UserId" });
            AlterColumn("dbo.Creatives", "UserId", c => c.Long());
            AlterColumn("dbo.Creatives", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Creatives", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Creatives", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Creatives", "User_Id");
            AddForeignKey("dbo.Creatives", "User_Id", "dbo.AbpUsers", "Id");
        }
    }
}
