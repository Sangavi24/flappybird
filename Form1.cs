using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappybird
{
    public partial class Form1 : Form
    {
        int pipespeed = 8;
        int gravity = 5;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            FlappyBird.Top += gravity;
            pipeBottom.Left -= pipespeed;
            pipeTop.Left -= pipespeed;
            ScoreText.Text = score.ToString();
            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                score++;
            }
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 950;
                score++;
            }
            if (FlappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || FlappyBird.Bounds.IntersectsWith(pipeTop.Bounds) || FlappyBird.Bounds.IntersectsWith(Ground.Bounds))
            {
                endGame();
            }
            if(score>5)
            {
                pipespeed = 15;
            }
            if(FlappyBird.Top<-25)
            {
                endGame(); 
            }
        }

        private void endGame()
        {
            GameTimer.Stop();
            ScoreText.Text += " Game over!!!";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gameKeyisUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }

        private void gameKeyisDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }
        }
    }
}
