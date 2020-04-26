namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTable5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UsersDbTables", "Level");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersDbTables", "Level", c => c.Int(nullable: false));
        }
    }
}
