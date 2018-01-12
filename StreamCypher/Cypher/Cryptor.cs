using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamCypher.Cypher
{
    public interface Cryptor
    {
        Task Encrypt(byte[] chunk);

        Task Decrypt(byte[] chunk);

        byte[] Key { get; set; }
        Stream EncryptDestination { get; set; }
        Stream DecryptDestination { get; set; }
    }
}
