namespace MovieSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255, storeType: "nvarchar"),
                        Description = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 255, storeType: "nvarchar"),
                        Description = c.String(maxLength: 255, storeType: "nvarchar"),
                        Year = c.DateTime(nullable: false, precision: 0),
                        Genres_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genre", t => t.Genres_Id)
                .Index(t => t.Genres_Id);

            Sql(@"
                INSERT INTO Genre (Name, Description) VALUES('Aventura', 'Filmes de aventura');
                INSERT INTO Genre (Name, Description) VALUES('Ficção', 'Filmes de ficção');

                INSERT INTO Movie (Title, Description, Year, Genres_id) VALUES('teste', 'Lorem ipsun', 2018, 1);
            ");

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movie", "Genres_Id", "dbo.Genre");
            DropIndex("dbo.Movie", new[] { "Genres_Id" });
            DropTable("dbo.Movie");
            DropTable("dbo.Genre");
        }
    }
}
