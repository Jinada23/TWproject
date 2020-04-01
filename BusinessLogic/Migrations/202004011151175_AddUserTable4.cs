namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTable4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UsersDbTables", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UsersDbTables", "Password", c => c.String(nullable: false, maxLength: 40));
        }
    }
}
