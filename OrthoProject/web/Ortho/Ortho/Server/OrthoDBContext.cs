using Microsoft.EntityFrameworkCore;
using Ortho.Shared.Models;

namespace Ortho.Server
{
    public class OrthoDBContext : DbContext
    {
        private readonly string _connectionString;
        private bool bDesktopMode = false;

        public OrthoDBContext(DbContextOptions<OrthoDBContext> options) : base(options)
        {
        }

        public OrthoDBContext(string connectionString)
        {
            _connectionString = connectionString;
            bDesktopMode = true;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (bDesktopMode)
                optionsBuilder.UseNpgsql(_connectionString);
        }

        public DbSet<ConfigDemandSource> configDemandSources { get; set; }
        public DbSet<ConfigLabType> configLabTypes { get; set; }
        public DbSet<Scenario> scenarios { get; set; }
        public DbSet<AppUser> appUsers { get; set; }
        public DbSet<ConfigScenarioType> configScenarioTypes { get; set; }
        public DbSet<ExtCustomer> extCustomers { get; set; }
        public DbSet<Panel> panels { get; set; }
        public DbSet<ConfigOrthoAssay> configOrthoAssays { get; set; }
        public DbSet<PanelAssay> panelAssays { get; set; }
        public DbSet<DemandLISFile> demandLisFiles { get; set; }
        public DbSet<DemandFileColumnMapping> demandFileColumnMappings { get; set; }
        public DbSet<ConfigLISField> configLISFields { get; set; }
        public DbSet<DemandData> demandData { get; set; }

    }
}
