using System;
using System.Collections.Generic;
using System.Text;

namespace VoiceNET.Lib.ClientAPI
{
    class RandomName
    {

        private static readonly Random _random = new Random();


        public static string getRandomName()
        {
            return RandomChar();
        }
        // Generates a random number within a range.      
        private static int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        // Generates a random string with a given size.    
        private static string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length = 26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        private static string RandomChar()
        {
            var passwordBuilder = new StringBuilder();

            // 4-Letters lower case   
            passwordBuilder.Append(RandomString(4, true));

            // 4-Digits between 100 and 9999  
            passwordBuilder.Append(RandomNumber(100, 9999));

            // 2-Letters upper case  
            passwordBuilder.Append(RandomString(2));
            return passwordBuilder.ToString();
        }
    }
}
