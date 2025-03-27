using Microsoft.EntityFrameworkCore;
using yovoyenruta_backend.Data.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievement> achievements { get; set; }

    public virtual DbSet<AssignmentLog> assignment_logs { get; set; }

    public virtual DbSet<Certification> certifications { get; set; }

    public virtual DbSet<Feature> features { get; set; }

    public virtual DbSet<Incident> incidents { get; set; }

    public virtual DbSet<Maintenance> maintenances { get; set; }

    public virtual DbSet<Operator> operators { get; set; }

    public virtual DbSet<OperatorAchievement> operator_achievements { get; set; }

    public virtual DbSet<OperatorCertification> operator_certifications { get; set; }

    public virtual DbSet<OperatorPreference> operator_preferences { get; set; }

    public virtual DbSet<Rating> ratings { get; set; }

    public virtual DbSet<yovoyenruta_backend.Data.Entities.Route> routes { get; set; }

    public virtual DbSet<Shift> shifts { get; set; }

    public virtual DbSet<Terminal> terminals { get; set; }

    public virtual DbSet<Trip> trips { get; set; }

    public virtual DbSet<User> users { get; set; }

    public virtual DbSet<UserType> user_types { get; set; }

    public virtual DbSet<Vehicle> vehicles { get; set; }

    public virtual DbSet<VehicleAvailability> vehicle_availabilities { get; set; }

    public virtual DbSet<VehicleFeature> vehicle_features { get; set; }
}