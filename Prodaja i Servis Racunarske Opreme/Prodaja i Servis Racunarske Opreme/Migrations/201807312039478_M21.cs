namespace Prodaja_i_Servis_Racunarske_Opreme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M21 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JedinicaMjeres", "Naziv", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JedinicaMjeres", "Naziv", c => c.String());
        }
    }
}
