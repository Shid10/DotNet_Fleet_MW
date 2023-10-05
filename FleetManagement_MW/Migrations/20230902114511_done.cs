using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetManagement_MW.Migrations
{
    /// <inheritdoc />
    public partial class done : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerMasters",
                columns: table => new
                {
                    customerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creditCardType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    drivingLicence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dlIssuedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dlValidThrough = table.Column<DateTime>(type: "datetime2", nullable: false),
                    passportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passportIssuedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passportValidUpto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMasters", x => x.customerId);
                });

            migrationBuilder.CreateTable(
                name: "StateMasters",
                columns: table => new
                {
                    stateId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateMasters", x => x.stateId);
                });

            migrationBuilder.CreateTable(
                name: "CityMasters",
                columns: table => new
                {
                    cityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stateId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityMasters", x => x.cityId);
                    table.ForeignKey(
                        name: "FK_CityMasters_StateMasters_stateId",
                        column: x => x.stateId,
                        principalTable: "StateMasters",
                        principalColumn: "stateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HubMasters",
                columns: table => new
                {
                    hubId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hubName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hubAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cityId = table.Column<long>(type: "bigint", nullable: false),
                    stateId = table.Column<long>(type: "bigint", nullable: false),
                    hubPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    openingHours = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HubMasters", x => x.hubId);
                    table.ForeignKey(
                        name: "FK_HubMasters_CityMasters_cityId",
                        column: x => x.cityId,
                        principalTable: "CityMasters",
                        principalColumn: "cityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HubMasters_StateMasters_stateId",
                        column: x => x.stateId,
                        principalTable: "StateMasters",
                        principalColumn: "stateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AirportMasters",
                columns: table => new
                {
                    airportId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    airportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cityId = table.Column<long>(type: "bigint", nullable: false),
                    stateId = table.Column<long>(type: "bigint", nullable: false),
                    hubId = table.Column<long>(type: "bigint", nullable: false),
                    airportCode = table.Column<long>(type: "bigint", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    openingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    closingTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportMasters", x => x.airportId);
                    table.ForeignKey(
                        name: "FK_AirportMasters_CityMasters_cityId",
                        column: x => x.cityId,
                        principalTable: "CityMasters",
                        principalColumn: "cityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AirportMasters_HubMasters_hubId",
                        column: x => x.hubId,
                        principalTable: "HubMasters",
                        principalColumn: "hubId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AirportMasters_StateMasters_stateId",
                        column: x => x.stateId,
                        principalTable: "StateMasters",
                        principalColumn: "stateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarTypeMasters",
                columns: table => new
                {
                    carTypeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dailyRate = table.Column<double>(type: "float", nullable: false),
                    hubId = table.Column<long>(type: "bigint", nullable: false),
                    weeklyRate = table.Column<double>(type: "float", nullable: false),
                    monthlyRate = table.Column<double>(type: "float", nullable: false),
                    imagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarTypeMasters", x => x.carTypeId);
                    table.ForeignKey(
                        name: "FK_CarTypeMasters_HubMasters_hubId",
                        column: x => x.hubId,
                        principalTable: "HubMasters",
                        principalColumn: "hubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookingHeaderReservations",
                columns: table => new
                {
                    bookingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    customerId = table.Column<long>(type: "bigint", nullable: false),
                    bookingStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bookingEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    carTypeId = table.Column<long>(type: "bigint", nullable: false),
                    custDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dailyRate = table.Column<double>(type: "float", nullable: false),
                    weeklyRate = table.Column<double>(type: "float", nullable: false),
                    monthlyRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingHeaderReservations", x => x.bookingId);
                    table.ForeignKey(
                        name: "FK_BookingHeaderReservations_CarTypeMasters_carTypeId",
                        column: x => x.carTypeId,
                        principalTable: "CarTypeMasters",
                        principalColumn: "carTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookingHeaderReservations_CustomerMasters_customerId",
                        column: x => x.customerId,
                        principalTable: "CustomerMasters",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarMasters",
                columns: table => new
                {
                    carId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carTypeId = table.Column<long>(type: "bigint", nullable: false),
                    carFuelCapacity = table.Column<double>(type: "float", nullable: false),
                    hubId = table.Column<long>(type: "bigint", nullable: false),
                    isAvailable = table.Column<bool>(type: "bit", nullable: false),
                    maintenanceDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    carCurrentFuelStatus = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarMasters", x => x.carId);
                    table.ForeignKey(
                        name: "FK_CarMasters_CarTypeMasters_carTypeId",
                        column: x => x.carTypeId,
                        principalTable: "CarTypeMasters",
                        principalColumn: "carTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarMasters_HubMasters_hubId",
                        column: x => x.hubId,
                        principalTable: "HubMasters",
                        principalColumn: "hubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MembershipRegistrations",
                columns: table => new
                {
                    memRegId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerId = table.Column<long>(type: "bigint", nullable: false),
                    carTypeId = table.Column<long>(type: "bigint", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipRegistrations", x => x.memRegId);
                    table.ForeignKey(
                        name: "FK_MembershipRegistrations_CarTypeMasters_carTypeId",
                        column: x => x.carTypeId,
                        principalTable: "CarTypeMasters",
                        principalColumn: "carTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MembershipRegistrations_CustomerMasters_customerId",
                        column: x => x.customerId,
                        principalTable: "CustomerMasters",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AddOnMasters",
                columns: table => new
                {
                    addOnId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    addOnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addOnRate = table.Column<double>(type: "float", nullable: false),
                    rateValidity = table.Column<DateTime>(type: "datetime2", nullable: false),
                    carId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddOnMasters", x => x.addOnId);
                    table.ForeignKey(
                        name: "FK_AddOnMasters_CarMasters_carId",
                        column: x => x.carId,
                        principalTable: "CarMasters",
                        principalColumn: "carId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceHeaderTableHandovers",
                columns: table => new
                {
                    invoiceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoiceDate = table.Column<DateTime>(type: "Date", nullable: false),
                    bookingId = table.Column<long>(type: "bigint", nullable: false),
                    customerId = table.Column<long>(type: "bigint", nullable: false),
                    handoverDate = table.Column<DateTime>(type: "Date", nullable: false),
                    carId = table.Column<long>(type: "bigint", nullable: false),
                    returnDate = table.Column<DateTime>(type: "Date", nullable: false),
                    rentalAmt = table.Column<double>(type: "float", nullable: false),
                    totalAddonAmt = table.Column<double>(type: "float", nullable: false),
                    totalAmt = table.Column<double>(type: "float", nullable: false),
                    customerDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    invoiceRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceHeaderTableHandovers", x => x.invoiceId);
                    table.ForeignKey(
                        name: "FK_InvoiceHeaderTableHandovers_BookingHeaderReservations_bookingId",
                        column: x => x.bookingId,
                        principalTable: "BookingHeaderReservations",
                        principalColumn: "bookingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceHeaderTableHandovers_CarMasters_carId",
                        column: x => x.carId,
                        principalTable: "CarMasters",
                        principalColumn: "carId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceHeaderTableHandovers_CustomerMasters_customerId",
                        column: x => x.customerId,
                        principalTable: "CustomerMasters",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    bookingDetailsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookingId = table.Column<long>(type: "bigint", nullable: false),
                    addOnId = table.Column<long>(type: "bigint", nullable: false),
                    addOnRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => x.bookingDetailsId);
                    table.ForeignKey(
                        name: "FK_BookingDetails_AddOnMasters_addOnId",
                        column: x => x.addOnId,
                        principalTable: "AddOnMasters",
                        principalColumn: "addOnId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookingDetails_BookingHeaderReservations_bookingId",
                        column: x => x.bookingId,
                        principalTable: "BookingHeaderReservations",
                        principalColumn: "bookingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetailTableReturns",
                columns: table => new
                {
                    invoiceDetailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoiceId = table.Column<long>(type: "bigint", nullable: false),
                    addOnId = table.Column<long>(type: "bigint", nullable: false),
                    addOnAmt = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetailTableReturns", x => x.invoiceDetailId);
                    table.ForeignKey(
                        name: "FK_InvoiceDetailTableReturns_AddOnMasters_addOnId",
                        column: x => x.addOnId,
                        principalTable: "AddOnMasters",
                        principalColumn: "addOnId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetailTableReturns_InvoiceHeaderTableHandovers_invoiceId",
                        column: x => x.invoiceId,
                        principalTable: "InvoiceHeaderTableHandovers",
                        principalColumn: "invoiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddOnMasters_carId",
                table: "AddOnMasters",
                column: "carId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportMasters_cityId",
                table: "AirportMasters",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportMasters_hubId",
                table: "AirportMasters",
                column: "hubId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportMasters_stateId",
                table: "AirportMasters",
                column: "stateId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_addOnId",
                table: "BookingDetails",
                column: "addOnId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_bookingId",
                table: "BookingDetails",
                column: "bookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHeaderReservations_carTypeId",
                table: "BookingHeaderReservations",
                column: "carTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHeaderReservations_customerId",
                table: "BookingHeaderReservations",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_CarMasters_carTypeId",
                table: "CarMasters",
                column: "carTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarMasters_hubId",
                table: "CarMasters",
                column: "hubId");

            migrationBuilder.CreateIndex(
                name: "IX_CarTypeMasters_hubId",
                table: "CarTypeMasters",
                column: "hubId");

            migrationBuilder.CreateIndex(
                name: "IX_CityMasters_stateId",
                table: "CityMasters",
                column: "stateId");

            migrationBuilder.CreateIndex(
                name: "IX_HubMasters_cityId",
                table: "HubMasters",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_HubMasters_stateId",
                table: "HubMasters",
                column: "stateId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetailTableReturns_addOnId",
                table: "InvoiceDetailTableReturns",
                column: "addOnId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetailTableReturns_invoiceId",
                table: "InvoiceDetailTableReturns",
                column: "invoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeaderTableHandovers_bookingId",
                table: "InvoiceHeaderTableHandovers",
                column: "bookingId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeaderTableHandovers_carId",
                table: "InvoiceHeaderTableHandovers",
                column: "carId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeaderTableHandovers_customerId",
                table: "InvoiceHeaderTableHandovers",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipRegistrations_carTypeId",
                table: "MembershipRegistrations",
                column: "carTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipRegistrations_customerId",
                table: "MembershipRegistrations",
                column: "customerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirportMasters");

            migrationBuilder.DropTable(
                name: "BookingDetails");

            migrationBuilder.DropTable(
                name: "InvoiceDetailTableReturns");

            migrationBuilder.DropTable(
                name: "MembershipRegistrations");

            migrationBuilder.DropTable(
                name: "AddOnMasters");

            migrationBuilder.DropTable(
                name: "InvoiceHeaderTableHandovers");

            migrationBuilder.DropTable(
                name: "BookingHeaderReservations");

            migrationBuilder.DropTable(
                name: "CarMasters");

            migrationBuilder.DropTable(
                name: "CustomerMasters");

            migrationBuilder.DropTable(
                name: "CarTypeMasters");

            migrationBuilder.DropTable(
                name: "HubMasters");

            migrationBuilder.DropTable(
                name: "CityMasters");

            migrationBuilder.DropTable(
                name: "StateMasters");
        }
    }
}
