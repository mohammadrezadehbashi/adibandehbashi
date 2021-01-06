namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminLogins",
                c => new
                    {
                        LoginID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false, maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.LoginID);
            
            CreateTable(
                "dbo.DataRezervcs",
                c => new
                    {
                        DataRezervID = c.Int(nullable: false, identity: true),
                        DateRez = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DataRezervID);
            
            CreateTable(
                "dbo.Numberings",
                c => new
                    {
                        NumberingID = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        DataRezervcs_DataRezervID = c.Int(),
                    })
                .PrimaryKey(t => t.NumberingID)
                .ForeignKey("dbo.DataRezervcs", t => t.DataRezervcs_DataRezervID)
                .Index(t => t.DataRezervcs_DataRezervID);
            
            CreateTable(
                "dbo.Hours",
                c => new
                    {
                        HourID = c.Int(nullable: false, identity: true),
                        SelectHour = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.HourID);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationID = c.Int(nullable: false, identity: true),
                        StationID = c.Int(nullable: false),
                        HourID = c.Int(nullable: false),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationID)
                .ForeignKey("dbo.Hours", t => t.HourID, cascadeDelete: true)
                .ForeignKey("dbo.Stations", t => t.StationID, cascadeDelete: true)
                .Index(t => t.StationID)
                .Index(t => t.HourID);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        StationID = c.Int(nullable: false, identity: true),
                        StationName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StationID);
            
            CreateTable(
                "dbo.PageComments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        PageID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 150),
                        Email = c.String(maxLength: 200),
                        WebSite = c.String(maxLength: 200),
                        Comment = c.String(nullable: false, maxLength: 500),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Pages", t => t.PageID, cascadeDelete: true)
                .Index(t => t.PageID);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        ShortDescription = c.String(nullable: false, maxLength: 250),
                        Text = c.String(nullable: false),
                        Visit = c.Int(nullable: false),
                        ShowInSlider = c.Boolean(nullable: false),
                        ImageName = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PageID)
                .ForeignKey("dbo.PageGroups", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.PageGroups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        GroupTitle = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.GroupID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "GroupID", "dbo.PageGroups");
            DropForeignKey("dbo.PageComments", "PageID", "dbo.Pages");
            DropForeignKey("dbo.Reservations", "StationID", "dbo.Stations");
            DropForeignKey("dbo.Reservations", "HourID", "dbo.Hours");
            DropForeignKey("dbo.Numberings", "DataRezervcs_DataRezervID", "dbo.DataRezervcs");
            DropIndex("dbo.Pages", new[] { "GroupID" });
            DropIndex("dbo.PageComments", new[] { "PageID" });
            DropIndex("dbo.Reservations", new[] { "HourID" });
            DropIndex("dbo.Reservations", new[] { "StationID" });
            DropIndex("dbo.Numberings", new[] { "DataRezervcs_DataRezervID" });
            DropTable("dbo.PageGroups");
            DropTable("dbo.Pages");
            DropTable("dbo.PageComments");
            DropTable("dbo.Stations");
            DropTable("dbo.Reservations");
            DropTable("dbo.Hours");
            DropTable("dbo.Numberings");
            DropTable("dbo.DataRezervcs");
            DropTable("dbo.AdminLogins");
        }
    }
}
