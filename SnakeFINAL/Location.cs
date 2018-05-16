namespace Snake
{
    class Location
    {
        //All moving items, food and snake will have an x and y co-ordinate as a location.
        public int X { get; set; }
        public int Y { get; set; }

        public Location ()
            //location of the X and Y co-ordinates
        {
            X = 0;
            Y = 0;
        }
    }
}
