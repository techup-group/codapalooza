using System;
using System.Security.Cryptography;
using System.Text;

namespace TampaInnovation.GimmeServices.Business
{
    public class Utilities
    {
        private static int CurrentUnixTimeStamp(DateTime dateTime)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return (int)dateTime.Subtract(epoch).TotalSeconds;
        }

        public static SigningKey GetSigningKey(string publicKey, string privateKey)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                SigningKey key = new SigningKey();
                key.TimeStamp = CurrentUnixTimeStamp(DateTime.UtcNow).ToString();
                key.PublicKey = publicKey;


                var input = string.Concat(publicKey, CurrentUnixTimeStamp(DateTime.UtcNow), privateKey);
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                foreach (byte character in data)
                    sBuilder.Append(character.ToString("x2"));

                // Return the hexadecimal string.
                key.Signature = sBuilder.ToString();

                return key; 
            }
        }
    }
}
