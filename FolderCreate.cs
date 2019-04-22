using System;
// for directory info
using System.IO;
// for process.start
using System.Diagnostics;

namespace folderCreate {
    class Program {
    // better ui for exiting
    static void exitPrompt()
    {
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    static void Main() {
        
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

        // prompt for the case name to use
        Console.WriteLine("Please enter the Case Name");
        string caseName = Console.ReadLine();
        // prompt for the HL number assigned
        Console.WriteLine("Please enter the HL Number");
        string hlNum = Console.ReadLine();
        // combined for ease of use
        string newName = caseName + " " + hlNum

        // confirm that what was entered is what they want to use
        Console.WriteLine("You've entered: \"" + newName + "\" is this correct (Y/N)?");
        string confirm = Console.ReadLine();
        if (confirm.Equals("Y", StringComparison.InvariantCultureIgnoreCase)) {
            // asyncronously copy & rename the template folder into \\holdendata\Common\Cases as the new folder name, 
            foreach (string subfolder in Directory.EnumerateFiles("\\\holdendata\Common\Cases\_NewCase Template")) {

            }
        }
        else {
            Console.WriteLine("Now exiting, please try again.")
        }
        Program.exitPrompt();
    }
    }
}