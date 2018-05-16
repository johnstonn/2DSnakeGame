using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;


namespace Snake
{
    public partial class SnakeGameForm : Form
    {
        //instantiate the items.
        private List<Location> Snake = new List<Location>();
        private Location food = new Location();
        private string errorHandle;
        private int ticks;

        public SnakeGameForm()
            //initialises the objects on the form and then calls start Game method. 
        {
            InitializeComponent();
            lblinfo.Text = Settings.Speed.ToString();
            labeltimer.Text = "0";
            //Set settings to default (new game)
            new Settings();
            //Set game speed and start timer - cannot be divided by 0 as the user does not set the speed.  Error checking for futureproofing the program.
            try
            {
            gameTimer.Interval = 1000 / Settings.Speed;

            }
            catch (Exception e)
            {
                errorHandle = "error dividing the speed.  Make is speed 0?" + e.Message;
                ErrorCheck ec = new ErrorCheck();
                //pass the error to the error handler to be checked and logged.
                ec.outputError(errorHandle);
            }
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();
            //Start New game
            StartGame();
        }

        private void StartGame()
            //Sets the game settings, clears the screen then generates a new game.
        {
            //starts the timer.
            snakeTimer.Start();
            lblGameOver.Visible = false;
            //Set settings to default values.
            new Settings();
            //Create new player object
            Snake.Clear();
            Location head = new Location {X = 10, Y = 5};
            Snake.Add(head);
            lblScore.Text = Settings.Score.ToString();
            lblLevel.Text = Settings.ilvl.ToString();
            //calls the generate food method to place food on screen.
            CreateFood();
        }

        public void CreateFood()
            //Place random food object - randomly between the boundaries of pbCanvas.
        {
            //sets the boundaries for the food locations.
            int maxXPosition = pbCanvas.Size.Width / Settings.Width;
            int maxYPosition = pbCanvas.Size.Height / Settings.Height;
            //calls upon the random class to generate a random number (x and y)
            Random random = new Random();
            food = new Location {X = random.Next(0, maxXPosition), Y = random.Next(0, maxYPosition)};
        }

        private void UpdateScreen(object sender, EventArgs e)
            //refreshes/updates the screen with new directions to make the snake move correctly.
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
                {
                    Settings.direction = Direction.Right;
                }
                else if (Input.KeyPressed(Keys.Left) && Settings.direction != Direction.Right)
                {
                    Settings.direction = Direction.Left;
                }
                else if (Input.KeyPressed(Keys.Up) && Settings.direction != Direction.Down)
                {
                    Settings.direction = Direction.Up;
                }
                else if (Input.KeyPressed(Keys.Down) && Settings.direction != Direction.Up)
                {
                    Settings.direction = Direction.Down;
                }
                MovePlayer();
            }
            //stops the canvas from displaying shapes/objects.
            pbCanvas.Invalidate();
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
            //paints the snake (length of the snake) and the fruit.
        {
            Graphics canvas = e.Graphics;
            //if the settings are NOT game over the program will draw the snake and food.
            if (!Settings.GameOver)
            {
                //Draw snake
                for (int snakeLength = 0; snakeLength < Snake.Count; snakeLength++)
                {
                    Brush snakeColour;
                    if (snakeLength == 0)
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
                    canvas.FillRectangle(snakeColour, new Rectangle((Snake[snakeLength].X * Settings.Width), (Snake[snakeLength].Y * Settings.Height), Settings.Width, Settings.Height));
                    //Draw Food - ellipse shape
                    canvas.FillEllipse(Brushes.DarkOrange, new Rectangle((food.X * Settings.Width), (food.Y * Settings.Height), Settings.Width, Settings.Height));
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

        public void MovePlayer()
            //main movement of the snake across the canvas. 
        {
            for (int snakeSection = Snake.Count - 1; snakeSection >= 0; snakeSection--)
            {
                //Move head rectangle item.
                if (snakeSection == 0)
                {
                    //select switch to set the directions, only 4 options. ><^v
                    //X is horizontal axis and Y is verical
                    switch (Settings.direction)
                    {
                        case Direction.Right:
                            Snake[snakeSection].X++;
                            break;
                        case Direction.Left:
                            Snake[snakeSection].X--;
                            break;
                        case Direction.Up:
                            Snake[snakeSection].Y--;
                            break;
                        case Direction.Down:
                            Snake[snakeSection].Y++;
                            break;
                    }
                    //Get maximum X and Y positions, limited by the size of the canvas
                    int maxXPosition = pbCanvas.Size.Width / Settings.Width;
                    int maxYPosition = pbCanvas.Size.Height / Settings.Height;
                    //Detect collision with game borders 
                    //if snake x < 0 OR snake y < 0 etc invokes the Dead() method.
                    if (Snake[snakeSection].X < 0 || Snake[snakeSection].Y < 0 || Snake[snakeSection].X >= maxXPosition || Snake[snakeSection].Y >= maxYPosition)
                    {
                        Dead();
                    }
                    //Detect collision with body
                    for (int index = 1; index < Snake.Count; index++)
                    {
                        //if the location of any of the snake ([1] as head cannot collide with itself, to the end of body ) == the value of another X or Y of the body, 
                        //collision is detected.
                        if (Snake[snakeSection].X == Snake[index].X && Snake[snakeSection].Y == Snake[index].Y)
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
                    Snake[snakeSection].X = Snake[snakeSection - 1].X;
                    Snake[snakeSection].Y = Snake[snakeSection - 1].Y;
                }
            }
        }

        private void SnakeGameForm_KeyDown(object sender, KeyEventArgs e)
            //detects when a key is pressed.
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void SnakeGameForm_KeyUp(object sender, KeyEventArgs e)
            //detects when a key is no longer being pressed.
        {
            Input.ChangeState(e.KeyCode, false);
        }

        private void Eaten()
            //controls actions for when snake interacts with fruit object.
        {
            //Add circle to body
            Location circle = new Location
            {X = Snake[Snake.Count - 1].X,Y = Snake[Snake.Count - 1].Y};
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
            //method used to stop the game and run the post game functionality such as storing the score.
        {
            //stops the timer from continuing to count.
            snakeTimer.Stop();
            //important to handle any exception in File IO.
            try
            {
                Settings.GameOver = true;
                string str = Convert.ToString(Settings.Score);
                //do not store high scores, if they get 0, display the high scores.
                if (Settings.Score == 0)
                {
                    viewHighScores();
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
                errorHandle = "Error when saving file " + sc.Message;
                ErrorCheck ec = new ErrorCheck();
                //pass the error to the error handler to be checked and logged.
                ec.outputError(errorHandle);
            }
        }

        private void viewHighScores()
            //loads the highscores form.
        {
            ScoresForm frm = new ScoresForm();
            frm.Show();
        }

        private void snakeTimer_Tick(object sender, EventArgs e)
            //Controls for the snakeTimer, tracks the time spent on the game.
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
