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
        public static Cryptor GetCryptor(CypherAlgorithm algorithm)
        {
            switch (algorithm)
            {
                case CypherAlgorithm.AES:
                    return GetAesCryptor();
                default: throw new InvalidOperationException("Specified algorithm does not exist.");
            }
        }

        public static AesCryptor GetAesCryptor()
        {
            return new AesCryptor();
        }
    }
}
