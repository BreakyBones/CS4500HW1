// The programming language for this project is C#.
// The IDE that is being used is Visual Studio 2022 for Windows.
// Installation Instructions: To be able to start the installation process,
// a monitor that runs on Windows is required.
// Download the .exe file that is being provided for you to a new empty directory.
// The name of the directory has no restrictions.
// In that same directory, download the link for the card deck.
// Then click the application named CS4500 and the game then appears on the screen. 
// Team members are Grant Harris and Mihir Bhakta.
// Chief Programmer was Grant Harris.
// Ex team members are Noor Ghazal and Kanaan Sullivan.
// Authors of the code to set up the buttons were primarily Noor Ghazal and Kanaan Sullivan
// Author of the code to set up the patterns was primarily Grant Harris.
// Author of the code to create the winning reactions was primarily Mihir Bhatka.
// Class name is CMPSCI 4500: Intro to Software Profession
// Date of last Commit: April 25, 2024
// The central data structures are winforms, which are used for displaying messages and 
// for the process of selecting or dealing cards.
// External files include images for all 52 cards in a deck
// and the file CardsDealt.txt used to keep track of the cards that were dealt or chosen.
// There is also a file called LastWon.txt that must be made by the user and the user must enter the number
// 0 into that file before starting the game.
// Another external that must be empty before the program starts is CurrentPattern.txt.
// DO NOT EDIT IT YOURSELF!! If you do, then the user will easily use duplicate hands to win the same pattern.
// This program starts with a welcome message.The user clicks Next to start selecting cards.
// One by one, the user confirms each of the four cards separately.
// For each card selected, select one of the boxes containing the suit to select the suit
// and then the dropdown must be used to enter the value instead of typing in the value. Then select Confirm.
// Then the user presses Deal to confirm the hand of four cards from one deck of 52 cards.
// Simultaneously, the coloring of the screen changes where the highlighted cards
// are the ones that the computer chooses based on a pattern, who goes by the name of Art Dealer.
// then the computer puts these cards' information to the file listed above.
// The user's cards that were selected by the Art Dealer will be surrounded from left and right with asterisks.
// The user will then be reminded that changing any of the cards before selecting Next Round will not be used or recorded.
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
// In Deck.cs, all of the if statements for the pattern numbers are for storing information about the hand selected
// to the textfile called CardsDealt.txt and to box in the corner that displays history.
// In DrawCard.cs, all of the if statements for the pattern numbers are for highlighting the cards the Art Dealer selected
// , determining if a round is won, and if the pattern has been won.
// When a pattern is won, a small celebration sound is played after selecting Next Round. 
// When the whole game is won, a bigger celebration is made.
// For Patterns 1 through 5, the full logic is used in both Deck.cs and DrawCard.cs.
// For Pattern 6, a method is called to find the highest value but then Deck.cs and DrawCard.cs do the remaining logic.
// For Patterns 7 through 12, separate methods are created in Deck.cs to perform all the logic.
// Then the if statements call the method to then just do the logic that I listed 9 lines above.
// Pattern nine has two if statements in Deck.cs. The first one is for finding each set the ArtDealer selected and for
// letting the user know about each set it selects. The second if statement outputs the whole hand as normal.




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