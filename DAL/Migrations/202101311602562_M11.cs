namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        CreationDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        ai_Cart = c.String(maxLength: 100, unicode: false),
                        Quantity = c.Int(nullable: false),
                        ProductID = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        NameEn = c.String(nullable: false, maxLength: 100, unicode: false),
                        NameAr = c.String(nullable: false, maxLength: 100, unicode: false),
                        DescriptionEn = c.String(nullable: false, maxLength: 100, unicode: false),
                        DescriptionAr = c.String(nullable: false, maxLength: 100, unicode: false),
                        FromPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        Code = c.String(nullable: false, maxLength: 100, unicode: false),
                        productstatus = c.Int(nullable: false),
                        TypeID = c.Guid(),
                        CategID = c.Guid(),
                        Sizeid = c.Guid(),
                        CreationDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        MainImage_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Image", t => t.MainImage_Id)
                .ForeignKey("dbo.ProductCategorie", t => t.CategID)
                .ForeignKey("dbo.ProductType", t => t.TypeID)
                .ForeignKey("dbo.Size", t => t.Sizeid)
                .Index(t => t.TypeID)
                .Index(t => t.CategID)
                .Index(t => t.Sizeid)
                .Index(t => t.MainImage_Id);
            
            CreateTable(
                "dbo.BoxReviews",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Username = c.String(maxLength: 100, unicode: false),
                        Summary = c.String(maxLength: 100, unicode: false),
                        Review = c.String(maxLength: 100, unicode: false),
                        rating = c.Int(nullable: false),
                        Userid = c.Guid(nullable: false),
                        Favourite = c.Boolean(nullable: false),
                        ProdID = c.Guid(),
                        CreationDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.ProdID)
                .Index(t => t.ProdID);
            
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductID = c.Guid(),
                        ImageContent = c.Binary(),
                        Description = c.String(maxLength: 100, unicode: false),
                        CreationDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        ProfileId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profile", t => t.ProfileId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.ProductSmallImages",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Photo = c.String(maxLength: 100, unicode: false),
                        SmallImageContent = c.Binary(),
                        CreationDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        MainImageID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Image", t => t.MainImageID)
                .Index(t => t.MainImageID);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 100, unicode: false),
                        LastName = c.String(maxLength: 100, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Birthday = c.DateTime(),
                        Password = c.String(maxLength: 100, unicode: false),
                        ConfirmPassword = c.String(maxLength: 100, unicode: false),
                        Photo = c.String(maxLength: 100, unicode: false),
                        IsActive = c.Boolean(nullable: false),
                        ActivationCode = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        RoleName = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.ProductCategorie",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        NameEn = c.String(maxLength: 100, unicode: false),
                        NameAr = c.String(nullable: false, maxLength: 100, unicode: false),
                        FontAwesome = c.String(maxLength: 100, unicode: false),
                        Icon = c.Binary(),
                        CreationDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductType",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        NameEn = c.String(nullable: false, maxLength: 100, unicode: false),
                        NameAr = c.String(nullable: false, maxLength: 100, unicode: false),
                        CategID = c.Guid(),
                        CreationDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        Icon = c.Binary(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductCategorie", t => t.CategID)
                .Index(t => t.CategID);
            
            CreateTable(
                "dbo.ProductViews",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        PrID = c.Guid(),
                        CreationDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.PrID)
                .Index(t => t.PrID);
            
            CreateTable(
                "dbo.Size",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        CreationDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        Value = c.Double(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        NameEn = c.String(nullable: false, maxLength: 100, unicode: false),
                        NameAr = c.String(nullable: false, maxLength: 100, unicode: false),
                        CountryID = c.Guid(),
                        CreationDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Country", t => t.CountryID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        NameEn = c.String(nullable: false, maxLength: 100, unicode: false),
                        NameAr = c.String(nullable: false, maxLength: 100, unicode: false),
                        CreationDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ContactSMS",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        ToEmail = c.String(maxLength: 100, unicode: false),
                        FromEmail = c.String(maxLength: 100, unicode: false),
                        Subject = c.String(maxLength: 100, unicode: false),
                        Message = c.String(maxLength: 100, unicode: false),
                        Status = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        CreationDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        Payment_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Payment", t => t.Payment_ID)
                .Index(t => t.Payment_ID);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        IBAN = c.String(nullable: false, maxLength: 100, unicode: false),
                        RIB = c.String(nullable: false, maxLength: 100, unicode: false),
                        BankName = c.String(nullable: false, maxLength: 100, unicode: false),
                        CreationDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        Profile_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Profile", t => t.Profile_Id)
                .Index(t => t.Profile_Id);
            
            CreateTable(
                "dbo.PaymentDetails",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        BankName = c.String(nullable: false, maxLength: 100, unicode: false),
                        Country = c.String(nullable: false, maxLength: 100, unicode: false),
                        AccountNumber = c.String(nullable: false, maxLength: 100, unicode: false),
                        AccountExpiryDate = c.String(nullable: false, maxLength: 100, unicode: false),
                        AccountSecurityNumber = c.String(nullable: false, maxLength: 100, unicode: false),
                        CreationDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RoleProfile",
                c => new
                    {
                        Role_RoleId = c.Guid(nullable: false),
                        Profile_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_RoleId, t.Profile_Id })
                .ForeignKey("dbo.Role", t => t.Role_RoleId)
                .ForeignKey("dbo.Profile", t => t.Profile_Id)
                .Index(t => t.Role_RoleId)
                .Index(t => t.Profile_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoice", "Payment_ID", "dbo.Payment");
            DropForeignKey("dbo.Payment", "Profile_Id", "dbo.Profile");
            DropForeignKey("dbo.City", "CountryID", "dbo.Country");
            DropForeignKey("dbo.Carts", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "Sizeid", "dbo.Size");
            DropForeignKey("dbo.ProductViews", "PrID", "dbo.Product");
            DropForeignKey("dbo.Product", "TypeID", "dbo.ProductType");
            DropForeignKey("dbo.ProductType", "CategID", "dbo.ProductCategorie");
            DropForeignKey("dbo.Product", "CategID", "dbo.ProductCategorie");
            DropForeignKey("dbo.Product", "MainImage_Id", "dbo.Image");
            DropForeignKey("dbo.RoleProfile", "Profile_Id", "dbo.Profile");
            DropForeignKey("dbo.RoleProfile", "Role_RoleId", "dbo.Role");
            DropForeignKey("dbo.Image", "ProfileId", "dbo.Profile");
            DropForeignKey("dbo.ProductSmallImages", "MainImageID", "dbo.Image");
            DropForeignKey("dbo.BoxReviews", "ProdID", "dbo.Product");
            DropIndex("dbo.RoleProfile", new[] { "Profile_Id" });
            DropIndex("dbo.RoleProfile", new[] { "Role_RoleId" });
            DropIndex("dbo.Payment", new[] { "Profile_Id" });
            DropIndex("dbo.Invoice", new[] { "Payment_ID" });
            DropIndex("dbo.City", new[] { "CountryID" });
            DropIndex("dbo.ProductViews", new[] { "PrID" });
            DropIndex("dbo.ProductType", new[] { "CategID" });
            DropIndex("dbo.ProductSmallImages", new[] { "MainImageID" });
            DropIndex("dbo.Image", new[] { "ProfileId" });
            DropIndex("dbo.BoxReviews", new[] { "ProdID" });
            DropIndex("dbo.Product", new[] { "MainImage_Id" });
            DropIndex("dbo.Product", new[] { "Sizeid" });
            DropIndex("dbo.Product", new[] { "CategID" });
            DropIndex("dbo.Product", new[] { "TypeID" });
            DropIndex("dbo.Carts", new[] { "ProductID" });
            DropTable("dbo.RoleProfile");
            DropTable("dbo.PaymentDetails");
            DropTable("dbo.Payment");
            DropTable("dbo.Invoice");
            DropTable("dbo.ContactSMS");
            DropTable("dbo.Country");
            DropTable("dbo.City");
            DropTable("dbo.Size");
            DropTable("dbo.ProductViews");
            DropTable("dbo.ProductType");
            DropTable("dbo.ProductCategorie");
            DropTable("dbo.Role");
            DropTable("dbo.Profile");
            DropTable("dbo.ProductSmallImages");
            DropTable("dbo.Image");
            DropTable("dbo.BoxReviews");
            DropTable("dbo.Product");
            DropTable("dbo.Carts");
        }
    }
}
