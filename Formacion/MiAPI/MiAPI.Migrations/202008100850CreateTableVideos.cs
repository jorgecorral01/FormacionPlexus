﻿using FluentMigrator;

namespace MiAPI.infrastucture.SqlMigrations {
    [Migration(202008100850)]
    public class CreateTableVideos : Migration {
        private const string TableName = @"Videos";
        public override void Up() {
            Create.Table(TableName)
                .WithColumn("VideoId").AsInt64().PrimaryKey($"PK_{TableName}").Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Format").AsString().NotNullable()
                .WithColumn("CreateDate").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime)
                .WithColumn("UpdateDate").AsDateTime().Nullable();
        }

        public override void Down() {
            Delete.Table(TableName);
        }
    }
}
