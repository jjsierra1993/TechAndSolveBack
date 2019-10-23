using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace ApiFile.FileProcess
{
    // method for process file
    public interface IProcessFile
    {
        MemoryStream FileProcess(IFormFile file);
        int CalculateTrips(List<int> elements);
    }
}