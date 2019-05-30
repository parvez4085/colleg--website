using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSJM.Models
{
    public class EncryptionManager
    {
        public string EncryptData(string PlainText)
        {
            string CyberText = "";
            foreach (char ch in PlainText)
            {
                int ASCIIValue = ch;
                if (ASCIIValue >= 65 && ASCIIValue <= 90)
                {
                    ASCIIValue = 65 - ASCIIValue + 122;
                }
                else if (ASCIIValue >= 97 && ASCIIValue <= 122)
                {
                    ASCIIValue = 97 - ASCIIValue + 90;
                }
                else if (ASCIIValue >= 48 && ASCIIValue <= 57)
                {
                    ASCIIValue = 48 - ASCIIValue + 57;
                }
                char c1 = (char)ASCIIValue;
                CyberText = CyberText + c1;
            }
            return CyberText;
        }
    }
}