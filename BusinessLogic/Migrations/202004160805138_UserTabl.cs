namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTabl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsersDbTables", "Role", c => c.Int(nullable: false));
            AddColumn("dbo.UsersDbTables", "Level", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UsersDbTables", "Level");
            DropColumn("dbo.UsersDbTables", "Role");
        }
    }
}
