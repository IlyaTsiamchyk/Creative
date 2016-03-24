namespace EventCloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Creatives", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Creatives", "User_Id", c => c.Long());
            CreateIndex("dbo.Creatives", "User_Id");
            AddForeignKey("dbo.Creatives", "User_Id", "dbo.AbpUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Creatives", "User_Id", "dbo.AbpUsers");
            DropIndex("dbo.Creatives", new[] { "User_Id" });
            DropColumn("dbo.Creatives", "User_Id");
            DropColumn("dbo.Creatives", "UserId");
        }
    }
}
