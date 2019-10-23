using Microsoft.EntityFrameworkCore;

namespace ApiFile.Models
{
    //Create context for Data base log
    public class LogContext : DbContext
    {
        public LogContext(DbContextOptions<LogContext> options) : base(options)
        {
        }

        public DbSet<FileText> LogTraces { get; set; }
    }
}