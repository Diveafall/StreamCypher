using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamCypher.Cypher
{
    public enum CypherAlgorithm
    {
        AES
    }

    public class CypherFactory
    {
        public static Cryptor GetCryptor(CypherAlgorithm algorithm, System.IO.Stream destination)
        {
            switch (algorithm)
            {
                case CypherAlgorithm.AES:
                    return GetAesCryptor(destination);
                default: throw new InvalidOperationException("Specified algorithm does not exist.");
            }
        }

        public static AesCryptor GetAesCryptor(System.IO.Stream destination)
        {
            return new AesCryptor(destination);
        }
    }
}
