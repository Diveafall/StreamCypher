using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StreamCypher.Cypher
{
    public class AesCryptor : Cryptor
    {
        public async Task Decrypt(byte[] chunk, Stream destination)
        {
            await _decryptor.WriteAsync(chunk, 0, chunk.Length).ConfigureAwait(false);
        }

        public async Task Encrypt(byte[] chunk, Stream destination)
        {
            await _encryptor.WriteAsync(chunk, 0, chunk.Length).ConfigureAwait(false);
        }

        public byte[] GetKey()
        {
            return _aes.Key;
        }

        private Aes _aes;

        protected Stream _destinationStream;

        CryptoStream _encryptor;
        CryptoStream _decryptor;

        public AesCryptor(Stream destination)
        {
            _aes = Aes.Create();

            _aes.Padding = PaddingMode.PKCS7;
            _aes.KeySize = 256;

            _aes.GenerateKey();
            _aes.GenerateIV();

            _encryptor = new CryptoStream(destination, _aes.CreateEncryptor(_aes.Key, _aes.IV), CryptoStreamMode.Write);
            _encryptor = new CryptoStream(destination, _aes.CreateDecryptor(_aes.Key, _aes.IV), CryptoStreamMode.Write);
        }
    }
}
