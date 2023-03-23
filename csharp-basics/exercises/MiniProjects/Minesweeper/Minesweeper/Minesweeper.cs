using Minesweeper.Core;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Minesweeper : Form
    {
        private int _startTime;
        private Minesweeper _game;
        public Minesweeper()
        {
            InitializeComponent();
            
            var board = new Board(this, 9, 9, 10);
            board.SetupBoard();
            board.PlaceMines();

            bombLabel.Text = board.NumMines.ToString();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            _startTime++;
            timeLabel.Text = $"{_startTime}";
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Hide();
            _game = new Minesweeper();
            _game.Show();
        }
    }
}
