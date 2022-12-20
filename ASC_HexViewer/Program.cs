using System;
using System.IO;
namespace HexViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hex Viewer

            const int octeti_din_fisier = 16;
            string nume_fisier = " .exe";
            using (FileStream fisier = File.OpenRead(nume_fisier))
            {
                byte[] data = new byte[octeti_din_fisier];
                int amount;
                string linie_hex = string.Empty;

                do
                {
                    Console.Write(ToHex(fisier.Position, 8));
                    Console.Write(" ");
                    amount = fisier.Read(data, 0, octeti_din_fisier);
                    int i;
                    for (i = 0; i < amount; i++)
                    {
                        Console.Write(ToHex(data[i], 2) + " ");

                        if (data[i] < 32)
                        {
                            linie_hex += "."; //caractere neafisabile devin puncte
                        }
                        else
                        {
                            linie_hex += (char)data[i];
                        }

                        if (amount < octeti_din_fisier)
                        {
                            for (i = amount; i < octeti_din_fisier; i++)
                            {
                                Console.Write("  ");
                            }
                        }
                        Console.WriteLine(linie_hex);
                        linie_hex = "";
                    }
                }
                while (amount == octeti_din_fisier);
            }
        }
        private static string ToHex(long n, int cifre)
        {
            string hex = Convert.ToString(n, 16);
            while (hex.Length < cifre)
            {
                hex += "0";
            }
            return hex;
        }
    }
}