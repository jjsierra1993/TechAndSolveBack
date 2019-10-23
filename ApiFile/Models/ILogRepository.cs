
using System.Threading.Tasks;

namespace ApiFile.Models
{
    //method for modify data in db
    public interface ILogRepository
    {
         Task Add(FileText trace);
    }
}