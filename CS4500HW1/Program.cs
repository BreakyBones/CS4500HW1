// The programming language for this project is C#
// The IDE that is being used is Visual Studio 2022 for Windows.
// Installation Instructions: To be able to start the installation process,
// a monitor that runs on Windows is required.
// Download the .exe file that is being provided for you to a new empty directory.
// The name of the directory has no restrictions.
// In that same directory, download the link for the card deck.
// Team members include Noor Ghazal, Kanaan Sullivan, Grant Harris, and Mihir Bhakta
// Authors of the code are primarily Noor Ghazal and Kanaan Sullivan
// Class name is CMPSCI 4500: Intro to Software Profession
// Date of last Commit: March 22, 2024
// The central data structures are winforms, which are used for displaying messages and 
// for the process of selecting or dealing cards.
// External files include images for all 52 cards in a deck
// and the file CardsDealt.txt used to keep track of the cards that were dealt or chosen.
// This program starts with a welcome message.The user clicks Next to start selecting cards.
// One by one, the user confirms each of the four cards separately.
// For each card selected select one of the boxes containing the suit to select the suit
// and then the dropdown must be used to enter the value instead of typing in the value. Then select Confirm.
// Then the user presses Deal lets to confirm the hand of four cards from one deck of 52 cards,
// Simultaneously, the coloring of the screen changes where the highlighted cards
// are the ones that the computer chooses, who goes by the name of Art Dealer.
// then the computer puts these cards' information to the file listed above.
// The user's cards that were selected by the Art Dealer will be surrouned left and right with asterisks.
// Then the user can select Next Round or Quit. If the user selects Next Round, then the round starts new again
// and the process is repeated.
// The cards selected by you and the Art Dealer from previous rounds are shown in the upper right corner.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS4500HW1
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartupForm());
        }
    }
}
// End of file