/* Program Name: Hearts Game
   Program Description: This is the Program Class for this Hearts Game
   File Name: Program.cs
   Program Authors: Group 5 
   Program Date: April 1st, 2024
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeartsCardGame
{
    /// <summary>
    ///  progam class or runner class for the whole project
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Run the Hearts game
            Application.Run(new HeartsGame());
        }
    }
}
