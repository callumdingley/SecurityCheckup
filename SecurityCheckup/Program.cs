/*
 * @author Callum Dingley
 * @date 2/20/2025
 */

using System.Text.RegularExpressions;
namespace SecurityCheckup
{
    internal class Program
    {
        /// <summary>
        /// Initiates the console and the input interface. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            TextReader input = Console.In;
            Console.WriteLine("Input a password to be checked for security level:");
            String password = input.ReadLine();
            Console.WriteLine("Your password is: " + password);
            Console.WriteLine("Security strength score: " + PasswordStrength(password) + "%");
        }
        
        /// <summary>
        /// Returns a int out of 100 for the strength of the password based on combination of letters, numbers, and special characters. 
        /// </summary>
        /// <param name="password">Password to be checked.</param>
        /// <returns>Int score out of 100.</returns>
        private static int PasswordStrength(string password)
        {
            int strength = 0;
            // Split password into array of each character and iterate through.
            char[] split = password.ToCharArray();
            foreach (char character in split)
            {
                // Change score based on if character is a letter, number, or special character. 
                if (Regex.IsMatch(character.ToString(), "[a-zA-Z0-9]"))   
                    strength += 5;
                if (Regex.IsMatch(character.ToString(), "[!@#$%^&*()?/,<.>]"))
                    strength += 15;
            }
            if (strength >= 100)
                return 100;
            return strength;
        }
    }
}
