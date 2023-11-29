using System;
using System.Collections.Generic;

namespace KeyBuilder
{
    class Key
    {
        private static string alpha = "3479ACEGHJKMNPQRATWY34793479TGKM";

        public static string a4angen(string seed, out char checkDigit, DateTime exp)
        {
            List<char> an = new List<char>();
            string ret = string.Empty;

            checkDigit = ' ';

            an.AddRange(a3angen(seed, out checkDigit, false, exp));

            foreach (char ch in an)
                ret += ch;

            return ret;
        }

        public static string a3angen(string seed, out char checkDigit, bool a3 = true, DateTime exp = new DateTime())
        {
            seed = seed.ToUpper() + "  ";

            int nseed = 0;

            if (exp != new DateTime())
                nseed = exp.Hour;

            foreach (char ch in seed)
                if (a3)
                    nseed += Convert.ToInt32(ch) * 3;
                else
                    nseed += Convert.ToInt32(ch) * 4;

            Random r = new Random(nseed);

            char[] an = new char[9];
            int chk = 0;

            an[0] = 'A'; // Escape from the Haunted Castle (ATLAS I)

            if (a3)
                an[1] = '3'; // Key Format
            else
                an[1] = '4'; // Key Format

            an[2] = alpha[r.Next(0, alpha.Length)]; // Random

            an[3] = an[2];

            while (an[3] == an[2])
                an[3] = alpha[r.Next(0, alpha.Length)]; // Random

            an[4] = '*';

            int p = 0;

            while (!alpha.Contains(an[4].ToString()) && p < seed.Length)
            {
                an[4] = seed[p]; // First Initial
                p++;
            }

            if (!alpha.Contains(an[4].ToString()))
                an[4] = 'K';

            an[5] = an[4];

            while (an[5] == an[4])
                an[5] = alpha[r.Next(0, alpha.Length)]; // Random

            an[6] = an[5];

            while (an[6] == an[5])
                an[6] = alpha[r.Next(0, alpha.Length)]; // Random

            an[7] = an[6];

            foreach (char ch in an)
                chk += Convert.ToInt32(ch);

            chk += nseed;
            chk %= alpha.Length;

            an[8] = alpha[chk]; // Check Digit

            while (an[7] == an[6] || an[7] == an[8])
                an[7] = alpha[r.Next(0, alpha.Length)]; // Random

            string ret = string.Empty;

            foreach (char ch in an)
                ret += ch;

            checkDigit = alpha[chk];

            return ret;
        }

        static void Main()
        {
            Console.Title = "Escape License Key Generator";
            DateTime d = DateTime.Now.AddHours(-1);

            Console.Write(">");

            string seed = Console.ReadLine();
            string an = string.Empty;

            Console.WriteLine();

            char checkDigit = ' ';

            an = a3angen(seed, out checkDigit);

            Console.WriteLine("INF " + an.Substring(0, 3) + " " + an.Substring(3, 3) + " " + an.Substring(6));

            for (int x = 0; x < 12; x++)
            {
                d = d.AddHours(1);

                an = a4angen(seed, out checkDigit, d);

                Console.WriteLine(d.ToString("hht").ToUpper() + " " + an.Substring(0, 3) + " " + an.Substring(3, 3) + " " + an.Substring(6));
            }

            Console.Read();
        }
    }
}
