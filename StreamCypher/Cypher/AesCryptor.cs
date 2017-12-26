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
        public async Task Decrypt(byte[] chunk, Stream output)
        {
            throw new NotImplementedException();
        }

        public async Task Encrypt(byte[] chunk, Stream destination)
        {
            using (var cryptoStream = new CryptoStream(destination, _encryptor, CryptoStreamMode.Write))
            {
                await _destinationStream.WriteAsync(chunk, 0, chunk.Length).ConfigureAwait(false);
            }
        }

        private Aes _aes;
        private CryptoStream _cryptoStream;
        private ICryptoTransform _encryptor;
        protected Stream _destinationStream;

        public AesCryptor(Stream destination)
        {
            _aes = Aes.Create();

            _aes.Padding = PaddingMode.PKCS7;
            _aes.KeySize = 256;

            _aes.GenerateKey();
            _aes.GenerateIV();

            _encryptor = _aes.CreateEncryptor(_aes.Key, _aes.IV);
        }

        public Stream Destination
        {
            get { return _destinationStream; }
            set
            {
                _destinationStream = value;
                _cryptoStream = new CryptoStream(_destinationStream, _encryptor, CryptoStreamMode.Write);
            }
        }
    }
}
