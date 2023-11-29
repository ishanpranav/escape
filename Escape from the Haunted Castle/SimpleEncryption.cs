using System.Collections.Generic;

namespace haunted_castle
{
    class SimpleEncryption
    {
        public string EncryptString(string PlainText)
        {
            string ret = string.Empty;
            List<char> u = new List<char>();
            List<char> d = new List<char>();

            PlainText = PlainText.Replace("True", "#-").Replace("False", ":").Replace(">", "=").Replace("<", "+").Replace("/", "?");

            while (PlainText.Length % 2 != 0)
                PlainText += "|";

            for (int i = 0; i < PlainText.Length; i++)
                if (i % 2 == 0)
                    u.Add(PlainText[i]);
                else
                    d.Add(PlainText[i]);

            foreach (char ch in u)
                ret += ch.ToString();

            foreach (char ch in d)
                ret += ch.ToString();

            return ret;
        }

        public string DecryptString(string EncryptedText)
        {
            string ret = string.Empty;
            string u = string.Empty;
            string d = string.Empty;

            if (EncryptedText.Length % 2 == 0)
            {
                u = EncryptedText.Substring(0, EncryptedText.Length / 2);
                d = EncryptedText.Substring(EncryptedText.Length / 2, EncryptedText.Length / 2);

                if (u.Length == d.Length)
                    for (int i = 0; i < u.Length; i++)
                    {
                        ret += u[i];
                        ret += d[i];
                    }
                else
                    ret = string.Empty;
            }
            else
                ret = string.Empty;

            ret = ret.Replace("|", string.Empty).Replace("#-", "True").Replace(":", "False").Replace("=", ">").Replace("+", "<").Replace("?", "/");
            return ret;
        }
    }
}
