using Auto.Core.BoumcyCastle.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auto.Core.BoumcyCastle
{
    public static class AutoBounyCastleServiceCollectionExtensions
    {
        #region MD5
        public static string MD5(this string str, MD5EncryptType encryptType = MD5EncryptType.ThirtyTwo)
        {
            string result =string.Empty;
            var m = BouncyCastle.MD5.Compute(str);
            if (encryptType.Equals( MD5EncryptType.ThirtyTwo))
            {

            }
            return result;
        }
        #endregion
    }
}
