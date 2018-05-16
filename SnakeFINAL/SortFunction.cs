using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    public class SortFunction
    {
        public void BubbleSort(int[] numbers)
            //sorting Highest to Lowest to display the high scores - stored in it's own class (Single Responsibility Principle).
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

        }
        public void DisplaySort(int[]numbers, ScoresForm f3)
            //Displays the sort in the ScoresForm listbox.
        {
            f3.lstHighScores.Refresh();
            for (int index = 0; index < numbers.Length; index++)
            {
                //key to adding the sorted array back into the listbox from the array.
                f3.lstHighScores.Items.Add(numbers[index]);
            }
        }
    }
}
