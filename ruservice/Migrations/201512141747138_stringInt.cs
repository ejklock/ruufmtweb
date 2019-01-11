namespace ruservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stringInt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cardapios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        periodo = c.String(unicode: false),
                        data = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tipo = c.String(unicode: false),
                        prato = c.String(unicode: false),
                        cardapioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cardapios", t => t.cardapioId, cascadeDelete: true)
                .Index(t => t.cardapioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "cardapioId", "dbo.Cardapios");
            DropIndex("dbo.Items", new[] { "cardapioId" });
            DropTable("dbo.Items");
            DropTable("dbo.Cardapios");
        }
    }
}
