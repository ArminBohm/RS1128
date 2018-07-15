
namespace Prodaja_i_Servis_Racunarske_Opreme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiG32 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KorisnikVMs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DatumRegistracije = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Adresa = c.String(),
                        Email = c.String(),
                        BrojTelefona = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        GradId = c.Int(nullable: false),
                        NazivGrada = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Grads", "KorisnikVM_id", c => c.Int());
            CreateIndex("dbo.Grads", "KorisnikVM_id");
            AddForeignKey("dbo.Grads", "KorisnikVM_id", "dbo.KorisnikVMs", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grads", "KorisnikVM_id", "dbo.KorisnikVMs");
            DropIndex("dbo.Grads", new[] { "KorisnikVM_id" });
            DropColumn("dbo.Grads", "KorisnikVM_id");
            DropTable("dbo.KorisnikVMs");
        }
    }
}
