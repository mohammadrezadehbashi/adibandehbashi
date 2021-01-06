namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Re_Pages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "DateRez", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "DateRez");
        }
    }
}
