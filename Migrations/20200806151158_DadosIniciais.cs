using Microsoft.EntityFrameworkCore.Migrations;

namespace ProvaConceito.Migrations
{
    public partial class DadosIniciais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Perguntas",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Você gosta de testar aplicações?" },
                    { 2, "Você gosta de desenhar telas para as aplicações?" },
                    { 3, "Você gosta de aprender novas linguagens e frameworks?" },
                    { 4, "Qual das seguintes personalidades mais te inspira?" }
                });

            migrationBuilder.InsertData(
                table: "Profissoes",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "QA" },
                    { 2, "UX" },
                    { 3, "Desenvolvedor" }
                });

            migrationBuilder.InsertData(
                table: "Respostas",
                columns: new[] { "Id", "PerguntaId", "ProfissaoId", "Texto" },
                values: new object[,]
                {
                    { 1, 1, 1, "Sou fanático por testes!" },
                    { 4, 2, 1, "Não gosto de desenhos de telas!" },
                    { 7, 3, 1, "Acho legal usar frameworks para teste de aplicações." },
                    { 12, 4, 1, "Thomas Edison" },
                    { 2, 1, 2, "Gosto de testar idéias com o usuário!" },
                    { 5, 2, 2, "Acho incrível e me interesso em entender o usuário cada vez mais!" },
                    { 8, 3, 2, "Detesto trabalhar com tecnologias." },
                    { 11, 4, 2, "Steve Jobs" },
                    { 3, 1, 3, "Testar não é minha praia definitivamente!" },
                    { 6, 2, 3, "Até acho legal ver a concepção das telas!" },
                    { 9, 3, 3, "Acho fantástico!" },
                    { 10, 4, 3, "Bill Gates" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Respostas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Respostas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Respostas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Respostas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Respostas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Respostas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Respostas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Respostas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Respostas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Respostas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Respostas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Respostas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Profissoes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Profissoes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Profissoes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
