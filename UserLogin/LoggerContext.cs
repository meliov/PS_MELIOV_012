using System.Data.Entity;
using UserLogin.Properties;

namespace UserLogin;

public class LoggerContext : DbContext
{
    public LoggerContext()
        : base(Settings.Default.DbConnect)
    { }
    
    public DbSet<Log> Logs { get; set; }
}