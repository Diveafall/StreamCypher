using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreamCypher.Helper;

namespace StreamCypher.Cypher
{
    public static class CypherEngine
    {
        public static async Task Encrypt(string sourcePath, string destinationPath, IProgress<int> progress)
        {
            using (var sourceStream = File.OpenRead(sourcePath))
            using (var destinationStream = File.OpenWrite(destinationPath))
            {
                int bytesRead = 0;
                long bytesTotalRead = 0;
                long bytesTotal = sourceStream.Length;
                byte[] buffer = new byte[BUFFER_SIZE];

                do
                {
                    bytesRead = await sourceStream.ReadAsync(buffer, 0, BUFFER_SIZE).ConfigureAwait(false);
                    if (bytesRead != 0)
                    {
                        if (bytesRead < BUFFER_SIZE)
                        {
                            Console.WriteLine("Last chunk.");
                        }
                    }
                    bytesTotalRead += bytesRead;
                    progress.Report((int)(bytesTotalRead * 100 / bytesTotal));
                } while (bytesRead != 0);
            }
        }

        public const int BUFFER_SIZE = 1000000;
    }
}
