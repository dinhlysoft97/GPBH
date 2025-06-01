namespace GPBH.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSysMenu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SysMenu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(nullable: false, maxLength: 20),
                        MenuName = c.String(maxLength: 50),
                        Type = c.Int(nullable: false),
                        Report = c.Boolean(nullable: false),
                        BasicRight = c.Boolean(nullable: false),
                        Picture = c.String(),
                        Active = c.Boolean(nullable: false),
                        Stt = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SysMenu");
        }
    }
}
