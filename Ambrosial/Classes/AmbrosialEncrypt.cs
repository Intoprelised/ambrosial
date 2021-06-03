using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambrosial.Ambrosial.Classes
{
    public static class AmbrosialEncrypt
    {
        private static string alphaChars;
        private static string GenerateRandomString(int length)
        {
            alphaChars = @"!#$%&*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{}~";
            VBMath.Randomize();
            string temp = "";
            checked
            {
                for (int x = 0; x <= length; x++)
                {
                    int i = (int)Math.Round(Math.Floor((double)(unchecked((float)(checked(alphaChars.Length - 1 + 1)) * VBMath.Rnd())))) + 1;
                    temp += Strings.Mid(alphaChars, i, 1);
                }
                return temp;
            }
        }

        public static string Encrypt(string inputString)
        {
            string input = inputString;
            string rand = GenerateRandomString(15);
            input = Cipher.Encrypt(input, rand);
            input += "[AmbrosialPacket]" + rand;
            return Cipher.EncryptBase64(input);
        }

        public static string Decrypt(string inputString)
        {
            string input = inputString;
            string decryptedBasePacket = Cipher.DecryptBase64(input);
            string[] packInfo = decryptedBasePacket.Split(new string[] { "[AmbrosialPacket]" }, StringSplitOptions.RemoveEmptyEntries);
            return Cipher.Decrypt(packInfo[0], packInfo[1]);
        }

    }
}
