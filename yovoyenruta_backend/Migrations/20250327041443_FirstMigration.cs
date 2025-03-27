using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yovoyenruta_backend.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "achievements",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_achievements", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "certifications",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_certifications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "features",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    feature = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_features", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "terminals",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_terminals", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "routes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    origin = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    destination = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    zone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    terminal_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_routes", x => x.id);
                    table.ForeignKey(
                        name: "FK_routes_terminals_terminal_id",
                        column: x => x.terminal_id,
                        principalTable: "terminals",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    license_plate = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    model = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    capacity = table.Column<int>(type: "int", nullable: true),
                    size = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    terminal_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.id);
                    table.ForeignKey(
                        name: "FK_vehicles_terminals_terminal_id",
                        column: x => x.terminal_id,
                        principalTable: "terminals",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_type_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    enrollment_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_user_types_user_type_id",
                        column: x => x.user_type_id,
                        principalTable: "user_types",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "maintenances",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    vehicle_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    scheduled_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    actual_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maintenances", x => x.id);
                    table.ForeignKey(
                        name: "FK_maintenances_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "shifts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    vehicle_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    route_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    scheduled_start = table.Column<DateTime>(type: "datetime", nullable: true),
                    scheduled_end = table.Column<DateTime>(type: "datetime", nullable: true),
                    actual_start = table.Column<DateTime>(type: "datetime", nullable: true),
                    actual_end = table.Column<DateTime>(type: "datetime", nullable: true),
                    attendance_status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    auto_assigned = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shifts", x => x.id);
                    table.ForeignKey(
                        name: "FK_shifts_routes_route_id",
                        column: x => x.route_id,
                        principalTable: "routes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_shifts_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "vehicle_availability",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    vehicle_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    day_of_week = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    start_time = table.Column<TimeOnly>(type: "time", nullable: true),
                    end_time = table.Column<TimeOnly>(type: "time", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_availability", x => x.id);
                    table.ForeignKey(
                        name: "FK_vehicle_availability_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "vehicle_features",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    vehicle_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    feature_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_features", x => x.id);
                    table.ForeignKey(
                        name: "FK_vehicle_features_features_feature_id",
                        column: x => x.feature_id,
                        principalTable: "features",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_vehicle_features_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "operators",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    shift_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    operator_number = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    service_zone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    years_experience = table.Column<int>(type: "int", nullable: true),
                    current_status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    salary = table.Column<double>(type: "float", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operators", x => x.id);
                    table.ForeignKey(
                        name: "FK_operators_shifts_shift_id",
                        column: x => x.shift_id,
                        principalTable: "shifts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_operators_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "assignment_log",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    route_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    vehicle_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    operator_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    date = table.Column<DateTime>(type: "datetime", nullable: true),
                    reason = table.Column<string>(type: "text", nullable: true),
                    result = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assignment_log", x => x.id);
                    table.ForeignKey(
                        name: "FK_assignment_log_operators_operator_id",
                        column: x => x.operator_id,
                        principalTable: "operators",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_assignment_log_routes_route_id",
                        column: x => x.route_id,
                        principalTable: "routes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_assignment_log_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "operator_achievements",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    operator_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    achievement_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    obtained_date = table.Column<DateOnly>(type: "date", nullable: true),
                    percentage = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operator_achievements", x => x.id);
                    table.ForeignKey(
                        name: "FK_operator_achievements_achievements_achievement_id",
                        column: x => x.achievement_id,
                        principalTable: "achievements",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_operator_achievements_operators_operator_id",
                        column: x => x.operator_id,
                        principalTable: "operators",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "operator_certifications",
                columns: table => new
                {
                    operator_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    certification_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    obtained_date = table.Column<DateOnly>(type: "date", nullable: true),
                    is_valid = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_operator_certifications_certifications_certification_id",
                        column: x => x.certification_id,
                        principalTable: "certifications",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_operator_certifications_operators_operator_id",
                        column: x => x.operator_id,
                        principalTable: "operators",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "operator_preferences",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    operator_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    route_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    priority = table.Column<int>(type: "int", nullable: true),
                    comments = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operator_preferences", x => x.id);
                    table.ForeignKey(
                        name: "FK_operator_preferences_operators_operator_id",
                        column: x => x.operator_id,
                        principalTable: "operators",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_operator_preferences_routes_route_id",
                        column: x => x.route_id,
                        principalTable: "routes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ratings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    operator_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    stars = table.Column<int>(type: "int", nullable: true),
                    comment = table.Column<string>(type: "text", nullable: true),
                    waiting_time_minutes = table.Column<int>(type: "int", nullable: true),
                    date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratings", x => x.id);
                    table.ForeignKey(
                        name: "FK_ratings_operators_operator_id",
                        column: x => x.operator_id,
                        principalTable: "operators",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ratings_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "trips",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    operator_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    vehicle_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    route_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    start_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    end_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trips", x => x.id);
                    table.ForeignKey(
                        name: "FK_trips_operators_operator_id",
                        column: x => x.operator_id,
                        principalTable: "operators",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_trips_routes_route_id",
                        column: x => x.route_id,
                        principalTable: "routes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_trips_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "incidents",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    trip_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    details = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incidents", x => x.id);
                    table.ForeignKey(
                        name: "FK_incidents_trips_trip_id",
                        column: x => x.trip_id,
                        principalTable: "trips",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_assignment_log_operator_id",
                table: "assignment_log",
                column: "operator_id");

            migrationBuilder.CreateIndex(
                name: "IX_assignment_log_route_id",
                table: "assignment_log",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "IX_assignment_log_vehicle_id",
                table: "assignment_log",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "UQ__incident__302A5D9F281CDF4B",
                table: "incidents",
                column: "trip_id",
                unique: true,
                filter: "[trip_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_maintenances_vehicle_id",
                table: "maintenances",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_operator_achievements_achievement_id",
                table: "operator_achievements",
                column: "achievement_id");

            migrationBuilder.CreateIndex(
                name: "IX_operator_achievements_operator_id",
                table: "operator_achievements",
                column: "operator_id");

            migrationBuilder.CreateIndex(
                name: "IX_operator_certifications_certification_id",
                table: "operator_certifications",
                column: "certification_id");

            migrationBuilder.CreateIndex(
                name: "IX_operator_certifications_operator_id",
                table: "operator_certifications",
                column: "operator_id");

            migrationBuilder.CreateIndex(
                name: "IX_operator_preferences_operator_id",
                table: "operator_preferences",
                column: "operator_id");

            migrationBuilder.CreateIndex(
                name: "IX_operator_preferences_route_id",
                table: "operator_preferences",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "IX_operators_shift_id",
                table: "operators",
                column: "shift_id");

            migrationBuilder.CreateIndex(
                name: "IX_operators_user_id",
                table: "operators",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_operator_id",
                table: "ratings",
                column: "operator_id");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_user_id",
                table: "ratings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_routes_terminal_id",
                table: "routes",
                column: "terminal_id");

            migrationBuilder.CreateIndex(
                name: "IX_shifts_route_id",
                table: "shifts",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "IX_shifts_vehicle_id",
                table: "shifts",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_trips_operator_id",
                table: "trips",
                column: "operator_id");

            migrationBuilder.CreateIndex(
                name: "IX_trips_route_id",
                table: "trips",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "IX_trips_vehicle_id",
                table: "trips",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_user_type_id",
                table: "users",
                column: "user_type_id");

            migrationBuilder.CreateIndex(
                name: "UQ__users__AB6E6164EA563539",
                table: "users",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_availability_vehicle_id",
                table: "vehicle_availability",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_features_feature_id",
                table: "vehicle_features",
                column: "feature_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_features_vehicle_id",
                table: "vehicle_features",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_terminal_id",
                table: "vehicles",
                column: "terminal_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assignment_log");

            migrationBuilder.DropTable(
                name: "incidents");

            migrationBuilder.DropTable(
                name: "maintenances");

            migrationBuilder.DropTable(
                name: "operator_achievements");

            migrationBuilder.DropTable(
                name: "operator_certifications");

            migrationBuilder.DropTable(
                name: "operator_preferences");

            migrationBuilder.DropTable(
                name: "ratings");

            migrationBuilder.DropTable(
                name: "vehicle_availability");

            migrationBuilder.DropTable(
                name: "vehicle_features");

            migrationBuilder.DropTable(
                name: "trips");

            migrationBuilder.DropTable(
                name: "achievements");

            migrationBuilder.DropTable(
                name: "certifications");

            migrationBuilder.DropTable(
                name: "features");

            migrationBuilder.DropTable(
                name: "operators");

            migrationBuilder.DropTable(
                name: "shifts");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "routes");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "user_types");

            migrationBuilder.DropTable(
                name: "terminals");
        }
    }
}
