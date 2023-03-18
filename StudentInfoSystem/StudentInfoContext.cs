using System.Data.Entity;
using UserLogin;
using WpfApp1.Properties;

namespace StudentInfoSystem;

public class StudentInfoContext : DbContext
{
    public StudentInfoContext()
        : base(Settings.Default.DbConnect)
    { }
    
    public DbSet<Student> Students { get; set; }
    public DbSet<User> Users { get; set; }
}