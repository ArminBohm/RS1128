namespace Prodaja_i_Servis_Racunarske_Opreme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiG31 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Zaduzenjes", "Naziv", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Zaduzenjes", "Naziv", c => c.Int(nullable: false));
        }
    }
}
