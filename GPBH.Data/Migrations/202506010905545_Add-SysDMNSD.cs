namespace GPBH.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSysDMNSD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SysDMNSD",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenDangNhap = c.String(nullable: false, maxLength: 20),
                        TenDayDu = c.String(maxLength: 50),
                        MatKhau = c.String(maxLength: 500),
                        IsAdmin = c.Boolean(nullable: false),
                        Ksd = c.Boolean(nullable: false),
                        NguoiTao = c.String(maxLength: 20),
                        NgayTao = c.DateTime(),
                        NguoiSua = c.String(maxLength: 20),
                        NgaySua = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenDangNhap, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.SysDMNSD", new[] { "TenDangNhap" });
            DropTable("dbo.SysDMNSD");
        }
    }
}
