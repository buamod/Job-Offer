namespace Job_Offers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addjobss1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobsses", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Jobsses", new[] { "Category_ID" });
            RenameColumn(table: "dbo.Jobsses", name: "Category_ID", newName: "CategoryID");
            AlterColumn("dbo.Jobsses", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobsses", "CategoryID");
            AddForeignKey("dbo.Jobsses", "CategoryID", "dbo.Categories", "ID", cascadeDelete: true);
            DropColumn("dbo.Jobsses", "CatagoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobsses", "CatagoryID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Jobsses", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Jobsses", new[] { "CategoryID" });
            AlterColumn("dbo.Jobsses", "CategoryID", c => c.Int());
            RenameColumn(table: "dbo.Jobsses", name: "CategoryID", newName: "Category_ID");
            CreateIndex("dbo.Jobsses", "Category_ID");
            AddForeignKey("dbo.Jobsses", "Category_ID", "dbo.Categories", "ID");
        }
    }
}
