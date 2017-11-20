namespace ShopCourses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelDataUserAndOrder : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Orders", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
            AddColumn("dbo.Orders", "Address", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.AspNetUsers", "DataUser_PostCode", c => c.String());
            AlterColumn("dbo.Orders", "PhoneNumber", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Orders", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Orders", "Street");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Street", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Orders", "Email", c => c.String());
            AlterColumn("dbo.Orders", "PhoneNumber", c => c.String());
            DropColumn("dbo.AspNetUsers", "DataUser_PostCode");
            DropColumn("dbo.Orders", "Address");
            RenameIndex(table: "dbo.Orders", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Orders", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
