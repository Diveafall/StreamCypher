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
        private Cryptor _cryptor = CypherFactory.GetCryptor(CypherAlgorithm.AES);
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

        public byte[] Key { get { return _cryptor.Key; } set { _key = value; } }

        public string EncryptedFilePath
        {
            get
            {
                return Path.Combine(EncryptedDirectory, EncryptedFileName);
            }
        }
        #endregion

        #region Public Methods
        public async Task<Stats> Encrypt(Action<int> reporter)
        {
            try
            {
                using (var sourceStream = File.OpenRead(_sourceFilePath))
                using (var destinationStream = File.OpenWrite(EncryptedFilePath))
                {
                    _cryptor.EncryptDestination = destinationStream;
                    return await CypherEngine.Encrypt(_cryptor, sourceStream, BUFFER_SIZE, new Progress<int>(reporter));
                }
            } catch(Exception exception)
            {
                UIEx.ShowNotice("Exception", exception.Message);
            }
            return new Stats();
        }

        public async Task<Stats> Decrypt(Action<int> reporter)
        {
            //try
            //{
                using (var sourceStream = File.OpenRead(_sourceFilePath))
                using (var destinationStream = File.OpenWrite(EncryptedFilePath))
                {
                    _cryptor.DecryptDestination = destinationStream;
                    return await CypherEngine.Decrypt(_cryptor, sourceStream, BUFFER_SIZE, new Progress<int>(reporter));
                }
            //}
            //catch (Exception exception)
            //{
            //    UIEx.ShowNotice("Exception", exception.Message);
            //}
            return new Stats();
        }
        #endregion
    }
}
