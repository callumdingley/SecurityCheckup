using System.Text.RegularExpressions;
namespace SecurityCheckup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextReader input = Console.In;
            Console.WriteLine("Input a password to be checked for security level:");
            String password = input.ReadLine();
            Console.WriteLine("Your password is: " + password);
            Console.WriteLine("Security strength score: " + PasswordStrength(password) + "%");
        }

        private static int PasswordStrength(string password)
        {
            int strength = 0;
            char[] split = password.ToCharArray();
            foreach (char character in split)
            {
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
