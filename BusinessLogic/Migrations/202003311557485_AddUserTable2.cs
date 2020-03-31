namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsersDbTables", "Username", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.UsersDbTables", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersDbTables", "Email", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.UsersDbTables", "Username");
        }
    }
}
