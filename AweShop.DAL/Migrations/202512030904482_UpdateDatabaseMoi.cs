namespace AweShop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabaseMoi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PhoneNumber", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "StreetAddress", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "State", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "PostCode", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "ExtraNote", c => c.String());
            AlterColumn("dbo.Orders", "City", c => c.String(nullable: false));
            DropColumn("dbo.Orders", "Phone");
            DropColumn("dbo.Orders", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Address", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "City", c => c.String());
            DropColumn("dbo.Orders", "ExtraNote");
            DropColumn("dbo.Orders", "PostCode");
            DropColumn("dbo.Orders", "State");
            DropColumn("dbo.Orders", "StreetAddress");
            DropColumn("dbo.Orders", "PhoneNumber");
        }
    }
}
