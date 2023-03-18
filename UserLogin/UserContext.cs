using System.Data.Entity;
using UserLogin.Properties;

namespace UserLogin;

public class UserContext : DbContext
{
    public UserContext()
        : base(Settings.Default.DbConnect)
    { }
    
    public DbSet<User> Users { get; set; }
}