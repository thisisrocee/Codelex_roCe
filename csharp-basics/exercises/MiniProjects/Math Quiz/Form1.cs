using System;
using System.Drawing;
using System.Windows.Forms;

namespace Math_Quiz
{
    public partial class Form1 : Form
    {
        Random rand = new Random();

        int addend1;
        int addend2;
        int minuend;
        int subtrahend;
        int multiplicand;
        int multiplier;
        int dividend;
        int divisor;
        int timeLeft;

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click_1(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        public void StartTheQuiz()
        {
            addend1 = rand.Next(51);
            addend2 = rand.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            sum.Value = 0;

            minuend = rand.Next(1, 101);
            subtrahend = rand.Next(1, minuend);

            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            multiplicand = rand.Next(2, 11);
            multiplier = rand.Next(2, 11);

            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            divisor = rand.Next(2, 11);
            var temporaryQuotient = rand.Next(2, 11);
            dividend = divisor * temporaryQuotient;

            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            timeLabel.BackColor = Color.White;
            timeLeft = 30;
            timeLabel.Text = $"{timeLeft} seconds";
            timer1.Start();
        }

        private bool CheckTheAnswer()
        {
            if (addend1 + addend2 == sum.Value
                && minuend - subtrahend == difference.Value
                && multiplicand * multiplier == product.Value
                && dividend / divisor == quotient.Value)
                return true;
            return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                    "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
                if (timeLeft <= 5)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            var answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                var lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void right_Value(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (CheckTheAnswer() && answerBox.Value == (int)answerBox.Tag)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\User\Downloads\ding.mp3");
                player.Play();
            }
        }
    }
}
