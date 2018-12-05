namespace UrunTakip.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonelName = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserInfoes");
        }
    }
}
