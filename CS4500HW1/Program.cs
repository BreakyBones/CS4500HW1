// The programming language for this project is C#
// The IDE that is being used is Visual Studio 2022 for Windows.
// Installation Instructions: To be able to start the installation process,
// a monitor that runs on Windows is required.
// Download the .exe file that is being provided for you to a new empty directory.
// The name of the directory has no restrictions.
// In that same directory, download the link for the card deck.
// Team members are Grant Harris and Mihir Bhakta
// Ex team members are Noor Ghazal and Kanaan Sullivan.
// Authors of the code are primarily Noor Ghazal and Kanaan Sullivan
// Class name is CMPSCI 4500: Intro to Software Profession
// Date of last Commit: April 13, 2024
// The central data structures are winforms, which are used for displaying messages and 
// for the process of selecting or dealing cards.
// External files include images for all 52 cards in a deck
// and the file CardsDealt.txt used to keep track of the cards that were dealt or chosen.
// There is also a file called LastWon.txt that must be made by the user and the user must enter the number
// 0 into that file.
// This program starts with a welcome message.The user clicks Next to start selecting cards.
// One by one, the user confirms each of the four cards separately.
// For each card selected, select one of the boxes containing the suit to select the suit
// and then the dropdown must be used to enter the value instead of typing in the value. Then select Confirm.
// Then the user presses Deal to confirm the hand of four cards from one deck of 52 cards,
// Simultaneously, the coloring of the screen changes where the highlighted cards
// are the ones that the computer chooses based on a pattern, who goes by the name of Art Dealer.
// then the computer puts these cards' information to the file listed above.
// The user's cards that were selected by the Art Dealer will be surrounded from left and right with asterisks.
// Then the user can select Next Round or Quit. If the user selects Next Round, then the round starts new again
// and the process is repeated. If the Art Dealer highlights all 4 cards in a round, the user will be one step 
// closer to winning the pattern and moving onto the next pattern. Once the Art Dealer has highlighted
// all 4 cards for a second time for a pattern, then the user will be congratulated by the Art Dealer
// and the user will move onto the next pattern upon entering the new round via the Next Round button.
// Once the user has won all the patterns (this means the user has won the game), 
// the Art Dealer will ask the user if they want to restart the game.
// If so, the Art Dealer will reset the patterns. If not, the program will close.
// If the user restarts the program after having already won the game without restarting the patterns, the Art Dealer will ask
// if the user wants to restart the game after the user attempts to deal. If so, then the patterns will be reset. If not, the program will close again as it did before 
// be one step closer to winning the pattern
// The cards selected by you and the Art Dealer from previous rounds are shown in the upper right corner.
// A third textfile called CurrentPattern.txt is used for this assignment. DO NOT EDIT IT YOURSELF!! If you do, then the user will easily 
// use duplicate hands to win the same pattern.



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