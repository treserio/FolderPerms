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
        static void Main(string[] args)
        {
            // while the password is incorrect loop through request, or type exit to quit
            string pw = "";
            while (!pw.Equals("H0Ld3nItD0wn!"))
            {
                Console.WriteLine("Enter Password or type [Exit] to exit:");
                pw = Console.ReadLine();
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
                string icaclsModify = prntFldr + "\\* /grant:r \"HOLDENMCKENNA\\Limited Case Access\":(OI)(CI)(IO)M";
                string icaclsWrite = prntFldr + "\\* /grant:r \"HOLDENMCKENNA\\Limited Case Access\":(NP)W";
                // start icacls process and send parameters to run as
                var modfy = Process.Start("icacls.exe", icaclsModify);
                    // wait for icacls to finish and confirm it ran successfully
                    modfy.WaitForExit();
                    if (modfy.ExitCode != 0)
                    {
                        Console.WriteLine("There was an error setting modify permissions");
                        Program.exitPrompt();
                        Environment.Exit(-1);
                    }
                // start icacls process and send parameters to run as
                var wrte = Process.Start("icacls.exe", icaclsWrite);
                    // wait for icacls to finish and confirm it ran successfully
                    wrte.WaitForExit();
                    if (wrte.ExitCode != 0)
                    {
                        Console.WriteLine("There was an error setting write permissions");
                        Program.exitPrompt();
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
            Program.exitPrompt();
        }
    }
}