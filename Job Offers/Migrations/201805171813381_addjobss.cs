namespace Job_Offers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addjobss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobsses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        JibContent = c.String(),
                        JobImage = c.String(),
                        CatagoryID = c.Int(nullable: false),
                        Category_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .Index(t => t.Category_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobsses", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Jobsses", new[] { "Category_ID" });
            DropTable("dbo.Jobsses");
        }
    }
}
