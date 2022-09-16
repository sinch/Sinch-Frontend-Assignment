using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sinch.Config.Mgmt.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("3ab55dd4-eb05-4355-b657-219fd3f50667"), "RTC API Gateway", "RTC.ApiGateway" });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("3e8e1230-f26e-4cd0-aecc-5d64637f9278"), "RTC Calling Service", "RTC.CallingService" });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("4ec370a1-1ccf-489b-bf39-c3580356f407"), "RTC Calling Application", "RTC.CallingApplication" });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("626090f5-296d-4b8b-8a89-2557f773755b"), "RTC Billing Application", "RTC.BillingApplication" });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("a70247a8-4d49-43b3-94be-1ef6455734cb"), "RTC Billing Service", "RTC.BillingService" });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("a75017e9-70f7-4363-8d73-1b8f306c2008"), "RTC Calling API", "RTC.CallingApi" });

            migrationBuilder.InsertData(
                table: "Environments",
                columns: new[] { "Id", "ApplicationId", "Name", "Region" },
                values: new object[] { new Guid("0985a1fc-b891-490a-9937-f6881d0cbc30"), new Guid("3ab55dd4-eb05-4355-b657-219fd3f50667"), "Dev", "EU-West1" });

            migrationBuilder.InsertData(
                table: "Environments",
                columns: new[] { "Id", "ApplicationId", "Name", "Region" },
                values: new object[] { new Guid("0a75bc9e-470e-4468-a2f8-3a9dda933306"), new Guid("4ec370a1-1ccf-489b-bf39-c3580356f407"), "Prod", "EU-West1" });

            migrationBuilder.InsertData(
                table: "Environments",
                columns: new[] { "Id", "ApplicationId", "Name", "Region" },
                values: new object[] { new Guid("1a884483-a7a8-4c45-b617-75ecfa62deb8"), new Guid("3ab55dd4-eb05-4355-b657-219fd3f50667"), "Qa", "EU-West1" });

            migrationBuilder.InsertData(
                table: "Environments",
                columns: new[] { "Id", "ApplicationId", "Name", "Region" },
                values: new object[] { new Guid("1f9b6afe-5725-4ad0-9460-2abaed19ba36"), new Guid("4ec370a1-1ccf-489b-bf39-c3580356f407"), "Dev", "EU-West1" });

            migrationBuilder.InsertData(
                table: "Environments",
                columns: new[] { "Id", "ApplicationId", "Name", "Region" },
                values: new object[] { new Guid("267a7710-7a87-4c3d-926f-910776adfda7"), new Guid("3ab55dd4-eb05-4355-b657-219fd3f50667"), "Prod", "EU-West1" });

            migrationBuilder.InsertData(
                table: "Environments",
                columns: new[] { "Id", "ApplicationId", "Name", "Region" },
                values: new object[] { new Guid("27c43d20-1289-4aed-8a6d-2573b8131a55"), new Guid("4ec370a1-1ccf-489b-bf39-c3580356f407"), "Qa", "EU-West1" });

            migrationBuilder.InsertData(
                table: "Environments",
                columns: new[] { "Id", "ApplicationId", "Name", "Region" },
                values: new object[] { new Guid("360cb85a-1d94-4de0-8cae-d5759f820490"), new Guid("a75017e9-70f7-4363-8d73-1b8f306c2008"), "Dev", "EU-West1" });

            migrationBuilder.InsertData(
                table: "Environments",
                columns: new[] { "Id", "ApplicationId", "Name", "Region" },
                values: new object[] { new Guid("3773fe57-a236-49a5-9ad6-94f0189140e0"), new Guid("a75017e9-70f7-4363-8d73-1b8f306c2008"), "Prod", "EU-West1" });

            migrationBuilder.InsertData(
                table: "Environments",
                columns: new[] { "Id", "ApplicationId", "Name", "Region" },
                values: new object[] { new Guid("3acbb91d-6c21-43f2-b246-0cadd1ad3063"), new Guid("3e8e1230-f26e-4cd0-aecc-5d64637f9278"), "Dev", "EU-West1" });

            migrationBuilder.InsertData(
                table: "Environments",
                columns: new[] { "Id", "ApplicationId", "Name", "Region" },
                values: new object[] { new Guid("3c1cc7ed-944f-44ac-a05b-a63f8402f106"), new Guid("a75017e9-70f7-4363-8d73-1b8f306c2008"), "Qa", "EU-West1" });

            migrationBuilder.InsertData(
                table: "Environments",
                columns: new[] { "Id", "ApplicationId", "Name", "Region" },
                values: new object[] { new Guid("6a35823e-1c19-48d1-9afa-a484763369ce"), new Guid("a70247a8-4d49-43b3-94be-1ef6455734cb"), "Dev", "EU-West1" });

            migrationBuilder.InsertData(
                table: "Environments",
                columns: new[] { "Id", "ApplicationId", "Name", "Region" },
                values: new object[] { new Guid("6b4faf7a-b500-4a24-91e1-e187e2b356a0"), new Guid("626090f5-296d-4b8b-8a89-2557f773755b"), "Qa", "EU-West1" });

            migrationBuilder.InsertData(
                table: "Environments",
                columns: new[] { "Id", "ApplicationId", "Name", "Region" },
                values: new object[] { new Guid("75d92b56-aa0f-4fad-a289-4978129baef5"), new Guid("3e8e1230-f26e-4cd0-aecc-5d64637f9278"), "Qa", "EU-West1" });

            migrationBuilder.InsertData(
                table: "Environments",
                columns: new[] { "Id", "ApplicationId", "Name", "Region" },
                values: new object[] { new Guid("7ba2b7b2-eb4a-4193-b1f4-0f786a31bd03"), new Guid("a70247a8-4d49-43b3-94be-1ef6455734cb"), "Prod", "EU-West1" });

            migrationBuilder.InsertData(
                table: "Environments",
                columns: new[] { "Id", "ApplicationId", "Name", "Region" },
                values: new object[] { new Guid("94e02d01-f5f3-40b8-b249-9418f9bb716e"), new Guid("626090f5-296d-4b8b-8a89-2557f773755b"), "Prod", "EU-West1" });

            migrationBuilder.InsertData(
                table: "Environments",
                columns: new[] { "Id", "ApplicationId", "Name", "Region" },
                values: new object[] { new Guid("a4ae0560-1803-4a21-8e05-dfdd3a7d6a11"), new Guid("626090f5-296d-4b8b-8a89-2557f773755b"), "Dev", "EU-West1" });

            migrationBuilder.InsertData(
                table: "Environments",
                columns: new[] { "Id", "ApplicationId", "Name", "Region" },
                values: new object[] { new Guid("c6014659-421e-4e7a-a0a2-85cfdadbfce9"), new Guid("3e8e1230-f26e-4cd0-aecc-5d64637f9278"), "Prod", "EU-West1" });

            migrationBuilder.InsertData(
                table: "Environments",
                columns: new[] { "Id", "ApplicationId", "Name", "Region" },
                values: new object[] { new Guid("f3edd593-2816-4cda-9eb6-63f1a17f378e"), new Guid("a70247a8-4d49-43b3-94be-1ef6455734cb"), "Qa", "EU-West1" });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Active", "Data", "EnviromentId" },
                values: new object[] { new Guid("0a045b8a-5551-4366-acf6-aad1bdfdef57"), true, "{\"AllowedHosts\":\"*\",\"ConnectionStrings\":{\"Sqlite\":\"Data Source=.\\\\app.db\"},\"Logging\":{\"LogLevel\":{\"Default\":\"Warning\",\"Microsoft.AspNetCore\":\"Warning\",\"Sinch\":\"Information\"}}}", new Guid("c6014659-421e-4e7a-a0a2-85cfdadbfce9") });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Active", "Data", "EnviromentId" },
                values: new object[] { new Guid("0b80ceea-a545-4e65-a7a4-f4a470092b35"), true, "{\"AllowedHosts\":\"*\",\"ConnectionStrings\":{\"Sqlite\":\"Data Source=.\\\\app.db\"},\"Logging\":{\"LogLevel\":{\"Default\":\"Warning\",\"Microsoft.AspNetCore\":\"Warning\",\"Sinch\":\"Information\"}}}", new Guid("27c43d20-1289-4aed-8a6d-2573b8131a55") });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Active", "Data", "EnviromentId" },
                values: new object[] { new Guid("0ba6815e-3a32-4596-a998-e142ef7a1a15"), true, "{\"AllowedHosts\":\"*\",\"ConnectionStrings\":{\"Sqlite\":\"Data Source=.\\\\app.db\"},\"Logging\":{\"LogLevel\":{\"Default\":\"Warning\",\"Microsoft.AspNetCore\":\"Warning\",\"Sinch\":\"Information\"}}}", new Guid("a4ae0560-1803-4a21-8e05-dfdd3a7d6a11") });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Active", "Data", "EnviromentId" },
                values: new object[] { new Guid("20040139-5c21-4175-b0f8-a4b37b045a37"), true, "{\"AllowedHosts\":\"*\",\"ConnectionStrings\":{\"Sqlite\":\"Data Source=.\\\\app.db\"},\"Logging\":{\"LogLevel\":{\"Default\":\"Warning\",\"Microsoft.AspNetCore\":\"Warning\",\"Sinch\":\"Information\"}}}", new Guid("0a75bc9e-470e-4468-a2f8-3a9dda933306") });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Active", "Data", "EnviromentId" },
                values: new object[] { new Guid("2449c283-b607-4029-8165-45779461ad72"), true, "{\"AllowedHosts\":\"*\",\"ConnectionStrings\":{\"Sqlite\":\"Data Source=.\\\\app.db\"},\"Logging\":{\"LogLevel\":{\"Default\":\"Warning\",\"Microsoft.AspNetCore\":\"Warning\",\"Sinch\":\"Information\"}}}", new Guid("75d92b56-aa0f-4fad-a289-4978129baef5") });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Active", "Data", "EnviromentId" },
                values: new object[] { new Guid("60668921-ba9d-4f1f-bd04-b2646e7679da"), true, "{\"AllowedHosts\":\"*\",\"ConnectionStrings\":{\"Sqlite\":\"Data Source=.\\\\app.db\"},\"Logging\":{\"LogLevel\":{\"Default\":\"Warning\",\"Microsoft.AspNetCore\":\"Warning\",\"Sinch\":\"Information\"}}}", new Guid("6a35823e-1c19-48d1-9afa-a484763369ce") });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Active", "Data", "EnviromentId" },
                values: new object[] { new Guid("6452ed7a-195a-4b9c-8395-aab6e24e6775"), true, "{\"AllowedHosts\":\"*\",\"ConnectionStrings\":{\"Sqlite\":\"Data Source=.\\\\app.db\"},\"Logging\":{\"LogLevel\":{\"Default\":\"Warning\",\"Microsoft.AspNetCore\":\"Warning\",\"Sinch\":\"Information\"}}}", new Guid("3773fe57-a236-49a5-9ad6-94f0189140e0") });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Active", "Data", "EnviromentId" },
                values: new object[] { new Guid("78dc480e-14f4-424e-825b-c8cb5a3b8df9"), true, "{\"AllowedHosts\":\"*\",\"ConnectionStrings\":{\"Sqlite\":\"Data Source=.\\\\app.db\"},\"Logging\":{\"LogLevel\":{\"Default\":\"Warning\",\"Microsoft.AspNetCore\":\"Warning\",\"Sinch\":\"Information\"}}}", new Guid("3c1cc7ed-944f-44ac-a05b-a63f8402f106") });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Active", "Data", "EnviromentId" },
                values: new object[] { new Guid("794cb141-a1a3-4ced-8e79-292e285a9b54"), true, "{\"AllowedHosts\":\"*\",\"ConnectionStrings\":{\"Sqlite\":\"Data Source=.\\\\app.db\"},\"Logging\":{\"LogLevel\":{\"Default\":\"Warning\",\"Microsoft.AspNetCore\":\"Warning\",\"Sinch\":\"Information\"}}}", new Guid("267a7710-7a87-4c3d-926f-910776adfda7") });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Active", "Data", "EnviromentId" },
                values: new object[] { new Guid("7c84dddc-530b-4489-93ad-5cc6299b0749"), true, "{\"AllowedHosts\":\"*\",\"ConnectionStrings\":{\"Sqlite\":\"Data Source=.\\\\app.db\"},\"Logging\":{\"LogLevel\":{\"Default\":\"Warning\",\"Microsoft.AspNetCore\":\"Warning\",\"Sinch\":\"Information\"}}}", new Guid("7ba2b7b2-eb4a-4193-b1f4-0f786a31bd03") });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Active", "Data", "EnviromentId" },
                values: new object[] { new Guid("852712a9-9478-4e13-9e37-159ce2bdbf04"), true, "{\"AllowedHosts\":\"*\",\"ConnectionStrings\":{\"Sqlite\":\"Data Source=.\\\\app.db\"},\"Logging\":{\"LogLevel\":{\"Default\":\"Warning\",\"Microsoft.AspNetCore\":\"Warning\",\"Sinch\":\"Information\"}}}", new Guid("0985a1fc-b891-490a-9937-f6881d0cbc30") });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Active", "Data", "EnviromentId" },
                values: new object[] { new Guid("8951a51f-ca42-4226-afaa-378e6ab8c681"), true, "{\"AllowedHosts\":\"*\",\"ConnectionStrings\":{\"Sqlite\":\"Data Source=.\\\\app.db\"},\"Logging\":{\"LogLevel\":{\"Default\":\"Warning\",\"Microsoft.AspNetCore\":\"Warning\",\"Sinch\":\"Information\"}}}", new Guid("94e02d01-f5f3-40b8-b249-9418f9bb716e") });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Active", "Data", "EnviromentId" },
                values: new object[] { new Guid("8be9a73e-8d48-45d9-84c7-d0c9018ce260"), true, "{\"AllowedHosts\":\"*\",\"ConnectionStrings\":{\"Sqlite\":\"Data Source=.\\\\app.db\"},\"Logging\":{\"LogLevel\":{\"Default\":\"Warning\",\"Microsoft.AspNetCore\":\"Warning\",\"Sinch\":\"Information\"}}}", new Guid("1f9b6afe-5725-4ad0-9460-2abaed19ba36") });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Active", "Data", "EnviromentId" },
                values: new object[] { new Guid("9d20c762-f2a5-40d1-9b16-574779728d29"), true, "{\"AllowedHosts\":\"*\",\"ConnectionStrings\":{\"Sqlite\":\"Data Source=.\\\\app.db\"},\"Logging\":{\"LogLevel\":{\"Default\":\"Warning\",\"Microsoft.AspNetCore\":\"Warning\",\"Sinch\":\"Information\"}}}", new Guid("f3edd593-2816-4cda-9eb6-63f1a17f378e") });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Active", "Data", "EnviromentId" },
                values: new object[] { new Guid("a1ef1a77-3ada-4206-854f-7b8365aae79a"), true, "{\"AllowedHosts\":\"*\",\"ConnectionStrings\":{\"Sqlite\":\"Data Source=.\\\\app.db\"},\"Logging\":{\"LogLevel\":{\"Default\":\"Warning\",\"Microsoft.AspNetCore\":\"Warning\",\"Sinch\":\"Information\"}}}", new Guid("6b4faf7a-b500-4a24-91e1-e187e2b356a0") });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Active", "Data", "EnviromentId" },
                values: new object[] { new Guid("a805da67-1b3c-409c-82a2-01be1376c403"), true, "{\"AllowedHosts\":\"*\",\"ConnectionStrings\":{\"Sqlite\":\"Data Source=.\\\\app.db\"},\"Logging\":{\"LogLevel\":{\"Default\":\"Warning\",\"Microsoft.AspNetCore\":\"Warning\",\"Sinch\":\"Information\"}}}", new Guid("1a884483-a7a8-4c45-b617-75ecfa62deb8") });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Active", "Data", "EnviromentId" },
                values: new object[] { new Guid("c2d6773e-c8c6-4f86-b26c-25b270df82a2"), true, "{\"AllowedHosts\":\"*\",\"ConnectionStrings\":{\"Sqlite\":\"Data Source=.\\\\app.db\"},\"Logging\":{\"LogLevel\":{\"Default\":\"Warning\",\"Microsoft.AspNetCore\":\"Warning\",\"Sinch\":\"Information\"}}}", new Guid("3acbb91d-6c21-43f2-b246-0cadd1ad3063") });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Active", "Data", "EnviromentId" },
                values: new object[] { new Guid("cdfa52b6-7bc7-430f-9d09-7c5566705801"), true, "{\"AllowedHosts\":\"*\",\"ConnectionStrings\":{\"Sqlite\":\"Data Source=.\\\\app.db\"},\"Logging\":{\"LogLevel\":{\"Default\":\"Warning\",\"Microsoft.AspNetCore\":\"Warning\",\"Sinch\":\"Information\"}}}", new Guid("360cb85a-1d94-4de0-8cae-d5759f820490") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: new Guid("0a045b8a-5551-4366-acf6-aad1bdfdef57"));

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: new Guid("0b80ceea-a545-4e65-a7a4-f4a470092b35"));

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: new Guid("0ba6815e-3a32-4596-a998-e142ef7a1a15"));

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: new Guid("20040139-5c21-4175-b0f8-a4b37b045a37"));

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: new Guid("2449c283-b607-4029-8165-45779461ad72"));

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: new Guid("60668921-ba9d-4f1f-bd04-b2646e7679da"));

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: new Guid("6452ed7a-195a-4b9c-8395-aab6e24e6775"));

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: new Guid("78dc480e-14f4-424e-825b-c8cb5a3b8df9"));

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: new Guid("794cb141-a1a3-4ced-8e79-292e285a9b54"));

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: new Guid("7c84dddc-530b-4489-93ad-5cc6299b0749"));

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: new Guid("852712a9-9478-4e13-9e37-159ce2bdbf04"));

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: new Guid("8951a51f-ca42-4226-afaa-378e6ab8c681"));

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: new Guid("8be9a73e-8d48-45d9-84c7-d0c9018ce260"));

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: new Guid("9d20c762-f2a5-40d1-9b16-574779728d29"));

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: new Guid("a1ef1a77-3ada-4206-854f-7b8365aae79a"));

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: new Guid("a805da67-1b3c-409c-82a2-01be1376c403"));

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: new Guid("c2d6773e-c8c6-4f86-b26c-25b270df82a2"));

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: new Guid("cdfa52b6-7bc7-430f-9d09-7c5566705801"));

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: new Guid("0985a1fc-b891-490a-9937-f6881d0cbc30"));

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: new Guid("0a75bc9e-470e-4468-a2f8-3a9dda933306"));

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: new Guid("1a884483-a7a8-4c45-b617-75ecfa62deb8"));

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: new Guid("1f9b6afe-5725-4ad0-9460-2abaed19ba36"));

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: new Guid("267a7710-7a87-4c3d-926f-910776adfda7"));

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: new Guid("27c43d20-1289-4aed-8a6d-2573b8131a55"));

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: new Guid("360cb85a-1d94-4de0-8cae-d5759f820490"));

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: new Guid("3773fe57-a236-49a5-9ad6-94f0189140e0"));

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: new Guid("3acbb91d-6c21-43f2-b246-0cadd1ad3063"));

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: new Guid("3c1cc7ed-944f-44ac-a05b-a63f8402f106"));

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: new Guid("6a35823e-1c19-48d1-9afa-a484763369ce"));

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: new Guid("6b4faf7a-b500-4a24-91e1-e187e2b356a0"));

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: new Guid("75d92b56-aa0f-4fad-a289-4978129baef5"));

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: new Guid("7ba2b7b2-eb4a-4193-b1f4-0f786a31bd03"));

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: new Guid("94e02d01-f5f3-40b8-b249-9418f9bb716e"));

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: new Guid("a4ae0560-1803-4a21-8e05-dfdd3a7d6a11"));

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: new Guid("c6014659-421e-4e7a-a0a2-85cfdadbfce9"));

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: new Guid("f3edd593-2816-4cda-9eb6-63f1a17f378e"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("3ab55dd4-eb05-4355-b657-219fd3f50667"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("3e8e1230-f26e-4cd0-aecc-5d64637f9278"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("4ec370a1-1ccf-489b-bf39-c3580356f407"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("626090f5-296d-4b8b-8a89-2557f773755b"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("a70247a8-4d49-43b3-94be-1ef6455734cb"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("a75017e9-70f7-4363-8d73-1b8f306c2008"));
        }
    }
}
