namespace RecipeApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ingredient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        IngredientId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        IngredientName = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.IngredientId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ingredient");
        }
    }
}
