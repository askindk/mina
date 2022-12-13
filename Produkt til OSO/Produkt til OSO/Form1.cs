using System;
using System.Windows.Forms;

namespace Produkt_til_OSO
{
    public partial class Form1 : Form
    {

        bool goLeft, goRight, jumping, isGameOver;

        int jumpspeed;
        int force;
        int score = 0;
        int playerSpeed = 7;

        int horizontalSpeed = 5;
        int verticalSpeed = 5;

        int enemyOneSpeed = 5;
        int enemyTwoSpeed = 5;
        int enemyThreeSpeed = 5;
        int enemyFourSpeed = 5;
        private object gameTimer;

        public Form1()
        {
            InitializeComponent();
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score " + score;

            player.Top += jumpspeed;

            if (goLeft == true)
            {
                player.Left -= playerSpeed;
            }
            if (goRight == true)
            {
                player.Left += playerSpeed;
            }

            if (jumping == true && force < 0)
            {
                jumping = false;
            }

            if (jumping == true)
            {
                jumpspeed = -8;
                force -= 1;
            }
            else
            {
                jumpspeed = 10;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "platform")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 8;
                            player.Top = x.Top - player.Height;


                            if ((string)x.Name == "movingWall1" && goLeft == false || (string)x.Name == "movingWall1" && goRight == false)
                            {
                                player.Left -= horizontalSpeed; 
                            }
                        }
                        
                            

                           
                         

                       x.BringToFront();

                    }

                    if ((string)x.Tag == "coin")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            score++;
                        }
                    }


                    if ((string)x.Tag == "enemy")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            gmeTimer.Stop();
                            isGameOver = true;
                            txtScore.Text = "Score: " + score + Environment.NewLine + "You Died";
                        }
                    }
                }
            }
            movingWall1.Left -= horizontalSpeed;

            if (movingWall1.Left < 0 || movingWall1.Left + movingWall1.Width > this.ClientSize.Width)
            {
               horizontalSpeed = -horizontalSpeed;
            }
            movingWall2.Top += verticalSpeed;

            if (movingWall2.Top < 195 || movingWall2.Top > 360)
            {
                verticalSpeed = -verticalSpeed;
            }

            enemyOne.Left -= enemyOneSpeed;
            if (enemyOne.Left < pictureBox5.Left || enemyOne.Left + enemyOne.Width > pictureBox5.Left + pictureBox5.Width)
            {
                enemyOneSpeed = -enemyOneSpeed;
            }

            enemyTwo.Left += enemyOneSpeed;

            if (enemyTwo.Left < pictureBox9.Left || enemyTwo.Left + enemyTwo.Width > pictureBox9.Left + pictureBox9.Width)
            {
                enemyTwoSpeed = -enemyTwoSpeed;
            }

            enemyFour.Left += enemyOneSpeed;

            if (enemyFour.Left < pictureBox6.Left || enemyFour.Left + enemyFour.Width > pictureBox6.Left + pictureBox9.Width)
            {
                enemyFourSpeed = -enemyFourSpeed;
            }


            if (player.Top + player.Height > this.ClientSize.Height + 50)
            {
                gmeTimer.Stop();
                isGameOver = true;
                txtScore.Text = "Score: " + score + Environment.NewLine + "You Fell to your Death";
            }

            if (player.Bounds.IntersectsWith(door.Bounds) && score == 4)
            {
                gmeTimer.Stop();
                isGameOver = true;
                txtScore.Text = "Score: " + score + Environment.NewLine + "You have Escaped!";
            }
            else
            {
                txtScore.Text = "Score: " + score + Environment.NewLine + "You need 4 coins";
            }

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (jumping == true)
            {
                jumping = false;
            }

            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                RestartGame();
            }

        }

        private void RestartGame()
        {

            jumping = false;
            goLeft = false;
            goRight = false;
            isGameOver = false;
            score = 0;

            txtScore.Text = "Score: " + score;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }

            player.Left = 10;
            player.Top = 665;

            enemyOne.Left = 243;
            enemyTwo.Left = 423;
            enemyFour.Left = 109;

            movingWall1.Top = 604;
            movingWall1.Left = 827;
            movingWall2.Top = 322;

            gmeTimer.Start();

        }





    }
}
