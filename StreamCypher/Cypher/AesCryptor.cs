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
        #region Fields
        private Aes _aes;

        private Stream _encDestination;
        private Stream _decDestination;

        private CryptoStream _encryptor;
        private CryptoStream _decryptor;
        #endregion

        #region Properties
        public byte[] Key
        {
            get
            {
                return _aes.Key;
            }
            set
            {
                _aes.Key = value;
            }
        }

        public Stream EncryptDestination
        {
            get { return _encDestination; }
            set
            {
                _encDestination = value;
                _encryptor = new CryptoStream(_encDestination, _aes.CreateEncryptor(_aes.Key, _aes.IV), CryptoStreamMode.Write);
            }
        }

        public Stream DecryptDestination
        {
            get { return _decDestination; }
            set
            {
                _encDestination = value;
                _encryptor = new CryptoStream(_decDestination, _aes.CreateDecryptor(_aes.Key, _aes.IV), CryptoStreamMode.Write);
            }
        }
        #endregion

        #region Public Methods
        public async Task Decrypt(byte[] chunk)
        {
            await _decryptor.WriteAsync(chunk, 0, chunk.Length).ConfigureAwait(false);
        }

        public async Task Encrypt(byte[] chunk)
        {
            await _encryptor.WriteAsync(chunk, 0, chunk.Length).ConfigureAwait(false);
        }
        #endregion

        #region Constructors
        public AesCryptor()
        {
            _aes = Aes.Create();

            _aes.Padding = PaddingMode.PKCS7;
            _aes.KeySize = 256;

            _aes.GenerateKey();
            _aes.GenerateIV();
        }
        #endregion
    }
}
