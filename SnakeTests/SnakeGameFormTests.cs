using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Tests
{
    [TestClass()]
    public class SnakeGameFormTests
    {
        [TestMethod()]
        public void CreateFoodTest()
        {
            ////sets the boundaries for the food locations.
            //int maxXPosition = pbCanvas.Size.Width / Settings.Width;
            //int maxYPosition = pbCanvas.Size.Height / Settings.Height;
            ////calls upon the random class to generate a random number (x and y)
            //Random random = new Random();
            //food = new Location { X = random.Next(0, maxXPosition), Y = random.Next(0, maxYPosition) };


            //arrange
            //act
            //assert

        }

        [TestMethod()]
        public void MovePlayerTest()
        {
            //for (int snakeSection = Snake.Count - 1; snakeSection >= 0; snakeSection--)
            //{
            //    //Move head rectangle item.
            //    if (snakeSection == 0)
            //    {
            //        //select switch to set the directions, only 4 options. ><^v
            //        //X is horizontal axis and Y is verical
            //        switch (Settings.direction)
            //        {
            //            case Direction.Right:
            //                Snake[snakeSection].X++;
            //                break;
            //            case Direction.Left:
            //                Snake[snakeSection].X--;
            //                break;
            //            case Direction.Up:
            //                Snake[snakeSection].Y--;
            //                break;
            //            case Direction.Down:
            //                Snake[snakeSection].Y++;
            //                break;
            //        }
            //        //Get maximum X and Y positions, limited by the size of the canvas
            //        int maxXPosition = pbCanvas.Size.Width / Settings.Width;
            //        int maxYPosition = pbCanvas.Size.Height / Settings.Height;
            //        //Detect collision with game borders 
            //        //if snake x < 0 OR snake y < 0 etc invokes the Dead() method.
            //        if (Snake[snakeSection].X < 0 || Snake[snakeSection].Y < 0 || Snake[snakeSection].X >= maxXPosition || Snake[snakeSection].Y >= maxYPosition)
            //        {
            //            Dead();
            //        }
            //        //Detect collision with body
            //        for (int index = 1; index < Snake.Count; index++)
            //        {
            //            //if the location of any of the snake ([1] as head cannot collide with itself, to the end of body ) == the value of another X or Y of the body, 
            //            //collision is detected.
            //            if (Snake[snakeSection].X == Snake[index].X && Snake[snakeSection].Y == Snake[index].Y)
            //            {
            //                Dead();
            //            }
            //        }
            //        //Detect collision with food piece (location 0 is the head piece) invoke Eaten method.
            //        if (Snake[0].X == food.X && Snake[0].Y == food.Y)
            //        {
            //            Eaten();
            //        }
            //    }
            //    else
            //    {
            //        //Move body
            //        Snake[snakeSection].X = Snake[snakeSection - 1].X;
            //        Snake[snakeSection].Y = Snake[snakeSection - 1].Y;
            //    }
            //}

        }
    }
}