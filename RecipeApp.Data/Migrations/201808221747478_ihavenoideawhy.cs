namespace RecipeApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ihavenoideawhy : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ingredient", "IngredientName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ingredient", "IngredientName", c => c.Int(nullable: false));
        }
    }
}
