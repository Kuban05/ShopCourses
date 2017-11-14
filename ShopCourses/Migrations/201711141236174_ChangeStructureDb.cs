namespace ShopCourses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStructureDb : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Category", newName: "Categories");
            RenameTable(name: "dbo.Course", newName: "Courses");
            RenameTable(name: "dbo.OrderItem", newName: "OrderItems");
            RenameTable(name: "dbo.Order", newName: "Orders");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Orders", newName: "Order");
            RenameTable(name: "dbo.OrderItems", newName: "OrderItem");
            RenameTable(name: "dbo.Courses", newName: "Course");
            RenameTable(name: "dbo.Categories", newName: "Category");
        }
    }
}
