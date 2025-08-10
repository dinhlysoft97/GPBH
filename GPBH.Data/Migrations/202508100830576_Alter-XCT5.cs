namespace GPBH.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterXCT5 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.XCT5");
            AlterColumn("dbo.XCT5", "So_to_khai", c => c.String(nullable: false, maxLength: 20));
            AddPrimaryKey("dbo.XCT5", new[] { "Ma_phieu", "Ma_hh", "So_to_khai" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.XCT5");
            AlterColumn("dbo.XCT5", "So_to_khai", c => c.String(maxLength: 20));
            AddPrimaryKey("dbo.XCT5", new[] { "Ma_phieu", "Stt" });
        }
    }
}
