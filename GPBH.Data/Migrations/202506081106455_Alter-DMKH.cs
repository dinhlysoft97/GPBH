namespace GPBH.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterDMKH : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DMKH", "Xnc_ngay_cap", c => c.DateTime());
            AddColumn("dbo.DMKH", "Xnc_ngay_hh", c => c.DateTime());
            AddColumn("dbo.DMKH", "So_hieu", c => c.String());
            AddColumn("dbo.DMKH", "Ten_tau_bay", c => c.String());
            AddColumn("dbo.DMKH", "Han_muc", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.DMQG", "Ten_Quoc_gia", c => c.String());
            DropColumn("dbo.DMKH", "Di_dong");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DMKH", "Di_dong", c => c.String(maxLength: 20));
            DropColumn("dbo.DMQG", "Ten_Quoc_gia");
            DropColumn("dbo.DMKH", "Han_muc");
            DropColumn("dbo.DMKH", "Ten_tau_bay");
            DropColumn("dbo.DMKH", "So_hieu");
            DropColumn("dbo.DMKH", "Xnc_ngay_hh");
            DropColumn("dbo.DMKH", "Xnc_ngay_cap");
        }
    }
}
