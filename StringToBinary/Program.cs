using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringToBinary
{
    class Program
    {
        static void Main(string[] args)
        {            
            string word = "ab";

            Console.WriteLine($"Input\n{word}\n\nOutput");

            foreach (var item in word)
            {
                // convert string to binary
                string binary = StringToBinary(item.ToString());

                // segregating nibbles
                string newBinary = binary.Insert(4, " ");
                string[] nibbles = newBinary.Split(new string[] { " "}, StringSplitOptions.RemoveEmptyEntries);
                
                // swapping the nibbles
                nibbles[1] = SwapValues(nibbles[1]);
                binary = nibbles[0] + nibbles[1];

                // convert binary to string
                string letter = BinaryToString(binary);
                Console.Write($"{letter}");
            }

            Console.Read();
        }

        // Function for swapping     
        static string SwapValues(string nibble)
        {
            string a, b;
            a = nibble.Substring(0, 2);
            b = nibble.Substring(2, 3-1);

            return b + a;
        }

        static string StringToBinary(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0') + " ");
            }
            return sb.ToString();
        }

        static string BinaryToString(string binary)
        {
            string tempString = "";
            string Character = binary;

            string[] splits = binary.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < splits.Length; i++)
            {
                byte[] Bytes = new byte[(splits[i].Length / 8) - 1 + 1];
                for (int Index = 0; Index <= Bytes.Length - 1; Index++)
                {
                    Bytes[Index] = Convert.ToByte(Character.Substring(Index * 8, 8), 2);
                }

                tempString = Encoding.ASCII.GetString(Bytes);
            }

            return tempString.ToString();
        }
    }
}
