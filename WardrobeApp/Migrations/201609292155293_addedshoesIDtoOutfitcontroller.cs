namespace WardrobeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedshoesIDtoOutfitcontroller : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Outfits", "Shoe_ShoesID", "dbo.Shoes");
            DropIndex("dbo.Outfits", new[] { "Shoe_ShoesID" });
            RenameColumn(table: "dbo.Outfits", name: "Shoe_ShoesID", newName: "ShoesID");
            AlterColumn("dbo.Outfits", "ShoesID", c => c.Int(nullable: false));
            CreateIndex("dbo.Outfits", "ShoesID");
            AddForeignKey("dbo.Outfits", "ShoesID", "dbo.Shoes", "ShoesID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Outfits", "ShoesID", "dbo.Shoes");
            DropIndex("dbo.Outfits", new[] { "ShoesID" });
            AlterColumn("dbo.Outfits", "ShoesID", c => c.Int());
            RenameColumn(table: "dbo.Outfits", name: "ShoesID", newName: "Shoe_ShoesID");
            CreateIndex("dbo.Outfits", "Shoe_ShoesID");
            AddForeignKey("dbo.Outfits", "Shoe_ShoesID", "dbo.Shoes", "ShoesID");
        }
    }
}
