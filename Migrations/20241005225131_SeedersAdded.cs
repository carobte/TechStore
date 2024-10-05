using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechStore.Migrations
{
    /// <inheritdoc />
    public partial class SeedersAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "powerful desktop computers designed for both home and professional use. From basic models to advanced workstations for intensive tasks, find the right fit for your needs.", "desktop" },
                    { 2, "discover the latest smartphones with cutting-edge technology. From flagship models to budget-friendly options, we offer devices for every lifestyle", "mobile" },
                    { 3, "essential tech accessories, including chargers, cases, keyboards, headphones, and more to enhance your experience", "accesories" },
                    { 4, "software solutions for all your needs, from operating systems and office suites to design, development, and digital security tools.", "software" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "employee" },
                    { 3, "client" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "category_id", "description", "name", "price", "stock" },
                values: new object[,]
                {
                    { 1, 1, "powerful desktop for gaming with the latest hardware.", "gaming desktop", 1500.00m, 30 },
                    { 2, 1, "desktop optimized for high-performance tasks like video editing.", "workstation desktop", 1800.00m, 15 },
                    { 3, 1, "compact desktop for home or office use.", "compact desktop", 600.00m, 60 },
                    { 4, 1, "all-in-one desktop with a sleek design, perfect for space-saving.", "all-in-one desktop", 1200.00m, 40 },
                    { 5, 1, "affordable desktop ideal for basic tasks and everyday use.", "budget desktop", 400.00m, 100 },
                    { 6, 2, "high-end smartphone with the latest technology and camera.", "flagship smartphone", 1000.00m, 50 },
                    { 7, 2, "affordable smartphone with all the essential features.", "budget smartphone", 200.00m, 150 },
                    { 8, 2, "smartphone offering a great balance of performance and price.", "mid-range smartphone", 500.00m, 100 },
                    { 9, 2, "smartphone built for mobile gaming with enhanced graphics.", "gaming smartphone", 800.00m, 40 },
                    { 10, 2, "durable smartphone designed for tough environments.", "rugged smartphone", 600.00m, 70 },
                    { 11, 3, "ergonomic wireless mouse with long battery life.", "wireless mouse", 25.00m, 200 },
                    { 12, 3, "high-quality mechanical keyboard for precision typing.", "mechanical keyboard", 100.00m, 150 },
                    { 13, 3, "smartwatch with fitness tracking and notification features.", "smartwatch", 150.00m, 80 },
                    { 14, 3, "compact wireless earbuds with noise-cancelling technology.", "wireless earbuds", 75.00m, 250 },
                    { 15, 3, "multi-port usb-c hub for enhanced connectivity.", "usb-c hub", 50.00m, 180 },
                    { 16, 4, "comprehensive antivirus software for real-time protection.", "antivirus software", 40.00m, 300 },
                    { 17, 4, "complete office suite including word processing and spreadsheets.", "office suite", 120.00m, 150 },
                    { 18, 4, "professional-grade photo editing software with advanced tools.", "photo editing software", 200.00m, 80 },
                    { 19, 4, "easy-to-use accounting software for small businesses.", "accounting software", 100.00m, 100 },
                    { 20, 4, "powerful project management tool for teams and individuals.", "project management software", 150.00m, 90 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
