using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Snake
{
    class ErrorCheck
       //writes error with a log of the date the error was logged.
    {
        StreamWriter sw = new StreamWriter(@"C:\Users\PHILO\My Documents\SnakeErrors.txt");
        public void outputError(string error)
            //outputs the error message to a text file and logs both the error and the time/date of the error.
        {
            try
            {
            while (error != null)
            {
                sw.WriteLine("Error logged as " + error + " on " + DateTime.Now);
            }
            sw.Close();
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
