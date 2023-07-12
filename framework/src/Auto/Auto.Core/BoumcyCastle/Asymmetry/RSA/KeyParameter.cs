﻿using Org.BouncyCastle.Crypto;

namespace Auto.Core.BouncyCastle
{
    public class KeyParameter
    {
        /// <summary>
        /// 公钥
        /// </summary>
        public string PublicKey { get; set; }
        /// <summary>
        /// 私钥
        /// </summary>
        public string PrivateKey { get; set; }
    }
}
