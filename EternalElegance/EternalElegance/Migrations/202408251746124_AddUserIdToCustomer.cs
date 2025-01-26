namespace EternalElegance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "UserId", c => c.String(nullable: false, maxLength: 128));
        }

        public override void Down()
        {
            DropColumn("dbo.Customers", "UserId");
        }
    }
}
