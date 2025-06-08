namespace GPBH.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterXPH5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.XPH5", "Tl1_tien_nt", c => c.Decimal(precision: 19, scale: 4));
            AddColumn("dbo.XPH5", "Tl2_tien_nt", c => c.Decimal(precision: 19, scale: 4));
            AddColumn("dbo.XPH5", "Tl3_tien_nt", c => c.Decimal(precision: 19, scale: 4));
            DropColumn("dbo.XPH5", "Tl1_tien_usd");
            DropColumn("dbo.XPH5", "Tl2_tien_usd");
            DropColumn("dbo.XPH5", "Tl3_tien_usd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.XPH5", "Tl3_tien_usd", c => c.Decimal(precision: 19, scale: 4));
            AddColumn("dbo.XPH5", "Tl2_tien_usd", c => c.Decimal(precision: 19, scale: 4));
            AddColumn("dbo.XPH5", "Tl1_tien_usd", c => c.Decimal(precision: 19, scale: 4));
            DropColumn("dbo.XPH5", "Tl3_tien_nt");
            DropColumn("dbo.XPH5", "Tl2_tien_nt");
            DropColumn("dbo.XPH5", "Tl1_tien_nt");
        }
    }
}
