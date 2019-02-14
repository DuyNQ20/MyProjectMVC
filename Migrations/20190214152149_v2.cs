using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProjectMVC.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Image",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Image",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Delected",
                table: "Comment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "content",
                table: "Comment",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedBy", "Delected", "ModifiedAt", "ModifiedBy", "ProductId", "content" },
                values: new object[,]
                {
                    { 1, true, new DateTimeOffset(new DateTime(2019, 2, 14, 22, 21, 49, 241, DateTimeKind.Unspecified).AddTicks(8559), new TimeSpan(0, 7, 0, 0, 0)), "Quang Duy", true, new DateTimeOffset(new DateTime(2019, 2, 14, 22, 21, 49, 241, DateTimeKind.Unspecified).AddTicks(8572), new TimeSpan(0, 7, 0, 0, 0)), "Quang Duy", 1, "Nội dung bình luận 1 cho iphone" },
                    { 2, true, new DateTimeOffset(new DateTime(2019, 2, 14, 22, 21, 49, 241, DateTimeKind.Unspecified).AddTicks(8615), new TimeSpan(0, 7, 0, 0, 0)), "Quang Duy", false, new DateTimeOffset(new DateTime(2019, 2, 14, 22, 21, 49, 241, DateTimeKind.Unspecified).AddTicks(8619), new TimeSpan(0, 7, 0, 0, 0)), "Quang Duy", 1, "Nội dung bình luận 2 cho iphone" }
                });

            migrationBuilder.UpdateData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy" },
                values: new object[] { true, new DateTimeOffset(new DateTime(2019, 2, 14, 22, 21, 49, 234, DateTimeKind.Unspecified).AddTicks(7024), new TimeSpan(0, 7, 0, 0, 0)), "Quang Duy", new DateTimeOffset(new DateTime(2019, 2, 14, 22, 21, 49, 238, DateTimeKind.Unspecified).AddTicks(9236), new TimeSpan(0, 7, 0, 0, 0)), "Quang Duy" });

            migrationBuilder.UpdateData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Active", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy" },
                values: new object[] { true, new DateTimeOffset(new DateTime(2019, 2, 14, 22, 21, 49, 239, DateTimeKind.Unspecified).AddTicks(1631), new TimeSpan(0, 7, 0, 0, 0)), "Quang Duy", new DateTimeOffset(new DateTime(2019, 2, 14, 22, 21, 49, 239, DateTimeKind.Unspecified).AddTicks(1652), new TimeSpan(0, 7, 0, 0, 0)), "Quang Duy" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "CreatedAt", "CreatedBy", "Decriptions", "ModifiedAt", "ModifiedBy", "Specifications" },
                values: new object[] { true, new DateTimeOffset(new DateTime(2019, 2, 14, 22, 21, 49, 241, DateTimeKind.Unspecified).AddTicks(3684), new TimeSpan(0, 7, 0, 0, 0)), "Quang Duy", "Cuối cùng iPhone X cũng đã ra mắt trong sự kiện diễn ra rạng sáng nay (13/9) theo giờ Việt Nam. </br>Đây là sản phẩm được Apple tung ra để kỷ niệm 10 năm iPhone.", new DateTimeOffset(new DateTime(2019, 2, 14, 22, 21, 49, 241, DateTimeKind.Unspecified).AddTicks(3697), new TimeSpan(0, 7, 0, 0, 0)), "Quang Duy", "Nhà sản xuất:Apple </br>Hệ điều hành: iOS 11 </br>Kích thước:	143,6 x 70,9 x 7,7 mm </br>Trọng lượng: 174g </br>Ngày giới thiệu:	13 / 09 / 2017" });

            migrationBuilder.UpdateData(
                table: "Vendor",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy" },
                values: new object[] { true, new DateTimeOffset(new DateTime(2019, 2, 14, 22, 21, 49, 240, DateTimeKind.Unspecified).AddTicks(1304), new TimeSpan(0, 7, 0, 0, 0)), "Quang Duy", new DateTimeOffset(new DateTime(2019, 2, 14, 22, 21, 49, 240, DateTimeKind.Unspecified).AddTicks(1317), new TimeSpan(0, 7, 0, 0, 0)), "Quang Duy" });

            migrationBuilder.UpdateData(
                table: "Vendor",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Active", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy" },
                values: new object[] { true, new DateTimeOffset(new DateTime(2019, 2, 14, 22, 21, 49, 240, DateTimeKind.Unspecified).AddTicks(1359), new TimeSpan(0, 7, 0, 0, 0)), "Quang Duy", new DateTimeOffset(new DateTime(2019, 2, 14, 22, 21, 49, 240, DateTimeKind.Unspecified).AddTicks(1359), new TimeSpan(0, 7, 0, 0, 0)), "Quang Duy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "Delected",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "content",
                table: "Comment");

            migrationBuilder.UpdateData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy" },
                values: new object[] { false, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Active", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy" },
                values: new object[] { false, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "CreatedAt", "CreatedBy", "Decriptions", "ModifiedAt", "ModifiedBy", "Specifications" },
                values: new object[] { false, null, null, "Cuối cùng iPhone X cũng đã ra mắt trong sự kiện diễn ra rạng sáng nay (13/9) theo giờ Việt Nam. Đây là sản phẩm được Apple tung ra để kỷ niệm 10 năm iPhone.", null, null, "Nhà sản xuất:Apple Hệ điều hành: iOS 11 Kích thước:	143,6 x 70,9 x 7,7 mm Trọng lượng:174g Ngày giới thiệu:	13 / 09 / 2017" });

            migrationBuilder.UpdateData(
                table: "Vendor",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy" },
                values: new object[] { false, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Vendor",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Active", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy" },
                values: new object[] { false, null, null, null, null });
        }
    }
}
