using System;

namespace TicTacToe
{
    class Program
    {
        private static char[,] board = new char[3, 3];
        private static bool gameEnd = false;

        static void Main(string[] args)
        {
            InitBoard();
            DisplayBoard();

            char currentPlayer = 'X';
            while (!gameEnd)
            {
                Console.Write($"'{currentPlayer}', choose your location (row, column): ");
                string userInput = Console.ReadLine();
                int row, col;

                if (!ParseInput(userInput, out row, out col))
                {
                    Console.WriteLine("Invalid input. Try again.");
                    continue;
                }

                if (!IsValidMove(row, col))
                {
                    Console.WriteLine("Invalid move. Try again.");
                    continue;
                }

                board[row, col] = currentPlayer;
                DisplayBoard();

                if (IsWinningMove(currentPlayer, row, col))
                {
                    Console.WriteLine($"'{currentPlayer}' wins!");
                    gameEnd = true;
                }
                else if (IsBoardFull())
                {
                    Console.WriteLine("The game is a tie.");
                    gameEnd = true;
                }
                else
                {
                    currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                }
            }
        }

        private static void InitBoard()
        {
            for (var r = 0; r < 3; r++)
            {
                for (var c = 0; c < 3; c++)
                    board[r, c] = ' ';
            }
        }

        private static void DisplayBoard()
        {
            Console.WriteLine("  0  " + board[0, 0] + "|" + board[0, 1] + "|" + board[0, 2]);
            Console.WriteLine("    --+-+--");
            Console.WriteLine("  1  " + board[1, 0] + "|" + board[1, 1] + "|" + board[1, 2]);
            Console.WriteLine("    --+-+--");
            Console.WriteLine("  2  " + board[2, 0] + "|" + board[2, 1] + "|" + board[2, 2]);
            Console.WriteLine("    --+-+--");
        }

        private static bool ParseInput(string input, out int row, out int col)
        {
            row = -1;
            col = -1;
            var parts = input.Split(' ');
            if (parts.Length != 2)
            {
                return false;
            }

            if (!int.TryParse(parts[0], out row) || row < 0 || row >= 3)
            {
                return false;
            }

            if (!int.TryParse(parts[1], out col) || col < 0 || col >= 3)
            {
                return false;
            }
            return true;
        }

        private static bool IsValidMove(int row, int col)
        {
            return board[row, col] == ' ';
        }

        private static bool IsWinningMove(char player, int row, int col)
        {
            return (board[row, 0] == player && board[row, 1] == player && board[row, 2] == player) || // row
                   (board[0, col] == player && board[1, col] == player && board[2, col] == player) || // column
                   (row == col && board[0, 0] == player && board[1, 1] == player &&
                    board[2, 2] == player) || // diagonal
                   (row + col == 2 && board[0, 2] == player && board[1, 1] == player &&
                    board[2, 0] == player); // anti-diagonal
        }

        private static bool IsBoardFull()
        {
            for (var r = 0; r < 3; r++)
            {
                for (var c = 0; c < 3; c++)
                {
                    if (board[r, c] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}