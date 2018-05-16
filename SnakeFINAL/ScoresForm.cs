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
    public partial class ScoresForm : Form
    {
        public ScoresForm()
        {
            InitializeComponent();
        }
        private string errorHandle;
        private void ScoresForm_Load(object sender, EventArgs e)
            //When the form loads, read from the text file and then call BubbleSort from SortFunction class.
        {
            //Enter key or button "close" pressed will close the score form.
            if (Input.KeyPressed(Keys.Enter))
            {
                this.Close();
            }
            try
            {
            //connect to the text file where the scores are stored.
            StreamReader sr = new StreamReader(@"C:\\Users\PHILO\Documents\SnakeHighscores.csv");
            int NumberOfScores = 0;
            //read in the text file but only to count how many entries there are.
            while (sr.ReadLine() != null)
            {
                NumberOfScores = NumberOfScores + 1;
            }
            //close the file when it is completed.
            sr.Close();
            //update the count from the iteration.
            //clears the listbox.
            lstHighScores.Items.Clear();
            //creates a new instance of SortReadWrite called obj.
            ReadWriteFunction obj = new ReadWriteFunction();
            //creates a new array of items(the count is how many we need to pass)
            int[] numbers = new int[NumberOfScores];
            //pass to the ReadFromFile method, the array and this.
            obj.ReadFromFile(numbers, this);
            lstHighScores.Items.Clear();
            //sorts the array read in then displays it in the listbox from highest score to lowest.
            SortFunction sort = new SortFunction();
            sort.BubbleSort(numbers);
            sort.DisplaySort(numbers, this);
            }
            catch (Exception er)
            {
                errorHandle = "Error " + er.Message;
                ErrorCheck ec = new ErrorCheck();
                //pass the error to the error handler to be checked and logged.
                ec.outputError(errorHandle);
            }
        }
        private void cmdClose_Click(object sender, EventArgs e)
            //close the scores form.
        {
            this.Close();
        }
    }
}