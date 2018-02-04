namespace Snake
{
    public enum Direction
    {
        //sets the values that can be used for a direction.
        Up,
        Down,
        Left,
        Right
    };


    public class Settings
    {
        //internal static int score;

        //This sets the variables to be invoked by the Settings.  No danger of data stolen so no need to pass fields and properties.
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static int Score { get; set; }
        public static int Speed { get; set; }
        public static int Points { get; set; }
        public static bool GameOver { get; set; }
        public static Direction direction { get; set; }
        public static int ilvl { get; set; }

        public Settings()
        {
            //This defines the values to the settings.  Speed is 20 so it looks more fluid.
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
