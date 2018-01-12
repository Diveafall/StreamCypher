using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreamCypher.Helper;
using Sodium;
using System.Security.Cryptography;

namespace StreamCypher.Cypher
{
    public static class CypherEngine
    {

        public struct Stats
        {
            public string title;
            public long duration;
        }

        public static async Task<Stats> Process(Stream source, int bufferSize, IProgress<int> progress, Func<byte[], Task> apply)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            int bytesRead = 0;
            long bytesTotalRead = 0;
            long bytesTotal = source.Length;
            byte[] buffer = new byte[bufferSize];

            do
            {
                bytesRead = await source.ReadAsync(buffer, 0, bufferSize).ConfigureAwait(false);
                if (bytesRead != 0)
                {
                    if (bytesRead < bufferSize)
                    {
                        Console.WriteLine("Last chunk.");
                    }
                }
                await apply(buffer).ConfigureAwait(false);

                bytesTotalRead += bytesRead;

                progress.Report((int)(bytesTotalRead * 100 / bytesTotal));
            } while (bytesRead != 0);

            watch.Stop();

            Stats stats;
            stats.title = @"Results";
            stats.duration = watch.ElapsedMilliseconds;
            return stats;
        }

        public static async Task<Stats> Encrypt(Cryptor cryptor, Stream source, int bufferSize, IProgress<int> progress)
        {
            return await Process(source, bufferSize, progress, async (buffer) => {
                await cryptor.Encrypt(buffer).ConfigureAwait(false);
            });
        }

        public static async Task<Stats> Decrypt(Cryptor cryptor, Stream source, int bufferSize, IProgress<int> progress)
        {
            return await Process(source, bufferSize, progress, async (buffer) => {
                await cryptor.Decrypt(buffer).ConfigureAwait(false);
            });
        }
    }
}
