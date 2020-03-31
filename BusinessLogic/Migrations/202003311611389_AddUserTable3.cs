namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTable3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UsersDbTables", "Surname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersDbTables", "Surname", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
