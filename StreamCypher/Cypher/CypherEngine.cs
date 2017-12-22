using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreamCypher.Helper;

namespace StreamCypher.Cypher
{
    public class CypherEngine
    {
        public static async Task Encrypt(string sourcePath, string destinationPath, AesCryptor aes)
        {
            using (var sourceStream = File.OpenRead(sourcePath))
            using (var destinationStream = File.OpenWrite(destinationPath))
            {
                int bytesRead = 0;
                byte[] buffer = new byte[BUFFER_SIZE];

                do
                {
                    bytesRead = await sourceStream.ReadAsync(buffer, 0, BUFFER_SIZE).ConfigureAwait(false);
                    if (bytesRead != 0)
                    {
                        if (bytesRead <= BUFFER_SIZE)
                        {
                            Console.WriteLine("Last chunk.");
                        }
                        await aes.Encrypt(buffer.SubArray(0, bytesRead), destinationStream).ConfigureAwait(false);
                    }
                } while (bytesRead != 0);
            }
        }

        public const int BUFFER_SIZE = 1000000;
    }
}
