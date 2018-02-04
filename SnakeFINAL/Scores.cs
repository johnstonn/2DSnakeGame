using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snake
{
    public partial class Scores : Form
    {
        public Scores()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //storing the "count" of scores to be passed as a parameter.
            int Count;

            //Enter key or button "close" pressed will close the score form.

            if (Input.KeyPressed(Keys.Enter))
            {
                this.Close();
            }
            //connect to the text file where the scores are stored.
            StreamReader sr = new StreamReader(@"C:\\Users\PHILO\Documents\SnakeHighscores.csv");
            int newcount = 0;
            //read in the text file but only to count how many entries there are.
            while (sr.ReadLine() != null)
            {


                newcount = newcount + 1;

            }

            //close the file when it is completed.

            sr.Close();
            //update the count from the iteration.
            Count = newcount;


            //clears the listbox.
            listBox1.Items.Clear();
            //creates a new instance of SortReadWrite called obj.
            SortReadWrite obj = new SortReadWrite();
            //creates a new array of items(the count is how many we need to pass)
            int[] numbers = new int[Count];
            //pass to the ReadFromFile method, the array and this.
            obj.ReadFromFile(numbers, this);

            listBox1.Items.Clear();
            //sorts the array read in then displays it in the listbox from highest score to lowest.
            obj.BubbleSort(numbers, this);

        }


        private void cmdClose_Click(object sender, EventArgs e)
        {
            //close the scores form.
            this.Close();
        }
    }
}