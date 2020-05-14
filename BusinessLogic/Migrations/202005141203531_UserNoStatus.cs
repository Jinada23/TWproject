namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNoStatus : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UsersDbTables", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersDbTables", "Status", c => c.Boolean(nullable: false));
        }
    }
}
