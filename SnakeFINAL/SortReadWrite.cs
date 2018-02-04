using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Snake
{
    class SortReadWrite
    {
        public int Count;
        public string error;

        public int counting(int x)
        {
            {
                //returns the value of count to Count.
                return Count = x;
            }
        }

        public void ReadFromFile(int[] numbers, Scores f3)
        {
            try
            {
                //if the file doesn't exist, we get an exception.
                // string path = @"C:\\Users\PHILO\Documents\numbers.csv";
                StreamReader sr = new StreamReader(@"C:\\Users\PHILO\Documents\SnakeHighscores.csv");
                int count = 0;

                //while streamreader object is not empty, it will read a line in.
                while (sr.ReadLine() != null)
                {
                    for (int index = 0; index < numbers.Length; index++)
                    {
                        count = count + 1;

                        //convert from the sr to the index within the array numbers.
                        numbers[index] = Convert.ToInt32(sr.ReadLine());
                        //This allows the program to access the listbox from array.
                        f3.listBox1.Items.Add(numbers[index]);
                    }
                }
                //close the file when it is completed.
                sr.Close();
                //passes the value of count to the method counting to be displayed on user form.
                counting(count);
            }
            catch (Exception e)
            {
                error = ("The following error occured reading from file " + e.Message);
                File.AppendAllText(@"C:\\Users\PHILO\Documents\SnakeErrors.csv", error + Environment.NewLine);
                //could do a e.StackTrace   (e.StackTrace)
            }
        }

        public void BubbleSort(int[] numbers, Scores f3)
        //sorting Highest to Lowest to display the high scores.
        {
            bool swap;
            int temp;
            {
                //do while loop, execute the following while swap == true.
                do
                {
                    //sets the flag to false, will be switched to true if a swap is made.
                    swap = false;
                    //does the bubble sort until numbers -1 as once initial pass is done, only 1 comparison can be made/moved.
                    for (int i = 0; i < (numbers.Length - 1); i++)
                    {
                        //could change this to > if was low-high
                        if (numbers[i] < numbers[i + 1])
                        {
                            //swapping the items using a temporary storage variable.
                            temp = numbers[i];
                            numbers[i] = numbers[i + 1];
                            numbers[i + 1] = temp;
                            //set the flag to true.
                            swap = true;
                        }
                    }
                }
                while (swap == true);
            }
            //refreshes the listbox
            f3.listBox1.Refresh();

            for (int index = 0; index < numbers.Length; index++)
            {
                //key to adding the sorted array back into the listbox from the array.
                f3.listBox1.Items.Add(numbers[index]);
            }

        }


    }
}
