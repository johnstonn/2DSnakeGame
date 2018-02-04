using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;


namespace Snake
{
    public partial class SnakeGame : Form
    {
        //instantiate the items.
        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();
        private Death deadfood = new Death();
        public SnakeGame()
        {
           

            InitializeComponent();
            lblinfo.Text = Settings.Speed.ToString();
            labeltimer.Text = "0";
            

            //Set settings to default (new game)
            new Settings();

            //Set game speed and start timer
            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            //Start New game
            StartGame();
        }

        private void StartGame()
        {
            
            //starts the timer.
            timer1.Start();


            lblGameOver.Visible = false;

            //Set settings to default values.
            new Settings();

            //Create new player object
            Snake.Clear();
            Circle head = new Circle {X = 10, Y = 5};
            Snake.Add(head);


            lblScore.Text = Settings.Score.ToString();
            lblLevel.Text = Settings.ilvl.ToString();
            //calls the generate food method to place food on screen.
            CreateFood();
            
            
        }
        

        //Place random food object
        private void CreateFood()
        {
            //sets the boundaries for the food locations.
            int maxXPosition = pbCanvas.Size.Width / Settings.Width;
            int maxYPosition = pbCanvas.Size.Height / Settings.Height;
            //calls upon the random class to generate a random number (x and y)
            Random random = new Random();
            food = new Circle {X = random.Next(0, maxXPosition), Y = random.Next(0, maxYPosition)};



        }

        #region deathfood -------------------------
        //Place random Deathfood object
        //private void GenerateDeadFood()
        //{
            
        //    int newmaxXPosition = pbCanvas.Size.Width / Settings.Width;
        //    int newmaxYPosition = pbCanvas.Size.Height / Settings.Height;

                        
        //    Random newrandom = new Random();

        //    deadfood = new Death { X1 = newrandom.Next(0, newmaxXPosition), Y1 = newrandom.Next(0, newmaxYPosition) };

            

        //    if (Settings.ilvl > 2)

        //    {
                
        //        deadfood = new Death { X1 = newrandom.Next(0, newmaxXPosition), Y1 = newrandom.Next(0, newmaxYPosition) };
        //        GenerateDeadFood();
        //    }
        //}
        #endregion



        private void UpdateScreen(object sender, EventArgs e)
        {
            //Check for Game Over
            if (Settings.GameOver)
            {
                //Check if Enter is pressed
                if (Input.KeyPressed(Keys.Enter))
                {
                    StartGame();
                }
            }
            else
            {
                //sets the direction (of the snake [0] head item.
                if (Input.KeyPressed(Keys.Right) && Settings.direction != Direction.Left)
                    Settings.direction = Direction.Right;
                else if (Input.KeyPressed(Keys.Left) && Settings.direction != Direction.Right)
                    Settings.direction = Direction.Left;
                else if (Input.KeyPressed(Keys.Up) && Settings.direction != Direction.Down)
                    Settings.direction = Direction.Up;
                else if (Input.KeyPressed(Keys.Down) && Settings.direction != Direction.Up)
                    Settings.direction = Direction.Down;

                MovePlayer();
            }
            //stops the canvas from displaying shapes/objects.
            pbCanvas.Invalidate();

        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            //if the settings are NOT game over the program will draw the snake and food.
            if (!Settings.GameOver)
            {

                //Draw snake
                for (int i = 0; i < Snake.Count; i++)
                {
                    Brush snakeColour;
                    if (i == 0)
                    //draw the snake
                    {
                        //draws the snakes head
                        snakeColour = Brushes.Black;
                    }
                    else
                    {
                        //draws the rest of the body
                        snakeColour = Brushes.ForestGreen;
                    }
                    //Draw snake - rectangle shape 
                   
                    canvas.FillRectangle(snakeColour, new Rectangle((Snake[i].X * Settings.Width), (Snake[i].Y * Settings.Height), Settings.Width, Settings.Height));


                    //Draw Food - ellipse shape
                    canvas.FillEllipse(Brushes.DarkOrange, new Rectangle((food.X * Settings.Width), (food.Y * Settings.Height), Settings.Width, Settings.Height));


                    #region Death food -----------
                    //if (ticks % 10 == 0)
                    //{
                    //    canvas.FillEllipse(Brushes.Black, new Rectangle(deadfood.X1 * Settings.Width, deadfood.Y1 * Settings.Height, Settings.Width, Settings.Height));



                    //}

                    //Draw DeadFood
                    //canvas.FillEllipse(Brushes.Black, new Rectangle(deadfood.X1 * Settings.Width, deadfood.Y1 * Settings.Height, Settings.Width, Settings.Height));

                    #endregion

                }
            }
            else
            {
                //when the game over is true, display the following messages.
                string gameOver = "Game over \nYour final score is: " + Settings.Score + "\nPress Enter to try again";
                lblGameOver.Text = gameOver;
                lblGameOver.Visible = true;
            }
        }


        private void MovePlayer()
        {
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                //Move head rectangle item.
                if (i == 0)
                {
                    //select switch to set the directions, only 4 options. ><^v
                    //X is horizontal axis and Y is verical
                    switch (Settings.direction)
                    {
                        case Direction.Right:
                            Snake[i].X++;
                            break;
                        case Direction.Left:
                            Snake[i].X--;
                            break;
                        case Direction.Up:
                            Snake[i].Y--;
                            break;
                        case Direction.Down:
                            Snake[i].Y++;
                            break;
                    }


                    //Get maximum X and Y positions, limited by the size of the canvas
                    int maxXPosition = pbCanvas.Size.Width / Settings.Width;
                    int maxYPosition = pbCanvas.Size.Height / Settings.Height;

                    //Detect collission with game borders 
                    //if snake x < 0 OR snake y < 0 etc invokes the Dead() method.
                    if (Snake[i].X < 0 || Snake[i].Y < 0 || Snake[i].X >= maxXPosition || Snake[i].Y >= maxYPosition)
                    {
                        Dead();
                    }


                    //Detect collission with body
                    //
                    for (int index = 1; index < Snake.Count; index++)
                    {
                        //if the location of any of the snake ([1] as head cannot collide with itself, to the end of body ) == the value of another X or Y of the body, 
                        //collision is detected.
                        if (Snake[i].X == Snake[index].X && Snake[i].Y == Snake[index].Y)
                        {
                            Dead();
                        }
                    }

                    //Detect collision with food piece (location 0 is the head piece) invoke Eaten method.
                    if (Snake[0].X == food.X && Snake[0].Y == food.Y)
                    {
                        Eaten();
                    }

                }
                else
                {
                    //Move body
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //detects when a key is pressed.
            Input.ChangeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //detects when a key is no longer being pressed.
            Input.ChangeState(e.KeyCode, false);
        }

        private void Eaten()
        {
            //Add circle to body
            Circle circle = new Circle
            {
                X = Snake[Snake.Count - 1].X,Y = Snake[Snake.Count - 1].Y
            };
            //adds the circle object to the snake.
            Snake.Add(circle);

            //Update Score
            Settings.Score += Settings.Points;
            lblScore.Text = Settings.Score.ToString();

            
            if (Settings.Score >0)
            {
                //level increased by 1
                Settings.ilvl++;
                //increased the speed by 10.
                Settings.Speed = Settings.Speed + 10;
                lblinfo.Text = "" + Settings.Speed;


                lblLevel.Text = ""+ Settings.ilvl.ToString();

            }
            //calls the create food method.
            CreateFood();

        }

        private void Dead()
        {
            //stops the timer from continuing to count.
            timer1.Stop();
            //important to handle any exception in File IO.
            try
            {
                Settings.GameOver = true;
              
                string str = Convert.ToString(Settings.Score);

                if (Settings.Score == 0)
                {
                    MessageBox.Show("You have scored 0");
                }
                else
                {
                    // To save a high score into the text file.
                    File.AppendAllText(@"C:\\Users\PHILO\Documents\SnakeHighscores.csv", str + Environment.NewLine);
                    viewHighScores();
                }
            }
            catch (Exception sc)
            {
                //throws an excpetion if the high score file is moved/corrupt.
                //can store this in a text file logging errors.
                string error = ("Error when saving file "+ sc.Message);
                File.AppendAllText(@"C:\\Users\PHILO\Documents\SnakeErrors.csv", error + Environment.NewLine);

            }

        }



        private void viewHighScores()
        {
            //loads the highscores form.
            Scores frm = new Scores();
            frm.Show();
        }


      //creates a timer tick counter.
        private int ticks;

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            ticks++;
            labeltimer.Text = ticks.ToString();
            
            // uses modulus to work out if this is a multiple of 10.
            if (ticks % 10 == 0)
            {

                Settings.Speed = Settings.Speed + 10;
                lblinfo.Text = "" + Settings.Speed;

                


            }

        }


    }
}
