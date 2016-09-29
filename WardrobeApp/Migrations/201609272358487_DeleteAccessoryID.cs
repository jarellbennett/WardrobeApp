namespace WardrobeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAccessoryID : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Outfits", "AccessoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Outfits", "AccessoryID", c => c.Int(nullable: false));
        }
    }
}
