namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        StockPrice = c.Double(nullable: false),
                        Volatility = c.Double(nullable: false),
                        CurrencyId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: true)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        RiskFreeRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "CurrencyId", "dbo.Currencies");
            DropIndex("dbo.Companies", new[] { "CurrencyId" });
            DropTable("dbo.Currencies");
            DropTable("dbo.Companies");
        }
    }
}
