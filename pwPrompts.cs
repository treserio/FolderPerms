using System;

namespace pw
{
    public class Prompts
    {
        public static void Insecure(string password)
        {
            // initialize password string for while loop
            string pw = "";
            // while the password is incorrect loop through request, or type exit to quit
            while (!pw.Equals(password))
            {
                // reset string after iteration
                pw = "";
                Console.WriteLine("Enter Password or type [Exit] to exit:");
                // for reading in keystrokes
                ConsoleKeyInfo key;
                // obstruct and read in keystrokes
                do
                {
                    key = Console.ReadKey(true);
                    // as long as a Backspace or Enter wasn't used
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        pw += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        // If backspace is used, remove a space from the pw and correct the number of * displayed
                        if (key.Key == ConsoleKey.Backspace && pw.Length > 0)
                        {
                            // reduce the characters in pw by 1
                            pw = pw.Substring(0, (pw.Length - 1));
                            // backspace, erase by using a space, and backspace again
                            Console.Write("\b \b");
                        }
                    }
                    // exit on Enter
                } while (key.Key != ConsoleKey.Enter);
                Console.WriteLine("");
                // Console.WriteLine(pw); *** Line used for debugging

                // on exit sequence quit application
                if (pw.Equals("Exit", StringComparison.InvariantCultureIgnoreCase))
                {
                    Environment.Exit(0);
                }
            }
        }
        public static void SecurePW()
        {

        }

    }
}
