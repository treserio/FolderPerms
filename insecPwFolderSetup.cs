using System;
// for directory info
using System.IO;
// for process.start
using System.Diagnostics;

namespace FolderSetup
{
    class Program
    {
        // better ui for exiting
        static void exitPrompt()
        {
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        static void Main()
        {
            // initialize password string for while loop
            string pw = "";
            // while the password is incorrect loop through request, or type exit to quit
            while (!pw.Equals("H0Ld3nItD0wn!"))
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
                        // append keystroke to pw string
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
            // confirm the directory you'd like to set permissions on
            var prntFldr = Directory.GetParent(Directory.GetCurrentDirectory());
            Console.WriteLine("Configure permissions for " + prntFldr + "  ( Y/N )?");
            string confirm = Console.ReadLine();
            // case insensitive comparison
            if (confirm.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                // command strings for icacls ***? add one to lock down permissions on this executable ?***
                // ***? Also create a check to make sure that it's in the admin folder before running? "Directory\ + prntFldr + \Admin" ?***
                string icaclsModify = "\"" + prntFldr + "\\*\" /grant:r \"HOLDENMCKENNA\\Limited Case Access\":(OI)(CI)(IO)M";
                string icaclsWrite = "\"" + prntFldr + "\\*\" /grant:r \"HOLDENMCKENNA\\Limited Case Access\":(NP)W";
                // Console.WriteLine(icaclsModify); *** Line used for debugging
                // start icacls process and send parameters to run as
                var modfy = Process.Start("icacls.exe", icaclsModify);
                // wait for icacls to finish and confirm it ran successfully
                modfy.WaitForExit();
                if (modfy.ExitCode != 0)
                {
                    Console.WriteLine("There was an error setting modify permissions: " + modfy.ExitCode);
                    exitPrompt();
                    Environment.Exit(-1);
                }
                // start icacls process and send parameters to run as
                var wrte = Process.Start("icacls.exe", icaclsWrite);
                // wait for icacls to finish and confirm it ran successfully
                wrte.WaitForExit();
                if (wrte.ExitCode != 0)
                {
                    Console.WriteLine("There was an error setting write permissions: " + modfy.ExitCode);
                    exitPrompt();
                    Environment.Exit(-2);
                }
                // display confirmation that permissions have been set correctly
                Console.WriteLine();
                Console.WriteLine("Permissions have been set for " + prntFldr);
            }
            else
            {
                Console.WriteLine("Permissions have not been set.");
            }
            exitPrompt();
        }
    }
}