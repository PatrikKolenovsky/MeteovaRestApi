using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeteovaRestApi.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "comtype",
                columns: table => new
                {
                    ComTypeID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comtype", x => x.ComTypeID);
                });

            migrationBuilder.CreateTable(
                name: "devicename",
                columns: table => new
                {
                    DeviceNameID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devicename", x => x.DeviceNameID);
                });

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "maker",
                columns: table => new
                {
                    MakerID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maker", x => x.MakerID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_messages",
                columns: table => new
                {
                    messageID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    clientID = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    topic = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    message = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Enable = table.Column<bool>(nullable: true, defaultValueSql: "'1'"),
                    DateTime_created = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "'current_timestamp()'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.messageID);
                });

            migrationBuilder.CreateTable(
                name: "varname",
                columns: table => new
                {
                    VarNameID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_varname", x => x.VarNameID);
                });

            migrationBuilder.CreateTable(
                name: "vartype",
                columns: table => new
                {
                    VarTypeID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vartype", x => x.VarTypeID);
                });

            migrationBuilder.CreateTable(
                name: "device",
                columns: table => new
                {
                    DeviceID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeviceNameID = table.Column<int>(type: "int(11)", nullable: false),
                    IP = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Port = table.Column<int>(type: "int(11)", nullable: false),
                    ComServIP = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    ComServPort = table.Column<int>(type: "int(11)", nullable: false),
                    ComTypeID = table.Column<int>(type: "int(11)", nullable: false),
                    InUse = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_device", x => x.DeviceID);
                    table.ForeignKey(
                        name: "fk_DEVICE_COMTYPE1",
                        column: x => x.ComTypeID,
                        principalTable: "comtype",
                        principalColumn: "ComTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_DEVICE_DEVICENAME1",
                        column: x => x.DeviceNameID,
                        principalTable: "devicename",
                        principalColumn: "DeviceNameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "moduletype",
                columns: table => new
                {
                    ModuleTypeID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    MakerID = table.Column<int>(type: "int(11)", nullable: false),
                    Description = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moduletype", x => x.ModuleTypeID);
                    table.ForeignKey(
                        name: "fk_MODULETYPE_MAKER1",
                        column: x => x.MakerID,
                        principalTable: "maker",
                        principalColumn: "MakerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "module",
                columns: table => new
                {
                    ModuleID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    LocationID = table.Column<int>(type: "int(11)", nullable: false),
                    ModuleTypeID = table.Column<int>(type: "int(11)", nullable: false),
                    DeviceID = table.Column<int>(type: "int(11)", nullable: false),
                    Description = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_module", x => x.ModuleID);
                    table.ForeignKey(
                        name: "fk_MODULE_DEVICE1",
                        column: x => x.DeviceID,
                        principalTable: "device",
                        principalColumn: "DeviceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_MODULE_LOCATION1",
                        column: x => x.LocationID,
                        principalTable: "location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_MODULE_MODULETYPE1",
                        column: x => x.ModuleTypeID,
                        principalTable: "moduletype",
                        principalColumn: "ModuleTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vardef",
                columns: table => new
                {
                    VarDefID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ModuleTypeID = table.Column<int>(type: "int(11)", nullable: false),
                    VarNameID = table.Column<int>(type: "int(11)", nullable: false),
                    VarTypeID = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vardef", x => x.VarDefID);
                    table.ForeignKey(
                        name: "fk_VARDEF_MODULETYPE1",
                        column: x => x.ModuleTypeID,
                        principalTable: "moduletype",
                        principalColumn: "ModuleTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_VARDEF_VARNAME1",
                        column: x => x.VarNameID,
                        principalTable: "varname",
                        principalColumn: "VarNameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_VARDEF_VARTYPE1",
                        column: x => x.VarTypeID,
                        principalTable: "vartype",
                        principalColumn: "VarTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "variable",
                columns: table => new
                {
                    VariableID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Pub = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    ModuleID = table.Column<int>(type: "int(11)", nullable: false),
                    VarDefID = table.Column<int>(type: "int(11)", nullable: false),
                    Description = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_variable", x => x.VariableID);
                    table.ForeignKey(
                        name: "fk_VARIABLE_MODULE1",
                        column: x => x.ModuleID,
                        principalTable: "module",
                        principalColumn: "ModuleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_VARIABLE_VARDEF1",
                        column: x => x.VarDefID,
                        principalTable: "vardef",
                        principalColumn: "VarDefID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "valint",
                columns: table => new
                {
                    ValIntID = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VariableID = table.Column<int>(type: "int(11)", nullable: false),
                    Value = table.Column<int>(type: "int(11)", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp(3)", nullable: false, defaultValueSql: "'current_timestamp(3)'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_valint", x => x.ValIntID);
                    table.ForeignKey(
                        name: "fk_Int_Variable1",
                        column: x => x.VariableID,
                        principalTable: "variable",
                        principalColumn: "VariableID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "valreal",
                columns: table => new
                {
                    ValRealID = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VariableID = table.Column<int>(type: "int(11)", nullable: false),
                    Value = table.Column<double>(nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp(3)", nullable: false, defaultValueSql: "'current_timestamp(3)'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_valreal", x => x.ValRealID);
                    table.ForeignKey(
                        name: "fk_Real_Variable1",
                        column: x => x.VariableID,
                        principalTable: "variable",
                        principalColumn: "VariableID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "valstring",
                columns: table => new
                {
                    ValStringID = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VariableID = table.Column<int>(type: "int(11)", nullable: false),
                    Value = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Time = table.Column<DateTime>(type: "timestamp(3)", nullable: false, defaultValueSql: "'current_timestamp(3)'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_valstring", x => x.ValStringID);
                    table.ForeignKey(
                        name: "fk_VALSTRING_VARIABLE1",
                        column: x => x.VariableID,
                        principalTable: "variable",
                        principalColumn: "VariableID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "fk_DEVICE_COMTYPE1_idx",
                table: "device",
                column: "ComTypeID");

            migrationBuilder.CreateIndex(
                name: "fk_DEVICE_DEVICENAME1_idx",
                table: "device",
                column: "DeviceNameID");

            migrationBuilder.CreateIndex(
                name: "fk_MODULE_DEVICE1_idx",
                table: "module",
                column: "DeviceID");

            migrationBuilder.CreateIndex(
                name: "fk_MODULE_LOCATION1_idx",
                table: "module",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "fk_MODULE_MODULETYPE1_idx",
                table: "module",
                column: "ModuleTypeID");

            migrationBuilder.CreateIndex(
                name: "fk_MODULETYPE_MAKER1_idx",
                table: "moduletype",
                column: "MakerID");

            migrationBuilder.CreateIndex(
                name: "fk_Int_Variable1_idx",
                table: "valint",
                column: "VariableID");

            migrationBuilder.CreateIndex(
                name: "fk_Real_Variable1_idx",
                table: "valreal",
                column: "VariableID");

            migrationBuilder.CreateIndex(
                name: "fk_VALSTRING_VARIABLE1_idx",
                table: "valstring",
                column: "VariableID");

            migrationBuilder.CreateIndex(
                name: "fk_VARDEF_MODULETYPE1_idx",
                table: "vardef",
                column: "ModuleTypeID");

            migrationBuilder.CreateIndex(
                name: "fk_VARDEF_VARNAME1_idx",
                table: "vardef",
                column: "VarNameID");

            migrationBuilder.CreateIndex(
                name: "fk_VARDEF_VARTYPE1_idx",
                table: "vardef",
                column: "VarTypeID");

            migrationBuilder.CreateIndex(
                name: "fk_VARIABLE_MODULE1_idx",
                table: "variable",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "fk_VARIABLE_VARDEF1_idx",
                table: "variable",
                column: "VarDefID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_messages");

            migrationBuilder.DropTable(
                name: "valint");

            migrationBuilder.DropTable(
                name: "valreal");

            migrationBuilder.DropTable(
                name: "valstring");

            migrationBuilder.DropTable(
                name: "variable");

            migrationBuilder.DropTable(
                name: "module");

            migrationBuilder.DropTable(
                name: "vardef");

            migrationBuilder.DropTable(
                name: "device");

            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.DropTable(
                name: "moduletype");

            migrationBuilder.DropTable(
                name: "varname");

            migrationBuilder.DropTable(
                name: "vartype");

            migrationBuilder.DropTable(
                name: "comtype");

            migrationBuilder.DropTable(
                name: "devicename");

            migrationBuilder.DropTable(
                name: "maker");
        }
    }
}
