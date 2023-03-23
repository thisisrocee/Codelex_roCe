using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper.Core
{
    public enum CellType
    {
        Regular, Mine, Flagged, FlaggedMine
    }

    public enum CellState
    {
        Opened, Closed
    }

    public class Cell : Button
    {
        public int XLoc { get; set; }
        public int YLoc { get; set; }
        public int CellSize { get; set; }
        public CellState CellState { get; set; }
        public CellType CellType { get; set; }
        public int NumMinesAround { get; set; }
        public Board Board { get; set; }

        public void SetupDesign()
        {
            //BackColor = SystemColors.ButtonFace;
            Location = new Point(XLoc * CellSize, YLoc * CellSize);
            Size = new Size(CellSize, CellSize);
            UseVisualStyleBackColor = false;
            Font = new Font("Verdana", 15.75F, FontStyle.Bold);
        }

        public void OnFlag()
        {
            if (CellState == CellState.Closed && CellType == CellType.Regular)
            {
                CellType = CellType.Flagged;
                Board.NumMines--;
                Text = "F";
                ForeColor = Color.Red;
            }
            else if (CellState == CellState.Closed && CellType == CellType.Mine)
            {
                CellType = CellType.FlaggedMine;
                Board.NumMines--;
                Text = "F";
                ForeColor = Color.Red;
            }
            else if (CellType == CellType.Flagged)
            {
                CellType = CellType.Regular;
                Board.NumMines++;
                Text = "";
            }
            else if (CellType == CellType.FlaggedMine)
            {
                CellType = CellType.Mine;
                Board.NumMines++;
                Text = "";
            }
        }

        public void OnClick(bool recursiveCall = false)
        {
            if (CellType == CellType.Mine || CellType == CellType.FlaggedMine)
            {
                BackColor = Color.Red;
                Board.EndGame(false);
                return;
            }

            CellState = CellState.Opened;
            BackColor = Color.LightGray;
            UseVisualStyleBackColor = true;
            Board.NumCells--;

            if (Board.NumCells == 0)
            {
                Board.EndGame(true);
            }

            CountMinesAround();

            if (NumMinesAround == 0)
            {
                IterateNeighbors(cell =>
                {
                    if (cell.CellState == CellState.Closed)
                    {
                        cell.OnClick(true);
                    }
                });
            }
        }

        public void CountMinesAround()
        {
            var count = 0;

            IterateNeighbors(cell =>
            {
                if (cell.CellType == CellType.Mine || cell.CellType == CellType.FlaggedMine)
                {
                    count++;
                }
            });

            NumMinesAround = count;

            if (count > 0)
            {
                Text = count.ToString();
                ForeColor = GetCellColour();
            }
        }

        public void IterateNeighbors(Action<Cell> action)
        {
            for (var x = XLoc - 1; x <= XLoc + 1; x++)
            {
                for (var y = YLoc - 1; y <= YLoc + 1; y++)
                {
                    if (x >= 0 && x < Board.Width && y >= 0 && y < Board.Height)
                    {
                        action(Board.Cells[x, y]);
                    }
                }
            }
        }

        private Color GetCellColour()
        {
            switch (NumMinesAround)
            {
                case 1:
                    return ColorTranslator.FromHtml("0x0000FE"); // 1
                case 2:
                    return ColorTranslator.FromHtml("0x186900"); // 2
                case 3:
                    return ColorTranslator.FromHtml("0xAE0107"); // 3
                case 4:
                    return ColorTranslator.FromHtml("0x000177"); // 4
                case 5:
                    return ColorTranslator.FromHtml("0x8D0107"); // 5
                case 6:
                    return ColorTranslator.FromHtml("0x007A7C"); // 6
                case 7:
                    return ColorTranslator.FromHtml("0x902E90"); // 7
                case 8:
                    return ColorTranslator.FromHtml("0x000000"); // 8
                default:
                    return ColorTranslator.FromHtml("0xffffff");
            }
        }
    }
}