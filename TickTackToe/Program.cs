using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TickTackToe
{
    /// <summary>
    /// Main Class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Current game. Starts new game at startup.
        /// </summary>
        public static Game g = new Game();

        #region Display strings
        static int displayTimer = 0;

        static readonly string[] title =
        {
            "Tic",
            "Tac",
            "Toe",
            ""
        };

        const string player1win = @"
 __________.__                               ____   __      __.__               
 \______   \  | _____  ___.__. ___________  /_   | /  \    /  \__| ____   ______
  |     ___/  | \__  \<   |  |/ __ \_  __ \  |   | \   \/\/   /  |/    \ /  ___/
  |    |   |  |__/ __ \\___  \  ___/|  | \/  |   |  \        /|  |   |  \\___ \ 
  |____|   |____(____  / ____|\___  >__|     |___|   \__/\  / |__|___|  /____  >
                     \/\/         \/                      \/          \/     \/ ";

        const string player2win = @"
 __________.__                              ________    __      __.__               
 \______   \  | _____  ___.__. ___________  \_____  \  /  \    /  \__| ____   ______
  |     ___/  | \__  \<   |  |/ __ \_  __ \  /  ____/  \   \/\/   /  |/    \ /  ___/
  |    |   |  |__/ __ \\___  \  ___/|  | \/ /       \   \        /|  |   |  \\___ \ 
  |____|   |____(____  / ____|\___  >__|    \_______ \   \__/\  / |__|___|  /____  >
                     \/\/         \/                \/        \/          \/     \/ ";

        const string draw = @"
 ________                       
 \______ \____________ __  _  __
  |    |  \_  __ \__  \\ \/ \/ /
  |    `   \  | \// __ \\     / 
 /_______  /__|  (____  /\/\_/  
         \/           \/        ";

        const string getRekt = @"
   ________        __    __________        __      __    ._. ._.  ____ 
  /  _____/  _____/  |_  \______   \ ____ |  | ___/  |_  | | | | /_   |
 /   \  ____/ __ \   __\  |       _// __ \|  |/ /\   __\ | | | |  |   |
 \    \_\  \  ___/|  |    |    |   \  ___/|    <  |  |    \|  \|  |   |
  \______  /\___  >__|    |____|_  /\___  >__|_ \ |__|    __  __  |___|
         \/     \/               \/     \/     \/         \/  \/       ";
        #endregion

        /// <summary>
        /// Start game update loop
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Task.Run((Action)HandleInput);
            while (true)
            {
                drawGame();
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Draws game or win screen
        /// Sets game title
        /// </summary>
        public static void drawGame()
        {
            displayTimer++;
            if (displayTimer >= int.MaxValue) displayTimer = int.MinValue;
            Console.Title = title[displayTimer % 16 / 4];

            if (!g.isGameRunning)
            {
                drawWin(g.winner);
                return;
            }
            drawField();
        }

        /// <summary>
        /// Handles player input
        /// </summary>
        /// <param name="consoleKeyInfo">
        /// ENTER / SPACEBAR: Place marker on board
        /// ARROW / WASD / NUMPAD: Move cursor
        /// F5: Start new game
        /// ESCAPE: Exit</param>
        public static void HandleInput()
        {
            while (true)
            {
                var consoleKeyInfo = Console.ReadKey(true);
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (!g.isGameRunning) break;
                        if (!g.SetMarker())
                        {
                            Console.Write("Cant place marker at this position"); Console.Beep(); Console.Beep();
                        }
                        else
                        {
                            Console.Beep();
                            Console.Write("                                  ");
                        }
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        g.MoveCursor(0, -1);
                        break;
                    case ConsoleKey.NumPad8:
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        g.MoveCursor(-1, 0);
                        break;
                    case ConsoleKey.NumPad6:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        g.MoveCursor(0, 1);
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        g.MoveCursor(1, 0);
                        break;
                    case ConsoleKey.F5:
                        Console.Clear();
                        g = new Game();
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        /// <summary>
        /// Prints the field to the console
        /// Starts at Position 0/0
        /// Does not clear console!
        /// </summary>
        public static void drawField()
        {
            Console.SetCursorPosition(0, 0);
            Console.WindowHeight = 6;
            Console.BufferHeight = 6;
            Console.WindowWidth = 35;
            Console.BufferWidth = 35;
            Thread.Sleep(10);
            Console.WriteLine($"Player {Convert.ToInt32(g.currentPlayer) + 1}'s Turn");

            for (int i = 0; i < g.field.GetLength(0); i++)
            {
                var isSelectedRow = g.cursor[0] == i;
                for (int j = 0; j < g.field.GetLength(1); j++)
                {
                    if (isSelectedRow && g.cursor[1] == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write($" [{(g.field[i, j].HasValue ? g.playerSymbols[Convert.ToInt32(g.field[i, j])] : g.playerSymbols[2])}] ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Draws win screen
        /// </summary>
        /// <param name="winner">
        /// false: Player 1 is winner
        /// true: Player 2 is winner
        /// null: Draw</param>
        public static void drawWin(bool? winner)
        {
            Console.WindowHeight = 8;
            Console.BufferHeight = 8;
            Console.Clear();
            if (!winner.HasValue)
            {
                Console.WindowWidth = 34;
                Console.BufferWidth = 34;
                Console.Write(draw);
                return;
            }
            else
            {
                if (displayTimer % 16 < 8)
                {
                    Console.Write(getRekt);
                    return;
                }

                if (!winner.Value)
                {
                    Console.WindowWidth = 82;
                    Console.BufferWidth = 82;
                    Console.Write(player1win);
                }
                else
                {
                    Console.WindowWidth = 86;
                    Console.BufferWidth = 86;
                    Console.Write(player2win);
                }

                if (displayTimer % 4 == 0) Console.Beep();
            }
        }
    }
}
