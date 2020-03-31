namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsersDbTables", "Name", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.UsersDbTables", "Surname", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.UsersDbTables", "Info", c => c.String(nullable: false, maxLength: 300));
            DropColumn("dbo.UsersDbTables", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersDbTables", "Username", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.UsersDbTables", "Info");
            DropColumn("dbo.UsersDbTables", "Surname");
            DropColumn("dbo.UsersDbTables", "Name");
        }
    }
}
