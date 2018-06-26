namespace Prodaja_i_Servis_Racunarske_Opreme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artikals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Cijena = c.Single(nullable: false),
                        ProizvodjacId = c.Int(nullable: false),
                        GrupaProizvodaId = c.Int(nullable: false),
                        JedinicaMjereId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GrupaProizvodas", t => t.GrupaProizvodaId)
                .ForeignKey("dbo.JedinicaMjeres", t => t.JedinicaMjereId)
                .ForeignKey("dbo.Proizvodjacs", t => t.ProizvodjacId)
                .Index(t => t.ProizvodjacId)
                .Index(t => t.GrupaProizvodaId)
                .Index(t => t.JedinicaMjereId);
            
            CreateTable(
                "dbo.GrupaProizvodas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JedinicaMjeres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Proizvodjacs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dobavljacs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        GradId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grads", t => t.GradId)
                .Index(t => t.GradId);
            
            CreateTable(
                "dbo.Grads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EvidencijaDostaves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatumDostave = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Korisniks",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DatumRegistracije = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Osobas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Osobas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Adresa = c.String(),
                        Email = c.String(),
                        BrojTelefona = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        GradId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grads", t => t.GradId)
                .Index(t => t.GradId);
            
            CreateTable(
                "dbo.Zaposleniks",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        PocetakRadnogOdnosa = c.DateTime(nullable: false),
                        ZavrsetakRadnogOdnosa = c.DateTime(nullable: false),
                        StrucnaSpremaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StrucnaSpremas", t => t.StrucnaSpremaId)
                .ForeignKey("dbo.Osobas", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.StrucnaSpremaId);
            
            CreateTable(
                "dbo.StrucnaSpremas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Narudzbas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatumNaredzbe = c.DateTime(nullable: false),
                        DobavljacId = c.Int(nullable: false),
                        ZaposlenikId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dobavljacs", t => t.DobavljacId)
                .ForeignKey("dbo.Zaposleniks", t => t.ZaposlenikId)
                .Index(t => t.DobavljacId)
                .Index(t => t.ZaposlenikId);
            
            CreateTable(
                "dbo.NazivPlacanjas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Metoda = c.String(),
                        Valuta = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Popusts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Iznos = c.Single(nullable: false),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Racuns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipUsluge = c.String(),
                        DatumUsluge = c.DateTime(nullable: false),
                        OsobaId = c.Int(nullable: false),
                        NazivPlacanjaId = c.Int(nullable: false),
                        PopustId = c.Int(nullable: false),
                        EvidencijaDostaveId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EvidencijaDostaves", t => t.EvidencijaDostaveId)
                .ForeignKey("dbo.NazivPlacanjas", t => t.NazivPlacanjaId)
                .ForeignKey("dbo.Osobas", t => t.OsobaId)
                .ForeignKey("dbo.Popusts", t => t.PopustId)
                .Index(t => t.OsobaId)
                .Index(t => t.NazivPlacanjaId)
                .Index(t => t.PopustId)
                .Index(t => t.EvidencijaDostaveId);
            
            CreateTable(
                "dbo.Uslugas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Cijena = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Skladistes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Kolicina = c.Int(nullable: false),
                        ArtikalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artikals", t => t.ArtikalId)
                .Index(t => t.ArtikalId);
            
            CreateTable(
                "dbo.Stavkas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Kolicina = c.Int(nullable: false),
                        NarudzbaId = c.Int(),
                        RacunId = c.Int(),
                        ArtikalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artikals", t => t.ArtikalId)
                .ForeignKey("dbo.Narudzbas", t => t.NarudzbaId)
                .ForeignKey("dbo.Racuns", t => t.RacunId)
                .Index(t => t.NarudzbaId)
                .Index(t => t.RacunId)
                .Index(t => t.ArtikalId);
            
            CreateTable(
                "dbo.TipDostaves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IzvrsenaUsluga",
                c => new
                    {
                        RacunId = c.Int(nullable: false),
                        UslugaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RacunId, t.UslugaId })
                .ForeignKey("dbo.Racuns", t => t.RacunId, cascadeDelete: true)
                .ForeignKey("dbo.Uslugas", t => t.UslugaId, cascadeDelete: true)
                .Index(t => t.RacunId)
                .Index(t => t.UslugaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stavkas", "RacunId", "dbo.Racuns");
            DropForeignKey("dbo.Stavkas", "NarudzbaId", "dbo.Narudzbas");
            DropForeignKey("dbo.Stavkas", "ArtikalId", "dbo.Artikals");
            DropForeignKey("dbo.Skladistes", "ArtikalId", "dbo.Artikals");
            DropForeignKey("dbo.IzvrsenaUsluga", "UslugaId", "dbo.Uslugas");
            DropForeignKey("dbo.IzvrsenaUsluga", "RacunId", "dbo.Racuns");
            DropForeignKey("dbo.Racuns", "PopustId", "dbo.Popusts");
            DropForeignKey("dbo.Racuns", "OsobaId", "dbo.Osobas");
            DropForeignKey("dbo.Racuns", "NazivPlacanjaId", "dbo.NazivPlacanjas");
            DropForeignKey("dbo.Racuns", "EvidencijaDostaveId", "dbo.EvidencijaDostaves");
            DropForeignKey("dbo.Narudzbas", "ZaposlenikId", "dbo.Zaposleniks");
            DropForeignKey("dbo.Narudzbas", "DobavljacId", "dbo.Dobavljacs");
            DropForeignKey("dbo.Zaposleniks", "Id", "dbo.Osobas");
            DropForeignKey("dbo.Zaposleniks", "StrucnaSpremaId", "dbo.StrucnaSpremas");
            DropForeignKey("dbo.Korisniks", "Id", "dbo.Osobas");
            DropForeignKey("dbo.Osobas", "GradId", "dbo.Grads");
            DropForeignKey("dbo.Dobavljacs", "GradId", "dbo.Grads");
            DropForeignKey("dbo.Artikals", "ProizvodjacId", "dbo.Proizvodjacs");
            DropForeignKey("dbo.Artikals", "JedinicaMjereId", "dbo.JedinicaMjeres");
            DropForeignKey("dbo.Artikals", "GrupaProizvodaId", "dbo.GrupaProizvodas");
            DropIndex("dbo.IzvrsenaUsluga", new[] { "UslugaId" });
            DropIndex("dbo.IzvrsenaUsluga", new[] { "RacunId" });
            DropIndex("dbo.Stavkas", new[] { "ArtikalId" });
            DropIndex("dbo.Stavkas", new[] { "RacunId" });
            DropIndex("dbo.Stavkas", new[] { "NarudzbaId" });
            DropIndex("dbo.Skladistes", new[] { "ArtikalId" });
            DropIndex("dbo.Racuns", new[] { "EvidencijaDostaveId" });
            DropIndex("dbo.Racuns", new[] { "PopustId" });
            DropIndex("dbo.Racuns", new[] { "NazivPlacanjaId" });
            DropIndex("dbo.Racuns", new[] { "OsobaId" });
            DropIndex("dbo.Narudzbas", new[] { "ZaposlenikId" });
            DropIndex("dbo.Narudzbas", new[] { "DobavljacId" });
            DropIndex("dbo.Zaposleniks", new[] { "StrucnaSpremaId" });
            DropIndex("dbo.Zaposleniks", new[] { "Id" });
            DropIndex("dbo.Osobas", new[] { "GradId" });
            DropIndex("dbo.Korisniks", new[] { "Id" });
            DropIndex("dbo.Dobavljacs", new[] { "GradId" });
            DropIndex("dbo.Artikals", new[] { "JedinicaMjereId" });
            DropIndex("dbo.Artikals", new[] { "GrupaProizvodaId" });
            DropIndex("dbo.Artikals", new[] { "ProizvodjacId" });
            DropTable("dbo.IzvrsenaUsluga");
            DropTable("dbo.TipDostaves");
            DropTable("dbo.Stavkas");
            DropTable("dbo.Skladistes");
            DropTable("dbo.Uslugas");
            DropTable("dbo.Racuns");
            DropTable("dbo.Popusts");
            DropTable("dbo.NazivPlacanjas");
            DropTable("dbo.Narudzbas");
            DropTable("dbo.StrucnaSpremas");
            DropTable("dbo.Zaposleniks");
            DropTable("dbo.Osobas");
            DropTable("dbo.Korisniks");
            DropTable("dbo.EvidencijaDostaves");
            DropTable("dbo.Grads");
            DropTable("dbo.Dobavljacs");
            DropTable("dbo.Proizvodjacs");
            DropTable("dbo.JedinicaMjeres");
            DropTable("dbo.GrupaProizvodas");
            DropTable("dbo.Artikals");
        }
    }
}
