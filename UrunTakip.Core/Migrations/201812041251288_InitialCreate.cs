namespace UrunTakip.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductsInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QName = c.String(),
                        Date = c.String(),
                        CustomerName = c.String(),
                        Amount = c.String(),
                        Color = c.String(),
                        Chemical = c.String(),
                        ChemicalProduct = c.String(),
                        Txt1 = c.String(),
                        Processing = c.String(),
                        DateOfProcessing = c.String(),
                        EndProcessingDate = c.String(),
                        Date2 = c.String(),
                        Manager = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductsInfoes");
        }
    }
}
