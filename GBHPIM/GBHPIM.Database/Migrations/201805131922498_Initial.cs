namespace GBHPIM.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarID = c.Int(nullable: false, identity: true),
                        License = c.Int(nullable: false),
                        PictureOFCar = c.Binary(),
                        Year = c.DateTime(nullable: false),
                        MakeModel = c.String(),
                        PlateNumber = c.Int(nullable: false),
                        ParentCar_ParentID = c.Int(),
                    })
                .PrimaryKey(t => t.CarID)
                .ForeignKey("dbo.Parents", t => t.ParentCar_ParentID)
                .Index(t => t.ParentCar_ParentID);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        ParentID = c.Int(nullable: false, identity: true),
                        NumberOfChildren = c.Int(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        DateRegisterd = c.DateTime(nullable: false),
                        Picture = c.Binary(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ParentID);
            
            CreateTable(
                "dbo.Children",
                c => new
                    {
                        ChildrenID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        GetParent_ParentID = c.Int(),
                    })
                .PrimaryKey(t => t.ChildrenID)
                .ForeignKey("dbo.Parents", t => t.GetParent_ParentID)
                .Index(t => t.GetParent_ParentID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        SchoolID = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        SchoolDistrict = c.String(),
                        City = c.String(),
                        State = c.String(),
                        GetChildren_ChildrenID = c.Int(),
                    })
                .PrimaryKey(t => t.SchoolID)
                .ForeignKey("dbo.Children", t => t.GetChildren_ChildrenID)
                .Index(t => t.GetChildren_ChildrenID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Schools", "GetChildren_ChildrenID", "dbo.Children");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Children", "GetParent_ParentID", "dbo.Parents");
            DropForeignKey("dbo.Cars", "ParentCar_ParentID", "dbo.Parents");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Schools", new[] { "GetChildren_ChildrenID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Children", new[] { "GetParent_ParentID" });
            DropIndex("dbo.Cars", new[] { "ParentCar_ParentID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Schools");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Children");
            DropTable("dbo.Parents");
            DropTable("dbo.Cars");
        }
    }
}
