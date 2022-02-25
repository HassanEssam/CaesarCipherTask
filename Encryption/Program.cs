using System;
using System.Text;

namespace Encryption.CaesarCipher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Input string: ");
            string input = Console.ReadLine();

            Console.Write("Shifting: ");
            int shifting = int.Parse(Console.ReadLine());

            string output = EncreptString_CaesarCipher(input, shifting);
            Console.WriteLine("Output: " + output);
        }
        /// <summary>
        /// circular shifting Logic
        ///     - In-case the Shifting count is grater than 90 ('Z') we take the modulus (circler shifting rule)
        ///     - In-case the shifted character is less than or equals  90 ('Z') So, nothing to do else
        ///     - Else we take modulus 90 ('Z') to reset the character in the capital alphabets range
        /// </summary>
        /// <param name="input"> The Input sting that will be processed/Encrypted using CaesarCipher</param>
        /// <param name="shift"> The shifting count</param>
        /// <returns>
        ///     Null   : If the input null
        ///     string : The encrypted string after applying the algorithm
        /// </returns>
        /// <exception cref="Exception"> In case the input string having a non capital alphabet </exception>
        public static string EncreptString_CaesarCipher(string input, int shift)
        {
            shift = shift % 'Z';

            // stringBuilder instead of string for better performance in concatenations 
            // ref : https://docs.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/general/string-concatenation
            StringBuilder output = new StringBuilder();

            // in case of NULL string return Null 
            if (input == null)
            {
                return input;
            }
            for (int i = 0; i < input.Length; i++)
            {
                // If the current character is not a capital alphabet, throw exception
                if (Char.IsUpper(input[i]) == false)
                {
                    throw new Exception("Only A-Z supported.");
                }

                int shifted = input[i] + shift;
                if (shifted > 'Z')
                    // Circular shifting rule 
                    shifted = (shifted % 'Z') + 'A' - 1;
                output.Append((char)shifted);
            }
            return output.ToString();
        }
    }
}

