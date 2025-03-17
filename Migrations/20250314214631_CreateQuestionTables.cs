using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AmadeusAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateQuestionTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionOptions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Category", "Text" },
                values: new object[,]
                {
                    { 1, "Preferencia de destino", "¿Qué tipo de entorno prefieres para tus vacaciones?" },
                    { 2, "Preferencia de destino", "¿Te gustaría explorar un destino internacional o nacional?" },
                    { 3, "Preferencia climática", "¿Qué clima prefieres durante tus vacaciones?" },
                    { 4, "Preferencia climática", "¿Te molesta la lluvia en tus vacaciones?" },
                    { 5, "Preferencia de actividad", "¿Qué tipo de actividades prefieres hacer durante tus vacaciones?" },
                    { 6, "Preferencia de actividad", "¿Te gusta disfrutar de la gastronomía local durante tus viajes?" },
                    { 7, "Preferencia de alojamiento", "¿Qué tipo de alojamiento prefieres?" },
                    { 8, "Preferencia de alojamiento", "¿Te importa si el alojamiento está en el centro de la ciudad o prefieres las afueras?" },
                    { 9, "Duración del viaje", "¿Cuánto tiempo planeas quedarte de vacaciones?" },
                    { 10, "Duración del viaje", "¿Cuántos días de actividades intensas puedes disfrutar antes de necesitar un descanso?" },
                    { 11, "Edad", "¿Cuál es tu rango de edad?" }
                });

            migrationBuilder.InsertData(
                table: "QuestionOptions",
                columns: new[] { "Id", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 1, 1, "Playa" },
                    { 2, 1, "Montaña" },
                    { 3, 1, "Ciudad" },
                    { 4, 2, "Internacional" },
                    { 5, 2, "Nacional" },
                    { 6, 2, "Indiferente" },
                    { 7, 3, "Caluroso" },
                    { 8, 3, "Templado" },
                    { 9, 3, "Frío" },
                    { 10, 4, "Sí, prefiero clima seco" },
                    { 11, 4, "No me importa un poco de lluvia" },
                    { 12, 4, "Prefiero destinos con lluvias ocasionales" },
                    { 13, 5, "Deportes y aventuras" },
                    { 14, 5, "Cultura y museos" },
                    { 15, 5, "Relax y bienestar" },
                    { 16, 6, "Sí, es muy importante para mí" },
                    { 17, 6, "Me gusta probar cosas nuevas, pero no es lo principal" },
                    { 18, 6, "No, prefiero comida más familiar" },
                    { 19, 7, "Hotel de lujo" },
                    { 20, 7, "Hostal o albergue" },
                    { 21, 7, "Airbnb o apartamento" },
                    { 22, 8, "Centro de la ciudad" },
                    { 23, 8, "Afueras" },
                    { 24, 8, "Indiferente" },
                    { 25, 9, "Menos de una semana" },
                    { 26, 9, "Una a dos semanas" },
                    { 27, 9, "Más de dos semanas" },
                    { 28, 10, "1-2 días" },
                    { 29, 10, "3-5 días" },
                    { 30, 10, "Más de 5 días" },
                    { 31, 11, "Menos de 30 años" },
                    { 32, 11, "30-50 años" },
                    { 33, 11, "Más de 50 años" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionOptions_QuestionId",
                table: "QuestionOptions",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionOptions");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
