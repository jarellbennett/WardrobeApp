namespace WardrobeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        AccessoryID = c.Int(nullable: false, identity: true),
                        AccessoryName = c.String(),
                        AccessoryColor = c.String(),
                        AccessoryPhoto = c.String(),
                    })
                .PrimaryKey(t => t.AccessoryID);
            
            CreateTable(
                "dbo.Outfits",
                c => new
                    {
                        OutfitID = c.Int(nullable: false, identity: true),
                        OutfitName = c.String(),
                        TopID = c.Int(nullable: false),
                        BottomID = c.Int(nullable: false),
                        AccessoryID = c.Int(nullable: false),
                        SeasonID = c.Int(nullable: false),
                        OccasionID = c.Int(nullable: false),
                        Shoe_ShoesID = c.Int(),
                    })
                .PrimaryKey(t => t.OutfitID)
                .ForeignKey("dbo.Bottoms", t => t.BottomID, cascadeDelete: true)
                .ForeignKey("dbo.Occasions", t => t.OccasionID, cascadeDelete: true)
                .ForeignKey("dbo.Seasons", t => t.SeasonID, cascadeDelete: true)
                .ForeignKey("dbo.Shoes", t => t.Shoe_ShoesID)
                .ForeignKey("dbo.Tops", t => t.TopID, cascadeDelete: true)
                .Index(t => t.TopID)
                .Index(t => t.BottomID)
                .Index(t => t.SeasonID)
                .Index(t => t.OccasionID)
                .Index(t => t.Shoe_ShoesID);
            
            CreateTable(
                "dbo.Bottoms",
                c => new
                    {
                        BottomID = c.Int(nullable: false, identity: true),
                        BotName = c.String(),
                        BotColor = c.String(),
                        BotPhoto = c.String(),
                    })
                .PrimaryKey(t => t.BottomID);
            
            CreateTable(
                "dbo.Occasions",
                c => new
                    {
                        OccasionID = c.Int(nullable: false, identity: true),
                        OccasionName = c.String(),
                    })
                .PrimaryKey(t => t.OccasionID);
            
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        SeasonID = c.Int(nullable: false, identity: true),
                        SeasonName = c.String(),
                    })
                .PrimaryKey(t => t.SeasonID);
            
            CreateTable(
                "dbo.Shoes",
                c => new
                    {
                        ShoesID = c.Int(nullable: false, identity: true),
                        ShoeName = c.String(),
                        ShoeColor = c.String(),
                        ShoePhoto = c.String(),
                    })
                .PrimaryKey(t => t.ShoesID);
            
            CreateTable(
                "dbo.Tops",
                c => new
                    {
                        TopID = c.Int(nullable: false, identity: true),
                        TopName = c.String(),
                        TopColor = c.String(),
                        TopPhoto = c.String(),
                    })
                .PrimaryKey(t => t.TopID);
            
            CreateTable(
                "dbo.OutfitAccessories",
                c => new
                    {
                        Outfit_OutfitID = c.Int(nullable: false),
                        Accessory_AccessoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Outfit_OutfitID, t.Accessory_AccessoryID })
                .ForeignKey("dbo.Outfits", t => t.Outfit_OutfitID, cascadeDelete: true)
                .ForeignKey("dbo.Accessories", t => t.Accessory_AccessoryID, cascadeDelete: true)
                .Index(t => t.Outfit_OutfitID)
                .Index(t => t.Accessory_AccessoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Outfits", "TopID", "dbo.Tops");
            DropForeignKey("dbo.Outfits", "Shoe_ShoesID", "dbo.Shoes");
            DropForeignKey("dbo.Outfits", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Outfits", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Outfits", "BottomID", "dbo.Bottoms");
            DropForeignKey("dbo.OutfitAccessories", "Accessory_AccessoryID", "dbo.Accessories");
            DropForeignKey("dbo.OutfitAccessories", "Outfit_OutfitID", "dbo.Outfits");
            DropIndex("dbo.OutfitAccessories", new[] { "Accessory_AccessoryID" });
            DropIndex("dbo.OutfitAccessories", new[] { "Outfit_OutfitID" });
            DropIndex("dbo.Outfits", new[] { "Shoe_ShoesID" });
            DropIndex("dbo.Outfits", new[] { "OccasionID" });
            DropIndex("dbo.Outfits", new[] { "SeasonID" });
            DropIndex("dbo.Outfits", new[] { "BottomID" });
            DropIndex("dbo.Outfits", new[] { "TopID" });
            DropTable("dbo.OutfitAccessories");
            DropTable("dbo.Tops");
            DropTable("dbo.Shoes");
            DropTable("dbo.Seasons");
            DropTable("dbo.Occasions");
            DropTable("dbo.Bottoms");
            DropTable("dbo.Outfits");
            DropTable("dbo.Accessories");
        }
    }
}
