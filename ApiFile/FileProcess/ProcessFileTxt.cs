using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace ApiFile.FileProcess
{
    //This class use the context for save LogTrace.
    public class ProcessFileTxt : IProcessFile
    {
        //Processed file for get trips file.
        public MemoryStream FileProcess(IFormFile textFile)
        {

            var resultBuilder = new List<string>();
            using (var fileReader = new StreamReader(textFile.OpenReadStream()))
            {
                while (fileReader.Peek() >= 0)
                    resultBuilder.Add(fileReader.ReadLine().Replace("/n",""));
            }

            var fileRead = resultBuilder;
            fileRead.Remove(string.Empty);
            var file = fileRead.ConvertAll(int.Parse);

            int numberDay = 0;
            List<string> resultado = new List<string>();
            int n;

            if (file.Any() && file.First() <= 500)
            {
                for (int t = 1; t < file.Count; t++)
                {
                    numberDay++;
                    var countElements = file[t];

                    if (countElements <= 100)
                    {
                        List<int> sizeElement = new List<int>();

                        for (n = t + 1; n <= (t + countElements); n++)
                        {
                            if (file[n] <= 100)
                            {
                                sizeElement.Add(file[n]);
                            }
                        }

                        var resultadoxDia = string.Format("Case # {0} : {1}", numberDay, CalculateTrips(sizeElement));
                        resultado.Add(resultadoxDia);

                        t = n - 1;
                    }
                }
            }

            var txtBuilder = new StringBuilder();

            if (resultado.Any())
            {
                for (int l = 0; l < resultado.Count; l++)
                {
                    txtBuilder.AppendLine(resultado[l]);
                }
            }

            var txtContent = txtBuilder?.ToString();
            var txtStream = new MemoryStream(Encoding.UTF8.GetBytes(txtContent));

            return txtStream;

        }

        //Calculate trip for days
        public int CalculateTrips(List<int> elements)
        {
            var elementMax = elements.Max();
            elements.Remove(elementMax);
            var size = 0;
            var i = 1;
            var trips = 0;

            while (size < 50 && size < 50)
            {
                if (elements.Count == 0)
                    return 0;

                var elementMin = elements.Min();
                elements.Remove(elementMin);
                i++;
                size = elementMax * i;

            }

            trips++;

            if (elements.Count > 0)
                trips += CalculateTrips(elements);

            return trips;
        }
    }
}