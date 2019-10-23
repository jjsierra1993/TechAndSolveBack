using System.Threading.Tasks;
using System;

namespace ApiFile.Models
{
    //This class use the context for save LogTrace.
    public class LogRepository : ILogRepository
    {
        private readonly LogContext _context;

        public LogRepository(LogContext context)
        {
            _context = context;
        }
        //This Method add trace in Table LogTrace
        public async Task Add(FileText trace)
        {
            _context.LogTraces.Add(trace);
            await _context.SaveChangesAsync();
        }
    }
}