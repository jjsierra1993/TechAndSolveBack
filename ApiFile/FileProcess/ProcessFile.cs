using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace ApiFile.FileProcess
{
    public class ProcessFile
    {
        protected IProcessFile process;

        public ProcessFile(IProcessFile _process)
        {
            this.process = _process;
        }

        public MemoryStream FileProcess(IFormFile file){
            return process.FileProcess(file);
        }

    }
}