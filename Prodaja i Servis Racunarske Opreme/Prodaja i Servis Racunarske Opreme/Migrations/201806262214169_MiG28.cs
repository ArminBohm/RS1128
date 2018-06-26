namespace Prodaja_i_Servis_Racunarske_Opreme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiG28 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EvidencijaDostaves", "TipDostaveId", c => c.Int(nullable: false));
            CreateIndex("dbo.EvidencijaDostaves", "TipDostaveId");
            AddForeignKey("dbo.EvidencijaDostaves", "TipDostaveId", "dbo.TipDostaves", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EvidencijaDostaves", "TipDostaveId", "dbo.TipDostaves");
            DropIndex("dbo.EvidencijaDostaves", new[] { "TipDostaveId" });
            DropColumn("dbo.EvidencijaDostaves", "TipDostaveId");
        }
    }
}
