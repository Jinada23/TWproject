namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userInput : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsersDbTables", "Genre", c => c.String(maxLength: 300));
            AddColumn("dbo.UsersDbTables", "Tags", c => c.String(maxLength: 300));
            AddColumn("dbo.UsersDbTables", "Instruments", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UsersDbTables", "Instruments");
            DropColumn("dbo.UsersDbTables", "Tags");
            DropColumn("dbo.UsersDbTables", "Genre");
        }
    }
}
