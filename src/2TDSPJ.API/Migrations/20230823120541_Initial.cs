using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2TDSPJ.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_HOSPEDE",
                columns: table => new
                {
                    HospedeId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Sobrenome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HOSPEDE", x => x.HospedeId);
                });

            migrationBuilder.CreateTable(
                name: "TB_QUARTO",
                columns: table => new
                {
                    QuartoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NumeroQuarto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PrecoPorNoite = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_QUARTO", x => x.QuartoId);
                });

            migrationBuilder.CreateTable(
                name: "TB_TIPOQUARTO",
                columns: table => new
                {
                    TipoQuartoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TIPOQUARTO", x => x.TipoQuartoId);
                });

            migrationBuilder.CreateTable(
                name: "TB_RESERVA",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataEntrada = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    HospedeId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    QuartoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RESERVA", x => x.ReservaId);
                    table.ForeignKey(
                        name: "FK_TB_RESERVA_TB_HOSPEDE_HospedeId",
                        column: x => x.HospedeId,
                        principalTable: "TB_HOSPEDE",
                        principalColumn: "HospedeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_RESERVA_TB_QUARTO_QuartoId",
                        column: x => x.QuartoId,
                        principalTable: "TB_QUARTO",
                        principalColumn: "QuartoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuartoTipoQuarto",
                columns: table => new
                {
                    QuartosQuartoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TipoQuartosTipoQuartoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuartoTipoQuarto", x => new { x.QuartosQuartoId, x.TipoQuartosTipoQuartoId });
                    table.ForeignKey(
                        name: "FK_QuartoTipoQuarto_TB_QUARTO_QuartosQuartoId",
                        column: x => x.QuartosQuartoId,
                        principalTable: "TB_QUARTO",
                        principalColumn: "QuartoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuartoTipoQuarto_TB_TIPOQUARTO_TipoQuartosTipoQuartoId",
                        column: x => x.TipoQuartosTipoQuartoId,
                        principalTable: "TB_TIPOQUARTO",
                        principalColumn: "TipoQuartoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_PAGAMENTO",
                columns: table => new
                {
                    PagamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataPagamento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    ReservaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PAGAMENTO", x => x.PagamentoId);
                    table.ForeignKey(
                        name: "FK_TB_PAGAMENTO_TB_RESERVA_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "TB_RESERVA",
                        principalColumn: "ReservaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuartoTipoQuarto_TipoQuartosTipoQuartoId",
                table: "QuartoTipoQuarto",
                column: "TipoQuartosTipoQuartoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PAGAMENTO_ReservaId",
                table: "TB_PAGAMENTO",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RESERVA_HospedeId",
                table: "TB_RESERVA",
                column: "HospedeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RESERVA_QuartoId",
                table: "TB_RESERVA",
                column: "QuartoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuartoTipoQuarto");

            migrationBuilder.DropTable(
                name: "TB_PAGAMENTO");

            migrationBuilder.DropTable(
                name: "TB_TIPOQUARTO");

            migrationBuilder.DropTable(
                name: "TB_RESERVA");

            migrationBuilder.DropTable(
                name: "TB_HOSPEDE");

            migrationBuilder.DropTable(
                name: "TB_QUARTO");
        }
    }
}
