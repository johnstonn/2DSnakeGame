namespace Snake
{
    public enum Direction
        //sets the values that can be used for a direction.
    {
        Up,
        Down,
        Left,
        Right
    };
    public class Settings
        //Setting the variables to be invoked.  No danger of data stolen so no need to pass fields and properties.
    {
            //Width and Height refer to the playing canvas.
        public static int Width { get; set; }
        public static int Height { get; set; }
            //score is set to 0 to begin.
        public static int Score { get; set; }
            //Speed is how fast the snake travels.
        public static int Speed { get; set; }
        public static int Points { get; set; }
            //True or false, is it game over or not?
        public static bool GameOver { get; set; }
            //sets the direction of the snake (up, down, left, right)
        public static Direction direction { get; set; }
        public static int ilvl { get; set; }
        public Settings()
            //Defines the numeric values to the settings
        {
            //Speed is 20 so it looks more fluid (cannot be 0 as divisible by 0 error).
            Width = 15;
            Height = 15;
            Score = 0;
            Speed = 20;
            Points = 100;
            GameOver = false;
            //starting position down.
            direction = Direction.Down;
            ilvl = 0;
        }
    }
}
