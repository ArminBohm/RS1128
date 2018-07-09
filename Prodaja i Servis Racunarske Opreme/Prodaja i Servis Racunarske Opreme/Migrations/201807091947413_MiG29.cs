namespace Prodaja_i_Servis_Racunarske_Opreme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiG29 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Zaduzenjes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Zaposleniks", "ZaduzenjeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Zaposleniks", "ZaduzenjeId");
            AddForeignKey("dbo.Zaposleniks", "ZaduzenjeId", "dbo.Zaduzenjes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zaposleniks", "ZaduzenjeId", "dbo.Zaduzenjes");
            DropIndex("dbo.Zaposleniks", new[] { "ZaduzenjeId" });
            DropColumn("dbo.Zaposleniks", "ZaduzenjeId");
            DropTable("dbo.Zaduzenjes");
        }
    }
}
