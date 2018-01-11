using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StreamCypher.Cypher.CypherEngine;
using Sodium;
using StreamCypher.Helper;

namespace StreamCypher.Cypher
{
    class CypherModel
    {
        #region Constants
        public const string ENCRYPTED_EXTENSION = @"enc";
        public const int BUFFER_SIZE = 1048576;
        #endregion

        #region Fields
        private string _sourceFilePath;
        private byte[] _key = SecretBox.GenerateKey();
        private byte[] _nonce = SecretBox.GenerateNonce();
        #endregion

        #region Properties
        public string SourceFilePath
        {
            get
            {
                return _sourceFilePath;
            }
            set
            {
                if (File.Exists(value))
                {
                    _sourceFilePath = value;
                }
            }
        }

        public string SourceExtension
        {
            get
            {
                return Path.GetExtension(SourceFilePath);
            }
        }

        public string EncryptedDirectory { get; set; }

        public string EncryptedFileName { get; set; }

        public byte[] Key { get { return _key; } set { _key = value; } }

        public byte[] Nonce { get { return _nonce; } set { _nonce = value; } }

        public string EncryptedFilePath
        {
            get
            {
                return Path.Combine(EncryptedDirectory, EncryptedFileName);
            }
        }
        #endregion

        public async Task<Stats> Encrypt(Action<int> reporter)
        {
            try
            {
                using (var sourceStream = File.OpenRead(_sourceFilePath))
                using (var destinationStream = File.OpenWrite(EncryptedFilePath))
                {
                    var cryptor = CypherFactory.GetCryptor(CypherAlgorithm.AES, destinationStream);
                    return await CypherEngine.Encrypt(cryptor, sourceStream, destinationStream, BUFFER_SIZE, new Progress<int>(reporter));
                }
            } catch(Exception exception)
            {
                UIEx.ShowNotice("SHIT", exception.Message);
            }
            return new Stats();
        }

        public async Task<Stats> Decrypt(Action<int> reporter)
        {
            try
            {
                using (var sourceStream = File.OpenRead(_sourceFilePath))
                using (var destinationStream = File.OpenWrite(EncryptedFilePath))
                {
                    var cryptor = CypherFactory.GetCryptor(CypherAlgorithm.AES, destinationStream);
                    return await CypherEngine.Decrypt(cryptor, sourceStream, destinationStream, BUFFER_SIZE, new Progress<int>(reporter));
                }
            }
            catch (Exception exception)
            {
                UIEx.ShowNotice("SHIT", exception.Message);
            }
            return new Stats();
        }
    }
}
