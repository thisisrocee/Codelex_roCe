using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Minesweeper.Core
{
    public class Board
    {
        public Minesweeper Minesweeper { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int NumMines { get; set; }
        public int NumCells { get; set; }
        public Cell[,] Cells { get; set; }

        public Board(Minesweeper minesweeper, int width, int height, int mines)
        {
            Minesweeper = minesweeper;
            Width = width;
            Height = height;
            NumMines = mines;
            Cells = new Cell[width, height];
        }

        public void SetupBoard()
        {
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    var c = new Cell
                    {
                        XLoc = i,
                        YLoc = j,
                        CellState = CellState.Closed,
                        CellType = CellType.Regular,
                        CellSize = 40,
                        Board = this
                    };

                    c.SetupDesign();
                    c.MouseDown += Cell_MouseClick;
                    c.Top += 70;

                    NumCells++;

                    Cells[i, j] = c;
                    Minesweeper.Controls.Add(c);
                }
            }

            NumCells -= NumMines;
        }

        private void Cell_MouseClick(object sender, MouseEventArgs e)
        {
            var cell = (Cell) sender;

            if (cell.CellState == CellState.Opened)
                return;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    Minesweeper.timer1.Enabled = true;
                    cell.OnClick();
                    break;

                case MouseButtons.Right:
                    cell.OnFlag();
                    Minesweeper.bombLabel.Text = NumMines.ToString();
                    break;

                default:
                    return;
            }
        }

        public void PlaceMines()
        {
            var random = new Random();
            var mineCount = 0;

            while (mineCount < NumMines)
            {
                var x = random.Next(Width);
                var y = random.Next(Height);

                if (Cells[x, y].CellType != CellType.Mine)
                {
                    Cells[x, y].CellType = CellType.Mine;
                    mineCount++;
                }
            }
        }

        public bool EndGame(bool win)
        {
            Minesweeper.timer1.Stop();
            NumMines = 0;
            Minesweeper.bombLabel.Text = NumMines.ToString();

            foreach (var cell in Cells)
            {
                if (cell.CellType == CellType.Mine || cell.CellType == CellType.FlaggedMine)
                {
                    cell.CellState = CellState.Opened;
                    cell.Text = "@";
                    cell.ForeColor = Color.Black;
                }
                else
                {
                    cell.CountMinesAround();

                    cell.CellState = CellState.Opened;
                    cell.BackColor = Color.LightGray;
                    cell.UseVisualStyleBackColor = true;

                    if (cell.NumMinesAround == 0)
                    {
                        cell.IterateNeighbors(c =>
                        {
                            if (c.CellState == CellState.Closed)
                            {
                                c.OnClick(true);
                            }
                        });
                    }
                }
            }

            if (win)
            {
                MessageBox.Show("Congratulations, you won!");
                return true;
            }
            else
            {
                MessageBox.Show("Sorry, you lost.");
                return false;
            }
        }
    }
}
