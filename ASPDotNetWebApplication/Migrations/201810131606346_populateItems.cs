namespace ASPDotNetWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateItems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Features", "Item_Id", c => c.Int());
            CreateIndex("dbo.Features", "Item_Id");
            AddForeignKey("dbo.Features", "Item_Id", "dbo.Items", "Id");

            Sql("INSERT INTO ITEMS (Name, Status) VALUES('Item1',1) ");
            Sql("INSERT INTO ITEMS (Name, Status) VALUES('Item2',1) ");
            Sql("INSERT INTO ITEMS (Name, Status) VALUES('Item3',0) ");
            Sql("INSERT INTO FEATURES (Name, ITEM_ID) VALUES('Feature1',(select Id from items where Name = 'Item1')) ");
            Sql("INSERT INTO FEATURES (Name, ITEM_ID) VALUES('Feature2',(select Id from items where Name = 'Item3')) ");
            Sql("INSERT INTO FEATURES (Name, ITEM_ID) VALUES('Feature3',(select Id from items where Name = 'Item1')) ");
            Sql("UPDATE FEATURES SET ITEM_ID=(select Id from items where Name = 'Item1') WHERE ID=(select ID FROM FEATURES WHERE NAME='Feature1') ");
            Sql("UPDATE FEATURES SET ITEM_ID=(select Id from items where Name = 'Item3') WHERE ID=(select ID FROM FEATURES WHERE NAME='Feature2') ");
            Sql("UPDATE FEATURES SET ITEM_ID=(select Id from items where Name = 'Item1') WHERE ID=(select ID FROM FEATURES WHERE NAME='Feature3') ");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Features", "Item_Id", "dbo.Items");
            DropIndex("dbo.Features", new[] { "Item_Id" });
            DropColumn("dbo.Features", "Item_Id");
        }
    }
}
