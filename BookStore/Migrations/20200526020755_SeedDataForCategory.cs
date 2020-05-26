using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class SeedDataForCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("category", new string[] {"id", "title", "parentId"}, new object[,]
            {
                {1, "Accessories", null },
                {2, "Arts & Photography", null },
                {3, "Biographies", null },
                {4, "Business & Money", null },
                {5, "Calendars", null },
                {6, "Children's Books", null },
                {7, "Comics", null },
                {8, "Cookbooks", null },
                {9, "Education", null },
                {10, "House Plants", null },
                {11, "Indoor Living", null },
                {12, "Perfomance Filters", null },
                {13, "House Plants", null },
                {14, "Shop", null },
                {15, "Saws", 14 },
                {16, "Concrete Tools", 14 },
                {17, "Drills", 14 },
                {18, "Sanders", 14 },
            });

            migrationBuilder.InsertData("categorybook", new string[] {"bookId", "categoryId"}, new object[,]
            {
                {1, 1 },
                {2, 2 },
                {3, 3 },
                {4, 4 },
                {5, 5 },
                {6, 6 },
                {7, 7 },
                {8, 8 },
                {9, 9 },
                {10, 10 },
                {11, 11 },
                {12, 12 },
                {13, 13 },
                {14, 14 },
                {15, 14 },
                {16, 5 },
                {17, 5 },
                {19, 5 },
                {20, 5 },
                {21, 4 },
                {22, 4 },
                {23, 4 },
                {24, 4 },
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM categorybook");
            migrationBuilder.DeleteData("category", "id", new object[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 15, 16, 17, 18, 14
            });
        }
    }
}
