using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Snake
{
    class ReadWriteFunction
    {
        private int NumberOfScores;
        private string error;
        public int counting(int score)
            //Property used to protect the field
        {
            {
                //returns the value of count to Count.
                return NumberOfScores = score;
            }
        }
        public void ReadFromFile(int[] numbers, ScoresForm f3)
            //Reads the HighScores from the text file.  Counts how many HighScores there are.
        {
            try
            {
                //if the file doesn't exist, we get an exception.
                StreamReader sr = new StreamReader(@"C:\\Users\PHILO\Documents\SnakeHighscores.csv");
                int numOfScores = 0;
                //while streamreader object is not empty, it will read a line in.
                while (sr.ReadLine() != null)
                {
                    for (int index = 0; index < numbers.Length; index++)
                    {
                        numOfScores = numOfScores + 1;

                        //convert from the sr to the index within the array numbers.
                        numbers[index] = Convert.ToInt32(sr.ReadLine());
                        //This allows the program to access the listbox from array.
                        f3.lstHighScores.Items.Add(numbers[index]);
                    }
                }
                //close the file when it is completed.
                sr.Close();
                //passes the value of count to the method counting to be displayed on user form.
                counting(numOfScores);
            }
            catch (Exception e)
            {
                error = ("The following error occured reading from file " + e.Message);
                File.AppendAllText(@"C:\\Users\PHILO\Documents\SnakeErrors.csv", error + Environment.NewLine);
                //could do a e.StackTrace   (e.StackTrace)
            }
        }
    }
}
