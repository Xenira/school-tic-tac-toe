using System.Linq;

namespace TickTackToe
{
    /// <summary>
    /// Game logic for tic tac toe game
    /// </summary>
    class Game
    {
        public char[] playerSymbols { get; } = { 'X', 'O', ' ' };

        public bool?[,] field { get; private set; } = new bool?[3, 3];
        public int[] cursor { get; private set; } = { 0, 0 };

        public bool currentPlayer = false;
        public bool? winner { get; private set; } = null;
        public bool isGameRunning { get; private set; } = true;

        public int[][] winnables =
        {
            new int[]{0,1,2}, // Vertical
            new int[]{3,4,5},
            new int[]{6,7,8},
            new int[]{0,3,6}, // Horicontal
            new int[]{1,4,7},
            new int[]{2,5,8},
            new int[]{0,4,8}, // Diagonal
            new int[]{2,4,6}
        };

        /// <summary>
        /// Places marker of the current player at current cursor position
        /// </summary>
        /// <returns>false if already a marker at cursor position or game is won,
        /// true otherwise</returns>
        public bool SetMarker()
        {
            // Prevent overwriting symbols
            if (field[cursor[0], cursor[1]].HasValue || !isGameRunning) return false;

            // Set field marker and change current player
            field[cursor[0], cursor[1]] = currentPlayer;
            currentPlayer = !currentPlayer;
            CheckGameStatus();
            return true;
        }

        /// <summary>
        /// Moves the cursor by increment of 1 in x / y direction
        /// </summary>
        /// <param name="x">Move the x position</param>
        /// <param name="y">Move the y position</param>
        /// <remarks>Does nothing if x or y are more than 1 / -1 or would move the cursor outside of the field</remarks>
        public void MoveCursor(int x, int y)
        {
            // Check if values are in bound
            if (x < -1 || x > 1 || y < -1 || y > 1) return;
            if (cursor[0] + x < 0 || cursor[0] + x > 2) return;
            if (cursor[1] + y < 0 || cursor[1] + y > 2) return;

            // Set cursor position
            cursor[0] += x;
            cursor[1] += y;
        }

        /// <summary>
        /// Checks if a player has won and returns that player
        /// </summary>
        /// <returns>The winning player. Has no value when no player has won.</returns>
        public bool? GetWinner()
        {
            if (!isGameRunning) return winner;
            CheckGameStatus();
            return winner;
        }

        /// <summary>
        /// Checks if the game is won by either player and sets the winner property if winner is found.
        /// </summary>
        public void CheckGameStatus()
        {
            if (!isGameRunning) return;

            // Finish game when all fields are occupied
            if (!field.Cast<bool?>().Any(v => !v.HasValue)) { this.isGameRunning = false; }
            foreach (var position in winnables)
            {
                // When first field is not set this combination is unable to win
                var field0 = field[position[0] % 3, position[0] / 3];
                if (!field0.HasValue) continue;

                var field1 = field[position[1] % 3, position[1] / 3];
                var field2 = field[position[2] % 3, position[2] / 3];

                if (field0 == field1 && field0 == field2)
                {
                    isGameRunning = false;
                    winner = field0;
                }
            }
        }
    }
}
