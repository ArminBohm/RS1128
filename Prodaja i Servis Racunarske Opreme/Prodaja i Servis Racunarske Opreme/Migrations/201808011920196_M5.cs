namespace Prodaja_i_Servis_Racunarske_Opreme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KorisnikVMs", "Ime", c => c.String(nullable: false));
            AlterColumn("dbo.KorisnikVMs", "Prezime", c => c.String(nullable: false));
            AlterColumn("dbo.KorisnikVMs", "Adresa", c => c.String(nullable: false));
            AlterColumn("dbo.KorisnikVMs", "BrojTelefona", c => c.String(nullable: false));
            AlterColumn("dbo.KorisnikVMs", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.KorisnikVMs", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KorisnikVMs", "Password", c => c.String());
            AlterColumn("dbo.KorisnikVMs", "UserName", c => c.String());
            AlterColumn("dbo.KorisnikVMs", "BrojTelefona", c => c.String());
            AlterColumn("dbo.KorisnikVMs", "Adresa", c => c.String());
            AlterColumn("dbo.KorisnikVMs", "Prezime", c => c.String());
            AlterColumn("dbo.KorisnikVMs", "Ime", c => c.String());
        }
    }
}
