using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StreamCypher.Cypher.CypherEngine;

namespace StreamCypher.Cypher
{
    class CypherModel
    {
        #region Constants
        public const string ENCRYPTED_EXTENSION = @"enc";
        #endregion

        #region Fields
        private string _sourceFilePath;
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

        public string EncryptedFilePath
        {
            get
            {
                return Path.Combine(EncryptedDirectory, EncryptedFileName + "." + ENCRYPTED_EXTENSION);
            }
        }
        #endregion

        public async Task<CypherStats> Encrypt(Action<int> reporter)
        {
            try
            {
                using (var sourceStream = File.OpenRead(_sourceFilePath))
                using (var destinationStream = File.OpenWrite(EncryptedFilePath))
                {
                    return await CypherEngine.Encrypt(sourceStream, destinationStream, new Progress<int>(reporter));
                }
            } catch(Exception exception)
            {

            }
            return new CypherStats();
        }
    }
}
