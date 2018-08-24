namespace RecipeApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class favorite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favorite",
                c => new
                    {
                        FavoriteId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        RecipeName = c.String(nullable: false),
                        Origin = c.String(nullable: false),
                        Ingredients = c.String(nullable: false),
                        Directions = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.FavoriteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Favorite");
        }
    }
}
