namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTable6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsersDbTables", "ImgUrl", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UsersDbTables", "ImgUrl");
        }
    }
}
