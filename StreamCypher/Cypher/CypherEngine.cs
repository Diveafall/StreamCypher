using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreamCypher.Helper;
using Sodium;

namespace StreamCypher.Cypher
{
    public static class CypherEngine
    {
        public struct CypherStats
        {
            public string name;
            public long durationMilliseconds;
            public long chunkCount;
            public long sourceSize;
            public long resultSize;
        }

        public static async Task<CypherStats> Encrypt(Stream sourceStream, Stream destinationStream, IProgress<int> progress)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            int bytesRead = 0;
            long bytesTotalRead = 0;
            long chunkCount = 0;
            long bytesTotal = sourceStream.Length;
            byte[] buffer = new byte[BUFFER_SIZE];

            var nonce = SecretBox.GenerateNonce();
            var key = SecretBox.GenerateKey();

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
                var encrypted = SecretBox.Create(buffer, nonce, key);
                await destinationStream.WriteAsync(encrypted, 0, encrypted.Length);

                bytesTotalRead += bytesRead;
                ++chunkCount;

                progress.Report((int)(bytesTotalRead * 100 / bytesTotal));
            } while (bytesRead != 0);

            watch.Stop();

            CypherStats stats = new CypherStats();
            stats.name = "Encryption";
            stats.durationMilliseconds = watch.ElapsedMilliseconds;
            stats.sourceSize = sourceStream.Length;
            stats.resultSize = destinationStream.Length;

            return stats;
        }

        public const int BUFFER_SIZE = 1000000;
    }
}
