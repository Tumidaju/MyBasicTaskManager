namespace MyBasicTaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBObjects : DbMigration
    {
        public override void Up()
        {
            string sqlResName = typeof(DBObjects).Namespace + ".201901191329314_DBObjects.sql";
            this.SqlResource(sqlResName);
        }
        
        public override void Down()
        {
        }
    }
}
