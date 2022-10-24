using DailyAppleAPI.Models;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace DailyAppleAPI.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> appUsers { get; set; } = null!;
        public DbSet<BluetoothDevice> bluetoothDevices { get; set; } = null!;
        public DbSet<EmergencyContact> emergencyContacts { get; set; } = null!;
        public DbSet<Patient> patients { get; set; } = null!;
        public DbSet<PatientBiometrics> patientBiometrics { get; set; } = null!;
        public DbSet<PatientInformation> patientsInformation { get; set; } = null!;
        public DbSet<Physician> physicians { get; set; } = null!;
        public DbSet<PhysicianPatient> physicianPatients { get; set; } = null!;
        public DbSet<Practice> practices { get; set; } = null!;
        public DbSet<Role> roles { get; set; } = null!;
        public DbSet<UserRole> userRoles { get; set; } = null!;

    }
}