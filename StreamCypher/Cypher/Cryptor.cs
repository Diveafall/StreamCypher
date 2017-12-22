using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamCypher.Cypher
{
    interface Cryptor
    {
        Task Encrypt(byte[] chunk, Stream destination);
        Task Decrypt(byte[] chunk, Stream destination);
    }
}
